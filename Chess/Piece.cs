using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public enum Cols
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
    public enum Rows
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
    public enum Pieces
    {
        Pawn = 1,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }
    public enum Colors
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

            if (pieces.Where(p => p.Position == this && p.Color != piece.Color).Count() != 0) return true;
            return false;
        }
        public bool IsFieldEmpty()
        {
            List<Piece> pieces = Board.Pieces;

            if (pieces.Where(p => p.Position == this).Count() != 0) return false;
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
        private Position position;
        private Colors color;
        private char icon;

        public Position Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Colors Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public char Icon
        {
            get { return this.icon; }
            set { this.icon = value; }
        }

    }

    public class King : Piece, IPiece
    {
        public King(int positionIndex, Colors color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == Colors.White) this.Icon = '\u2654';
            else if (this.Color == Colors.Black) this.Icon = '\u265a';

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

            tempPositions.Add(new Position(Position.row + 1, Position.col + 1));
            tempPositions.Add(new Position(Position.row + 1, Position.col - 1));
            tempPositions.Add(new Position(Position.row - 1, Position.col + 1));
            tempPositions.Add(new Position(Position.row - 1, Position.col - 1));
            tempPositions.Add(new Position(Position.row + 1, Position.col));
            tempPositions.Add(new Position(Position.row - 1, Position.col));
            tempPositions.Add(new Position(Position.row, Position.col + 1));
            tempPositions.Add(new Position(Position.row, Position.col - 1));

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
        public Queen(int positionIndex, Colors color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == Colors.White) this.Icon = '\u2655';
            else if (this.Color == Colors.Black) this.Icon = '\u265b';

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
                tempPositions.Add(new Position(Position.row + i, Position.col + i));//Bishop
                tempPositions.Add(new Position(Position.row + i, Position.col - i));
                tempPositions.Add(new Position(Position.row - i, Position.col + i));
                tempPositions.Add(new Position(Position.row - i, Position.col - i));
                tempPositions.Add(new Position(Position.row + i, Position.col));//Rook
                tempPositions.Add(new Position(Position.row - i, Position.col));
                tempPositions.Add(new Position(Position.row, Position.col + i));
                tempPositions.Add(new Position(Position.row, Position.col - i));
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
        public Bishop(int positionIndex, Colors color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == Colors.White) this.Icon = '\u2657';
            else if (this.Color == Colors.Black) this.Icon = '\u265d';

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
                tempPositions.Add(new Position(Position.row + i, Position.col + i));
                tempPositions.Add(new Position(Position.row + i, Position.col - i));
                tempPositions.Add(new Position(Position.row - i, Position.col + i));
                tempPositions.Add(new Position(Position.row - i, Position.col - i));
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
        public Knight(int positionIndex, Colors color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == Colors.White) this.Icon = '\u2658';
            else if (this.Color == Colors.Black) this.Icon = '\u265e';

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

            tempPositions.Add(new Position(Position.row + 2, Position.col + 1));
            tempPositions.Add(new Position(Position.row + 1, Position.col + 2));
            tempPositions.Add(new Position(Position.row + 2, Position.col - 1));
            tempPositions.Add(new Position(Position.row + 1, Position.col - 2));
            tempPositions.Add(new Position(Position.row - 2, Position.col - 1));
            tempPositions.Add(new Position(Position.row - 1, Position.col - 2));
            tempPositions.Add(new Position(Position.row - 2, Position.col + 1));
            tempPositions.Add(new Position(Position.row - 1, Position.col + 2));

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
        public Rook(int positionIndex, Colors color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == Colors.White) this.Icon = '\u2656';
            else if (this.Color == Colors.Black) this.Icon = '\u265c';

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
                tempPositions.Add(new Position(Position.row + i, Position.col));
                tempPositions.Add(new Position(Position.row - i, Position.col));
                tempPositions.Add(new Position(Position.row, Position.col + i));
                tempPositions.Add(new Position(Position.row, Position.col - i));
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
        public Pawn(int positionIndex, Colors color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == Colors.White) this.Icon = '\u2659';
            else if (this.Color == Colors.Black) this.Icon = '\u265f';

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

            tempPositions.Add(new Position(Position.row + 1, Position.col));

            if (Position.row == 1) tempPositions.Add(new Position(Position.row + 2, Position.col));

            tempPositionsCapture.Add(new Position(Position.row + 1, Position.col + 1));
            tempPositionsCapture.Add(new Position(Position.row + 1, Position.col + 1));

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