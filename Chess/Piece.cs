using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public enum PiecesEnum
    {
        Pawn,
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

        public Position(Position position)
        {
            this.row = position.row;
            this.col = position.col;
        }

        public Position()
        {

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
            List<Piece> pieces = Game.PiecesOnBoard;
            if (pieces.Exists(p => p.Position.Equals(this) && !p.Color.Equals(piece.Color))) return true;
            return false;
        }
        public bool IsFieldEmpty()
        {
            List<Piece> pieces = Game.PiecesOnBoard;
            if (pieces.Exists(p => p.Position.Equals(this))) return false;
            return true;
        }
    }
    public abstract class Piece
    {
        private Position position;
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
        public static Piece Clone(Piece piece)
        {
            switch (piece.GetType().Name)
            {
                case "Pawn":
                    return new Pawn((Pawn) piece);
                    break;
                case "Knight":
                    return new Knight((Knight) piece);
                    break;
                case "Bishop":
                    return new Bishop((Bishop) piece);
                    break;
                case "Rook":
                    return new Rook((Rook) piece);
                    break;
                case "Queen":
                    return new Queen((Queen) piece);
                    break;
                case "King":
                    return new King((King) piece);
                    break;
                default:
                    return null;
                    break;
            }
        }

        public abstract List<Position> PossibleMoves();

    }
    public class King : Piece
    {
        public King()
        {

        }

        public King(King king)
        {
            this.Position = new Position(king.Position);
            this.Color = king.Color;
            this.Icon = king.Icon;
        }
        public King(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2654';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265a';

        }
        public override List<Position> PossibleMoves()
        {

            List<Position> tempPositions = new List<Position>();
            List<Position> temptempPosition = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            temptempPosition.Add(new Position(Position.row + 1, Position.col + 1));
            temptempPosition.Add(new Position(Position.row + 1, Position.col - 1));
            temptempPosition.Add(new Position(Position.row - 1, Position.col + 1));
            temptempPosition.Add(new Position(Position.row - 1, Position.col - 1));
            temptempPosition.Add(new Position(Position.row + 1, Position.col));
            temptempPosition.Add(new Position(Position.row - 1, Position.col));
            temptempPosition.Add(new Position(Position.row, Position.col + 1));
            temptempPosition.Add(new Position(Position.row, Position.col - 1));

            foreach (Position element in temptempPosition)
            {
                if (element.IsFieldEmpty())
                {
                    tempPositions.Add(element);
                }
                if (!element.IsFieldEmpty() && element.IsEnemyOnField(this))
                {
                    tempPositions.Add(element);
                }
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
    public class Queen : Piece
    {
        public Queen()
        {

        }

        public Queen(Queen queen)
        {
            this.Position = new Position(queen.Position);
            this.Color = queen.Color;
            this.Icon = queen.Icon;
        }
        public Queen(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2655';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265b';

        }
        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            //Queen = Bishop + Rook
            //Bishop
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col + i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col - i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col + i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col - i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            //Rook
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row, Position.col + i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row, Position.col - i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
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
        public Bishop()
        {

        }

        public Bishop(Bishop bishop)
        {
            this.Position = new Position(bishop.Position);
            this.Color = bishop.Color;
            this.Icon = bishop.Icon;
        }
        public Bishop(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2657';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265d';

        } 
        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col + i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col - i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col + i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col - i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
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
        public Knight()
        {

        }

        public Knight(Knight knight)
        {
            this.Position = new Position(knight.Position);
            this.Color = knight.Color;
            this.Icon = knight.Icon;
        }
        public Knight(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2658';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265e';

        }
        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> temptempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            temptempPositions.Add(new Position(Position.row + 2, Position.col + 1));
            temptempPositions.Add(new Position(Position.row + 1, Position.col + 2));
            temptempPositions.Add(new Position(Position.row + 2, Position.col - 1));
            temptempPositions.Add(new Position(Position.row + 1, Position.col - 2));
            temptempPositions.Add(new Position(Position.row - 2, Position.col - 1));
            temptempPositions.Add(new Position(Position.row - 1, Position.col - 2));
            temptempPositions.Add(new Position(Position.row - 2, Position.col + 1));
            temptempPositions.Add(new Position(Position.row - 1, Position.col + 2));

            foreach (Position element in temptempPositions)
            {
                if (element.IsFieldEmpty())
                {
                    tempPositions.Add(element);
                }

                if (!element.IsFieldEmpty() && element.IsEnemyOnField(this))
                {
                    tempPositions.Add(element);
                }
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
    public class Rook : Piece
    {
        public Rook()
        {

        }

        public Rook(Rook rook)
        {
            this.Position = new Position(rook.Position);
            this.Color = rook.Color;
            this.Icon = rook.Icon;
        }
        public Rook(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2656';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265c';

        }
        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row + i, Position.col));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row - i, Position.col));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row, Position.col + i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
            }
            for (int i = 1; i <= 7; i++)
            {
                tempPositions.Add(new Position(Position.row, Position.col - i));
                if (!tempPositions.LastOrDefault().IsFieldEmpty())
                {
                    if (tempPositions.LastOrDefault().IsEnemyOnField(this)) break;
                    else
                    {
                        tempPositions.Remove(tempPositions.LastOrDefault());
                        break;
                    }
                }
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
        public Pawn()
        {

        }

        public Pawn(Pawn pawn)
        {
            this.Position = new Position(pawn.Position);
            this.Color = pawn.Color;
            this.Icon = pawn.Icon;
        }
        public Pawn(int positionIndex, ColorsEnum color)
        {
            this.Position = Position.GetPositionFromIndex(positionIndex);
            this.Color = color;

            if (this.Color == ColorsEnum.White) this.Icon = '\u2659';
            else if (this.Color == ColorsEnum.Black) this.Icon = '\u265f';

        }
        public override List<Position> PossibleMoves()
        {
            List<Position> tempPositions = new List<Position>();
            List<Position> tempPositionsCapture = new List<Position>();
            List<Position> availablePositions = new List<Position>();

            if (new Position(Position.row - 1, Position.col).IsFieldEmpty())
            {
                tempPositions.Add(new Position(Position.row - 1, Position.col));
                if (new Position(Position.row - 2, Position.col).IsFieldEmpty() && Position.row == 6) tempPositions.Add(new Position(Position.row - 2, Position.col));
            }

            tempPositionsCapture.Add(new Position(Position.row - 1, Position.col - 1));
            tempPositionsCapture.Add(new Position(Position.row - 1, Position.col + 1));

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