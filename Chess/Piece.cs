using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    enum Cols
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
    enum Rows
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
    enum Pieces
    {
        Pawn = 1,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }
    enum Colors
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
                return new Position(row, col);
            }
            else throw new ArgumentException("Index out of bounds");
        }
        public static int GetIndexFromPosition(Position position)
        {
            int index = ((position.row) * 8 + position.col);
            if (index >= 0 && index < 64) return index;
            else throw new ArgumentException("Position out of bounds");
        }
        public bool IsPositionOnBoard()
        {
            if ((this.row >= 0 && this.row <= 7) && (this.col >= 0 && this.col <= 7)) return true;
            return false;
        }
        public bool IsEnemyOnField(Piece piece)
        {
            List<Piece> pieces = Board.Pieces;

            if (pieces.Where(p => p.position == this && p.color != piece.color).Count() != 0) return true;
            return false;
        }
        public bool IsFieldEmpty()
        {
            List<Piece> pieces = Board.Pieces;

            if (pieces.Where(p => p.position == this).Count() != 0) return false;
            return true;
        }
    }
    interface IPiece
    {
        public void Move();
        public void Capture();
        public List<Position> PossibleMoves();

    }
    public class Piece
    {
        public Position position;
        public int color;
        public char icon;
    }

    public class King : Piece, IPiece
    {
        public King(int positionIndex, int color)
        {
            this.position = Position.GetPositionFromIndex(positionIndex);
            this.color = color;

            if (this.color == (int)Colors.White) this.icon = '\u2654';
            else if (this.color == (int)Colors.Black) this.icon = '\u265a';

        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            tempPositions.Add(new Position(position.row + 1, position.col + 1));
            tempPositions.Add(new Position(position.row + 1, position.col - 1));
            tempPositions.Add(new Position(position.row - 1, position.col + 1));
            tempPositions.Add(new Position(position.row - 1, position.col - 1));
            tempPositions.Add(new Position(position.row + 1, position.col));
            tempPositions.Add(new Position(position.row - 1, position.col));
            tempPositions.Add(new Position(position.row, position.col + 1));
            tempPositions.Add(new Position(position.row, position.col - 1));

            foreach (Position tempPosition in tempPositions)
            {
                if (tempPosition.IsPositionOnBoard())
                {
                    availablePositions.Add(tempPosition);
                }
            }
            return availablePositions;
        }
    }
    public class Queen : Piece, IPiece
    {
        public Queen(int positionIndex, int color)
        {
            this.position = Position.GetPositionFromIndex(positionIndex);
            this.color = color;

            if (this.color == (int)Colors.White) this.icon = '\u2655';
            else if (this.color == (int)Colors.Black) this.icon = '\u265b';

        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(position.row + i, position.col + i));//Bishop
                tempPositions.Add(new Position(position.row + i, position.col - i));
                tempPositions.Add(new Position(position.row - i, position.col + i));
                tempPositions.Add(new Position(position.row - i, position.col - i));
                tempPositions.Add(new Position(position.row + i, position.col));//Rook
                tempPositions.Add(new Position(position.row - i, position.col));
                tempPositions.Add(new Position(position.row, position.col + i));
                tempPositions.Add(new Position(position.row, position.col - i));
            }

            foreach (Position tempPosition in tempPositions)
            {
                if (tempPosition.IsPositionOnBoard())
                {
                    availablePositions.Add(tempPosition);
                }
            }
            return availablePositions;
        }
    }
    public class Bishop : Piece, IPiece
    {
        public Bishop(int positionIndex, int color)
        {
            this.position = Position.GetPositionFromIndex(positionIndex);
            this.color = color;

            if (this.color == (int)Colors.White) this.icon = '\u2657';
            else if (this.color == (int)Colors.Black) this.icon = '\u265d';

        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(position.row + i, position.col + i));
                tempPositions.Add(new Position(position.row + i, position.col - i));
                tempPositions.Add(new Position(position.row - i, position.col + i));
                tempPositions.Add(new Position(position.row - i, position.col - i));
            }

            foreach (Position tempPosition in tempPositions)
            {
                if (tempPosition.IsPositionOnBoard())
                {
                    availablePositions.Add(tempPosition);
                }
            }
            return availablePositions;
        }
    }
    public class Knight : Piece, IPiece
    {
        public Knight(int positionIndex, int color)
        {
            this.position = Position.GetPositionFromIndex(positionIndex);
            this.color = color;

            if (this.color == (int)Colors.White) this.icon = '\u2658';
            else if (this.color == (int)Colors.Black) this.icon = '\u265e';

        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            tempPositions.Add(new Position(position.row + 2, position.col + 1));
            tempPositions.Add(new Position(position.row + 1, position.col + 2));
            tempPositions.Add(new Position(position.row + 2, position.col - 1));
            tempPositions.Add(new Position(position.row + 1, position.col - 2));
            tempPositions.Add(new Position(position.row - 2, position.col - 1));
            tempPositions.Add(new Position(position.row - 1, position.col - 2));
            tempPositions.Add(new Position(position.row - 2, position.col + 1));
            tempPositions.Add(new Position(position.row - 1, position.col + 2));

            foreach (Position tempPosition in tempPositions)
            {
                if (tempPosition.IsPositionOnBoard())
                {
                    availablePositions.Add(tempPosition);
                }
            }
            return availablePositions;
        }
    }
    public class Rook : Piece, IPiece
    {
        public Rook(int positionIndex, int color)
        {
            this.position = Position.GetPositionFromIndex(positionIndex);
            this.color = color;

            if (this.color == (int)Colors.White) this.icon = '\u2656';
            else if (this.color == (int)Colors.Black) this.icon = '\u265c';

        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(position.row + i, position.col));
                tempPositions.Add(new Position(position.row - i, position.col));
                tempPositions.Add(new Position(position.row, position.col + i));
                tempPositions.Add(new Position(position.row, position.col - i));
            }
            foreach (Position tempPosition in tempPositions)
            {
                if (tempPosition.IsPositionOnBoard())
                {
                    availablePositions.Add(tempPosition);
                }
            }
            return availablePositions;
        }
    }
    public class Pawn : Piece, IPiece
    {
        public Pawn(int positionIndex, int color)
        {
            this.position = Position.GetPositionFromIndex(positionIndex);
            this.color = color;

            if (this.color == (int)Colors.White) this.icon = '\u2659';
            else if (this.color == (int)Colors.Black) this.icon = '\u265f';

        }
        public void Capture()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }

        public List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> tempPositionsCapture = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            tempPositions.Add(new Position(position.row + 1, position.col));

            if (position.row == 1) tempPositions.Add(new Position(position.row + 2, position.col));

            tempPositionsCapture.Add(new Position(position.row + 1, position.col + 1));
            tempPositionsCapture.Add(new Position(position.row + 1, position.col + 1));

            foreach (Position tempPosition in tempPositions)
            {
                if (tempPosition.IsPositionOnBoard())
                {
                    availablePositions.Add(tempPosition);
                }
            }

            foreach (Position tempPosition in tempPositionsCapture)
            {
                if (tempPosition.IsPositionOnBoard() && tempPosition.IsEnemyOnField(this))
                {
                    availablePositions.Add(tempPosition);
                }
            }

            return availablePositions;
        }
    }
}