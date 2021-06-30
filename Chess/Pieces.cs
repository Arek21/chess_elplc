using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
  
    enum columns
    {
        cA,
        cB,
        cC,
        cD,
        cE,
        cF,
        cG,
        cH
    }
    enum rows
    {
        r1,
        r2,
        r3,
        r4,
        r5,
        r6,
        r7,
        r8
    }

    public class Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    public class Pieces
    {
        public Position position;
        public bool colour;

    }
    interface IPiece
    {
        public void Move();
        public void ActualPosition();
        public List<int> PossibleMove();

    }
    public class King : Pieces, IPiece
    {
        public King()
        {
            this.position = new Position(0, 0);
            this.colour = false;
        }
        public void IsCheck()
        {

        }
        public void IsMat()
        {

        }
        public void IsPat()
        {

        }
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public void PossibleMove()
        {
            
        }

        List<int> IPiece.PossibleMove()
        {
            throw new NotImplementedException();
        }
    }
    public class Queen : IPiece
    {
        private bool colour;
        private bool isCaptured;
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public void PossibleMove()
        {
            throw new NotImplementedException();
        }

        List<int> IPiece.PossibleMove()
        {
            throw new NotImplementedException();
        }
    }
    public class Bishop : IPiece
    {
        private bool colour;
        private bool isCaptured;
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public void PossibleMove()
        {
            throw new NotImplementedException();
        }

        List<int> IPiece.PossibleMove()
        {
            throw new NotImplementedException();
        }
    }
    public class Knight : IPiece
    {
        private bool colour;
        private bool isCaptured;
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public void PossibleMove()
        {
            throw new NotImplementedException();
        }

        List<int> IPiece.PossibleMove()
        {
            throw new NotImplementedException();
        }
    }
    public class Rock : Pieces, IPiece
    {
        private bool isCaptured;
        private int field;
        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void PossibleMove()
        {
            throw new NotImplementedException();
        }

        List<int> IPiece.PossibleMove()
        {
            List<int> posMoveList = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                field = 8 * position.row + (position.col + i);
            }

            return posMoveList;
        }
    }
    public class Pawn : Pieces, IPiece
    {
        private bool isCaptured;
        private int field;

        public Pawn()
        {
            this.position = new Position(0, 0);
            this.colour = false;
        }
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMove()
        {
            List<int> posMoveList = new List<int>();

            if (position.row > 0 && position.row < 7)
            {
                field = 8 * position.row + (position.col + 1);
                posMoveList.Add(field);
            }
            if(position.row == 1)
            {
                field = 8 * position.row + (position.col + 2);
                posMoveList.Add(field);
            }
            //Dodać jeszcze bicie
            return posMoveList;

        }
    }
}
