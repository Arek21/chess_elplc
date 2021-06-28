using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

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
    public class Piece
    {
        public Position position;
        public bool colour;

    }
    interface IPiece
    {
        public void Move();
        public void ActualPosition();
    }
    public class King : Piece, IPiece
    {
        public King()
        {
            this.position = new Position(2, 2);
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
    }
    public class Rock : IPiece
    {
        private bool colour;
        private bool isCaptured;
        public void ActualPosition()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
    public class Pawn : IPiece
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
    }
}
