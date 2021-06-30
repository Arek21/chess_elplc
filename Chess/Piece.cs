using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{ 
    enum cols
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
    enum pieces
    {
        Pawn = 1,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }
    enum colors
    {
        White,
        Black
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
        public static Position GetPositionFromIndex(int index)
        {
            if (index >= 0 && index < 64)
            {
                int row = (int)Math.Floor(Convert.ToDouble(index) / 8);
                int col = index - (8 * row);
                return new Position(row - 1, col - 1);
            }
            else throw new ArgumentException("Index out of bounds");          
        }
        public static int GetIndexFromPosition(Position position)
        {
            int index = ((position.row) * 8 + position.col);
            if (index >= 0 && index < 64) return index;
            else throw new ArgumentException("Position out of bounds");
        }
    }

    interface IPiece
    {
        public void Move();
        public void Capture();
        public List<int> PossibleMoves();

    }
    public class Piece
    {   
        public Position position;
        public int color;
        public string icon;
    }


    public class King : Piece, IPiece
    {
        public King()
        {
          
        }

        public void Capture()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
    public class Queen : Piece, IPiece
    {
        public void Capture()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
    public class Bishop : Piece, IPiece
    {
        public void Capture()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
    public class Knight : Piece, IPiece
    {
        public void Capture()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
    public class Rook : Piece, IPiece
    {
        public void Capture()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();

        }
    }

    public class Pawn : Piece, IPiece
    {
        public Pawn(int positionIndex, int color)
        {
           
            this.position = Position.GetPositionFromIndex(positionIndex);        
            this.color = color;

            if(this.color == (int) colors.White)
            {
                this.icon = "\u2659";
            }
            else if(this.color == (int)colors.Black)
            {
                this.icon = "\u265f";
            }
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
