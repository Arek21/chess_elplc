using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class Game
    {
        private WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());
        private bool onTurn;
        private ColorsEnum playerColor;
        public Game(bool onStartTurn)
        {
            List<BoardDto> boardList = client.GetBoard().ToList();
            List<Piece> pieces = new List<Piece>();

            foreach (BoardDto element in boardList)
            {
                switch ((PiecesEnum?) element.PieceId)
                {
                    case PiecesEnum.Pawn:
                        pieces.Add(new Pawn(element.Id - 1, (ColorsEnum) element.ColorId - 1));
                        break;
                    case PiecesEnum.Knight:
                        pieces.Add(new Knight(element.Id - 1, (ColorsEnum) element.ColorId - 1));
                        break;
                    case PiecesEnum.Bishop:
                        pieces.Add(new Bishop(element.Id - 1, (ColorsEnum) element.ColorId - 1));
                        break;
                    case PiecesEnum.Rook:
                        pieces.Add(new Rook(element.Id - 1, (ColorsEnum) element.ColorId - 1));
                        break;
                    case PiecesEnum.Queen:
                        pieces.Add(new Queen(element.Id - 1, (ColorsEnum) element.ColorId - 1));
                        break;
                    case PiecesEnum.King:
                        pieces.Add(new King(element.Id - 1, (ColorsEnum) element.ColorId - 1));
                        break;
                }
            }

            Board.Pieces = pieces;
            this.onTurn = onStartTurn;

            if (this.onTurn) this.playerColor = ColorsEnum.White;
            else this.playerColor = ColorsEnum.Black;
        }

        public bool OnTurn
        {
            get { return this.onTurn; }
            set { this.onTurn = value; }
        }

        public ColorsEnum PlayerColor
        {
            get { return this.playerColor; }
            set { this.playerColor = value; }
        }

        public void MakeTurn()
        {

        }
    }
}
