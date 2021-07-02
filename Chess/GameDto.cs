using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class GameDto
    {
        private bool isMyTurn;
        private ColorsEnum playerColor;
        private List<Piece> piecesOnBoard;
        private Position recentMove;

        public GameDto(bool isMyTurn, List<Piece> piecesOnBoard,ColorsEnum playerColor,Position recentMove)
        {
            this.isMyTurn = isMyTurn;
            this.playerColor = playerColor;
            this.piecesOnBoard = piecesOnBoard;
            this.recentMove = recentMove;
        }

        public GameDto()
        {
      
        }

        public List<Piece> PiecesOnBoard
        {
            get { return this.piecesOnBoard; }
            set { this.piecesOnBoard = value; }
        }

        public ColorsEnum PlayerColor
        {
            get { return this.playerColor; }
            set { this.playerColor = value; }
        }

        public bool IsMyTurn
        {
            get { return this.isMyTurn; }
            set { this.isMyTurn = value; }
        }

        public Position RecentMove
        {
            get { return this.recentMove; }
            set { this.recentMove = value; }
        }
    }
}
