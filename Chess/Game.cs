using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class Game
    {
        WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());
        public Game()
        {
            List<BoardDto> boardList = client.GetBoard().ToList();
            List<Piece> pieces = new List<Piece>();

            foreach (BoardDto element in boardList)
            {
                switch (element.PieceId)
                {
                    case 1:
                        pieces.Add(new Pawn(element.Id-1, (int) element.ColorId-1));
                        break;
                    case 2:
                        pieces.Add(new Knight(element.Id - 1, (int)element.ColorId - 1));
                        break;
                    case 3:
                        pieces.Add(new Bishop(element.Id - 1, (int)element.ColorId - 1));
                        break;
                    case 4:
                        pieces.Add(new Rook(element.Id - 1, (int)element.ColorId - 1));
                        break;
                    case 5:
                        pieces.Add(new Queen(element.Id - 1, (int)element.ColorId - 1));
                        break;
                    case 6:
                        pieces.Add(new King(element.Id - 1, (int)element.ColorId - 1));
                        break;
                }
            }

            Board.Pieces = pieces;
        }

    }
}
