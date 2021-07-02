using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class Game
    {
        private static WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());

        private static bool isMyTurn;
        private static ColorsEnum playerColor;
        private static List<Piece> piecesOnBoard = new List<Piece>();

        public static void initGame(bool onStartTurn)
        {
            List<BoardDto> boardDtoList = client.GetBoard().ToList();
            List<Piece> pieces = new List<Piece>();

            foreach (BoardDto boardDto in boardDtoList)
            {
                switch ((PiecesEnum?)boardDto.PieceId-1)
                {
                    case PiecesEnum.Pawn:
                        pieces.Add(new Pawn(boardDto.Id - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Knight:
                        pieces.Add(new Knight(boardDto.Id - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Bishop:
                        pieces.Add(new Bishop(boardDto.Id - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Rook:
                        pieces.Add(new Rook(boardDto.Id - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Queen:
                        pieces.Add(new Queen(boardDto.Id - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.King:
                        pieces.Add(new King(boardDto.Id - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                }
            }

            Game.PiecesOnBoard = pieces;
            isMyTurn = onStartTurn;

            if (isMyTurn) playerColor = ColorsEnum.White;
            else
            {
                playerColor = ColorsEnum.Black;
            }
        }
        public static List<Piece> PiecesOnBoard
        {
            get { return piecesOnBoard; }
            set { piecesOnBoard = value; }
        }
        public static bool IsMyTurn
        {
            get { return isMyTurn; }
            set { isMyTurn = value; }
        }
        public static ColorsEnum PlayerColor
        {
            get { return playerColor; }
            set { playerColor = value; }
        }
  
        public static List<int> GetPossibleMoves(int selectedPositionId)
        {
            Position selectedPosition = Position.GetPositionFromIndex(selectedPositionId);
            Piece selectedPiece = PiecesOnBoard.Find(p => p.Position.Equals(selectedPosition));
            List<Position> possiblePositionsToMove = selectedPiece.PossibleMoves();
            List<int> possibleMoves = new List<int>();

            foreach(Position position in possiblePositionsToMove)
            {
                possibleMoves.Add(Position.GetIndexFromPosition(position));
            }

            return possibleMoves;
        }
        public static bool IsFieldEmpty(int selectedPositionId)
        {
            Position position = Position.GetPositionFromIndex(selectedPositionId);
            return position.IsFieldEmpty();
        }
        public static bool IsMyPiece(int selectedPositionId)
        {
            if (!IsFieldEmpty(selectedPositionId))
            {
                Position selectedPosition = Position.GetPositionFromIndex(selectedPositionId);
                Piece selectedPiece = PiecesOnBoard.Find(p => p.Position.Equals(selectedPosition));
                return PiecesOnBoard.Find(p => p.Position.Equals(selectedPiece.Position)).Color.Equals(Game.PlayerColor);
            }

            return false;
        }
        public static bool IsMyOpontentsPiece(int selectedPositionId)
        {
            if (!IsFieldEmpty(selectedPositionId))
            {
                Position selectedPosition = Position.GetPositionFromIndex(selectedPositionId);
                Piece selectedPiece = PiecesOnBoard.Find(p => p.Position.Equals(selectedPosition));
                return PiecesOnBoard.Find(p => p.Position.Equals(selectedPiece.Position)).Color.Equals(GetOpontentsColor());
            }

            return false;
        }
        public static void Move(int selectedPieceId, int selectedFieldId)
        {
            Position selectedPiecePosition = Position.GetPositionFromIndex((int)selectedPieceId);
            Piece selectedPiece = piecesOnBoard.Find(p => p.Position.Equals(selectedPiecePosition));
            selectedPiece.Position = Position.GetPositionFromIndex(selectedFieldId);
        }
        public static void Capture(int myPieceId, int opontentsPieceId)
        {
            Position myPiecePosition = Position.GetPositionFromIndex((int)myPieceId);
            Piece myPiece = piecesOnBoard.Find(p => p.Position.Equals(myPiecePosition));

            Position opontentsPiecePosition = Position.GetPositionFromIndex((int)opontentsPieceId);
            Piece opontentsPiece = piecesOnBoard.Find(p => p.Position.Equals(opontentsPiecePosition));

            Position tempPosition = opontentsPiecePosition;

            PiecesOnBoard.Remove(opontentsPiece);
            myPiece.Position = tempPosition;
        }
        private static ColorsEnum GetOpontentsColor()
        {
            if (PlayerColor.Equals(ColorsEnum.White)) return ColorsEnum.Black;
            return ColorsEnum.White;
        }
        public static void ReverseIndexOnBoard ()
        {
            
        }
    }
}
