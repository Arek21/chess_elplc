using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class GameDto
    {
        private bool isMyTurn;
        private List<Piece> piecesOnBoard;

        public GameDto(bool isMyTurn, List<Piece> piecesOnBoard)
        {
            this.isMyTurn = isMyTurn;
            this.piecesOnBoard = piecesOnBoard;            
        }

        public GameDto()
        {
      
        }

        public List<Piece> PiecesOnBoard
        {
            get { return this.piecesOnBoard; }
            set { this.piecesOnBoard = value; }
        }

        public bool IsMyTurn
        {
            get { return this.isMyTurn; }
            set { this.isMyTurn = value; }
        }
    }
}
