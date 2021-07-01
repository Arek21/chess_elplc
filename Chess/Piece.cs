﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public enum ColsEnum
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
    public enum RowsEnum
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
    public enum PiecesEnum
    {
        Pawn = 1,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }
    public enum ColorsEnum
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
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Position p = (Position)obj;
                return (this.row == p.row) && (this.col == p.col);
            }
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
            return (this.row >= 0 && this.row <= 7) && (this.col >= 0 && this.col <= 7);
        }
        public bool IsEnemyOnField(Piece piece)
        {
            List<Piece> pieces = Board.Pieces;
            if (pieces.Exists(p => p.Position.Equals(this) && !p.Color.Equals(piece.Color))) return true;
            return false;
        }
        public bool IsFieldEmpty()
        {
            List<Piece> pieces = Board.Pieces;
            if (pieces.Exists(p => p.Position.Equals(this))) return false;
            return true;
        }
    }
    public abstract class Piece
    {
        private Position position;
        private List<Position> possibleMoves;
        private ColorsEnum color;
        private char icon;

        public Position Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public ColorsEnum Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public char Icon
        {
            get { return this.icon; }
            set { this.icon = value; }
        }

        public abstract void Move();
        public abstract void Capture();
        public abstract List<Position> PossibleMoves();

    }
    public class King : Piece
    {
        public King(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2654';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265a';

        }
        public override void Capture()
        {
            throw new NotImplementedException();
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override List<Position> PossibleMoves()
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
    public class Queen : Piece
    {
        public Queen(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2655';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265b';

        }
        public override void Capture()
        {
            throw new NotImplementedException();
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override List<Position> PossibleMoves()
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
    public class Bishop : Piece
    {
        public Bishop(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2657';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265d';

        }
        public override void Capture()
        {
            throw new NotImplementedException();
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override List<Position> PossibleMoves()
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
    public class Knight : Piece
    {
        public Knight(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2658';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265e';

        }
        public override void Capture()
        {
            throw new NotImplementedException();
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override List<Position> PossibleMoves()
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
    public class Rook : Piece
    {
        public Rook(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2656';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265c';

        }
        public override void Capture()
        {
            throw new NotImplementedException();
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col));
                if (!tempPositions[tempPositions.Count - 1].IsFieldEmpty()) break;
            }
            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col));
                if (!tempPositions[tempPositions.Count - 1].IsFieldEmpty()) break;
            }
            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(Position.row, Position.col + i));
                if (!tempPositions[tempPositions.Count - 1].IsFieldEmpty()) break;
            }
            for (int i = 0; i < 7; i++)
            {
                tempPositions.Add(new Position(Position.row, Position.col - i));
                if (!tempPositions[tempPositions.Count - 1].IsFieldEmpty()) break;
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
    public class Pawn : Piece
    {
        public Pawn(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2659';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265f';

        }
        public override void Capture()
        {
            throw new NotImplementedException();
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> tempPositionsCapture = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            if (new Position(Position.row - 1, Position.col).IsFieldEmpty())
            {
                tempPositions.Add(new Position(Position.row - 1, Position.col));
                if (new Position(Position.row - 2, Position.col).IsFieldEmpty()) tempPositions.Add(new Position(Position.row - 2, Position.col));
            }

            tempPositionsCapture.Add(new Position(Position.row + 1, Position.col + 1));
            tempPositionsCapture.Add(new Position(Position.row + 1, Position.col - 1));

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