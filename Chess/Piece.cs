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
            int field;
            List<int> posMoveList = new List<int>();
                 
            if (position.row + 1 <= 7 && position.col <= 7) //prawa górna diagonala
            {
                field = 8 * (position.row + 1) + (position.col + 1);
                posMoveList.Add(field);
        }
            if (position.row + 1 <= 7 && position.col >= 0) //lewa górna diagonala
            {
                field = 8 * (position.row + 1) + (position.col - 1);
                posMoveList.Add(field);
    }
            if (position.row + 1 >= 0 && position.col >= 0) //lewa dolna diagonala
            {
                field = 8 * (position.row - 1) + (position.col - 1);
                posMoveList.Add(field);
            }
            if (position.row + 1 >= 0 && position.col <= 7) //prawa dolna diagonala
            {
                field = 8 * (position.row - 1) + (position.col + 1);
                posMoveList.Add(field);
            }
            field = 8 * position.row + 1;
            posMoveList.Add(field);
            field = 8 * position.row - 1;
            posMoveList.Add(field);

            field = 8 * 1 + position.col;
            posMoveList.Add(field);
            field = 8 * 1 - position.col;
            posMoveList.Add(field);

            return posMoveList;
        }
    }
    public class Queen : Piece, IPiece
    {
        public void Capture()
        public void Move()
        {
            throw new NotImplementedException();
        }

        {
            throw new NotImplementedException();
        }

        public List<int> PossibleMoves()
        {
            throw new NotImplementedException();
            int field;

            List<int> posMoveList = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                if (position.row + i <= 7 && position.col <= 7) //prawa górna diagonala
                {
                    field = 8 * (position.row + i) + (position.col + i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (position.row + i <= 7 && position.col >= 0) //lewa górna diagonala
                {
                    field = 8 * (position.row + i) + (position.col - i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (position.row + i >= 0 && position.col >= 0) //lewa dolna diagonala
                {
                    field = 8 * (position.row - i) + (position.col - i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (position.row + i >= 0 && position.col <= 7) //prawa dolna diagonala
                {
                    field = 8 * (position.row - i) + (position.col + i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)//dostepne kolumny
            {
                field = 8 * position.row + i;
                posMoveList.Add(field);

                if (field == 8 * position.row + position.col)
                {
                    posMoveList.Remove(field);
                }
            }
            for (int i = 0; i < 8; i++)//dostepne rzedy
            {
                field = 8 * i + position.col;
                posMoveList.Add(field);

                if (field == 8 * position.row + position.col)
                {
                    posMoveList.Remove(field);
                }
            }

            return posMoveList;
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
            int field;
            List<int> posMoveList = new List<int>();

        public List<int> PossibleMoves()
            for(int i = 0; i < 8; i++)
            {
                if(position.row + i <= 7 && position.col <= 7) //prawa górna diagonala
                {
                    field = 8 * (position.row + i) + (position.col + i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (position.row + i <= 7 && position.col >= 0) //lewa górna diagonala
                {
                    field = 8 * (position.row + i) + (position.col - i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (position.row + i >= 0 && position.col >= 0) //lewa dolna diagonala
                {
                    field = 8 * (position.row - i) + (position.col - i);
                    posMoveList.Add(field);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (position.row + i >= 0 && position.col <= 7) //prawa dolna diagonala
                {
                    field = 8 * (position.row - i) + (position.col + i);
                    posMoveList.Add(field);
                }
                else
        {
            throw new NotImplementedException();
                    break;
                }
            }

            return posMoveList;
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
            int field;
            List<int> posMoveList = new List<int>();

            if(position.col + 1 <= 7 && position.row + 2 <= 7)
            {
                field = 8 * (position.row + 2) + (position.col + 1);

                //field = Position.fun(new Position(position.row+1,position.col+1));

                posMoveList.Add(field);
            }
            if (position.col + 2 <= 7 && position.row + 1 <= 7)
            {
                field = 8 * (position.row + 1) + (position.col + 2);
                posMoveList.Add(field);
            }
            if (position.col - 1 >= 0 && position.row + 2 <= 7)
            {
                field = 8 * (position.row + 2) + (position.col - 1);
                posMoveList.Add(field);
            }
            if (position.col - 2 >= 0 && position.row + 1 <= 7)
            {
                field = 8 * (position.row + 1) + (position.col - 2);
                posMoveList.Add(field);
            }
            if (position.col - 1 >= 0 && position.row - 2 >= 0)
            {
                field = 8 * (position.row - 2) + (position.col - 1);
                posMoveList.Add(field);
            }
            if (position.col - 2 >= 0 && position.row - 1 >= 0)
            {
                field = 8 * (position.row - 1) + (position.col - 2);
                posMoveList.Add(field);
            }
            if (position.col + 1 <= 7 && position.row - 2 >= 0)
            {
                field = 8 * (position.row - 2) + (position.col + 1);
                posMoveList.Add(field);
            }
            if (position.col + 2 <= 7 && position.row - 1 >= 0)
            {
                field = 8 * (position.row - 1) + (position.col + 2);
                posMoveList.Add(field);
            }

            return posMoveList;
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
            int field;
            List<int> posMoveList = new List<int>();

            for (int i = 0; i < 8; i++)//dostepne kolumny
            {
                field = 8 * position.row + i;
                posMoveList.Add(field);

                if (field == 8 * position.row + position.col)
                {
                    posMoveList.Remove(field);
        }
    }

    public class Pawn : Piece, IPiece
    {
        public Pawn(int positionIndex, int color)
            for (int i = 0; i < 8; i++)//dostepne rzedy
        {
           
            this.position = Position.GetPositionFromIndex(positionIndex);        
            this.color = color;
                field = 8 * i + position.col;
                posMoveList.Add(field);

            if(this.color == (int) colors.White)
                if (field == 8 * position.row + position.col)
            {
                this.icon = "\u2659";
                    posMoveList.Remove(field);
                }
            }

            return posMoveList;
        }
            }
            else if(this.color == (int)colors.Black)
    public class Pawn : Piece, IPiece
    {
        public Pawn()
            {
                this.icon = "\u265f";
            }
            this.position = new Position(0, 0);
            this.colour = false;
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
            int field;
            List<int> posMoveList = new List<int>();

            if (position.row >= 0 && position.row <= 7)
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
