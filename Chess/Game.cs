using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceReference1;

namespace Chess
{
    class Game
    {
        private static WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());

        private static bool isMyTurn;
        private static ColorsEnum playerColor;
        private static List<Piece> piecesOnBoard = new List<Piece>();
        private static SessionDto session;
        private static string playerName;
        public static void initGame(SessionDto session, string playerName)
        {
            Game.session = session;
            Game.playerName = playerName;

            List<BoardDto> boardDtoList = client.GetGameState(session.Id, session.RoomName).ToList();
            List<Piece> pieces = new List<Piece>();

            foreach (BoardDto boardDto in boardDtoList)
            {
                switch ((PiecesEnum?)boardDto.PieceId - 1)
                {
                    case PiecesEnum.Pawn:
                        pieces.Add(new Pawn(boardDto.PositionIndex - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Knight:
                        pieces.Add(new Knight(boardDto.PositionIndex - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Bishop:
                        pieces.Add(new Bishop(boardDto.PositionIndex - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Rook:
                        pieces.Add(new Rook(boardDto.PositionIndex - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.Queen:
                        pieces.Add(new Queen(boardDto.PositionIndex - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                    case PiecesEnum.King:
                        pieces.Add(new King(boardDto.PositionIndex - 1, (ColorsEnum)boardDto.ColorId - 1));
                        break;
                }
            }

            if (playerName == session.FirstPlayer)
            {
                playerColor = ColorsEnum.White;
                Game.PiecesOnBoard = pieces;
                isMyTurn = session.FirstPlayerOnTurn;
            }
            else if (playerName == session.SecondPlayer)
            {
                playerColor = ColorsEnum.Black;
                Game.PiecesOnBoard = Game.ReverseBoard(pieces.ToList());
                isMyTurn = !session.FirstPlayerOnTurn;
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

            foreach (Position position in possiblePositionsToMove)
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
            Game.IsMyTurn = false;
            Game.SaveGameState(Game.session, Game.PiecesOnBoard);
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
            Game.IsMyTurn = false;
            Game.SaveGameState(Game.session, Game.PiecesOnBoard);

        }
        public static ColorsEnum GetOpontentsColor()
        {
            if (PlayerColor.Equals(ColorsEnum.White)) return ColorsEnum.Black;
            return ColorsEnum.White;
        }
        public static List<Piece> ReverseBoard(List<Piece> pieces)
        {
            List<Piece> piecesTemp = new List<Piece>();

            foreach(Piece piece in pieces)
            {
                piecesTemp.Add(Piece.Clone(piece));
            }
  
            foreach (Piece piece in piecesTemp)
            {
                piece.Position = Position.GetPositionFromIndex(63 - Position.GetIndexFromPosition(piece.Position));
            }
            return piecesTemp;
        }
        public static void SaveGameState(SessionDto session, List<Piece> pieces)
        {
            List<BoardDto> board = new List<BoardDto>();

            if (playerName.Equals(session.SecondPlayer)) pieces = ReverseBoard(pieces.ToList());

            foreach (Piece piece in pieces)
            {
                BoardDto boardItem = new BoardDto();
                boardItem.PositionIndex = Position.GetIndexFromPosition(piece.Position) + 1;
                boardItem.ColorId = (int)piece.Color + 1;

                switch (piece.GetType().Name)
                {
                    case "Pawn":
                        boardItem.PieceId = (int)PiecesEnum.Pawn + 1;
                        break;
                    case "Knight":
                        boardItem.PieceId = (int)PiecesEnum.Knight + 1;
                        break;
                    case "Bishop":
                        boardItem.PieceId = (int)PiecesEnum.Bishop + 1;
                        break;
                    case "Rook":
                        boardItem.PieceId = (int)PiecesEnum.Rook + 1;
                        break;
                    case "Queen":
                        boardItem.PieceId = (int)PiecesEnum.Queen + 1;
                        break;
                    case "King":
                        boardItem.PieceId = (int)PiecesEnum.King + 1;
                        break;
                }

                board.Add(boardItem);
            }


            SessionDto sessionDto = new SessionDto();
            sessionDto.Id = session.Id;
            sessionDto.IsBusy = session.IsBusy;
            sessionDto.FirstPlayerOnTurn = session.FirstPlayerOnTurn;
            if (playerName == session.FirstPlayer) sessionDto.FirstPlayerOnTurn = false;
            else if (playerName == session.SecondPlayer) sessionDto.FirstPlayerOnTurn = true;
            sessionDto.SecondPlayer = session.SecondPlayer;
            sessionDto.RoomName = session.RoomName;

            List<BoardDto> boardDto = new List<BoardDto>();
            boardDto = board.ToList();

            Task.Run(() =>
            {
                client.SaveGameState(sessionDto, board.ToList().ToArray());
            });

        }

    }
}
