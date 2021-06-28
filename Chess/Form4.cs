using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form4 : Form
    {
        private int? firstButtonId = null;
        private int? secondButtonId = null;

        private string opponentScore = "0"; //Póżniej uzywac lokalnie
        private string userScore = "0";     //Póżniej uzywac lokalnie

        public Form4()
        {
            InitializeComponent();
            string numOfSesions = string.Empty; //Odczytać z chmury dane do wyświetlenia
            string opponentName = string.Empty;
            string userName = string.Empty;

            sessionIdLabel.Text = "Room nr: " + numOfSesions;
            opponentNameLabel.Text = "Opponent name: " + opponentName;
            oppoentScoreLabel.Text = "Opponent score: " + opponentScore;
            userNameLabel.Text = "Your name: " + userName;
            userScoreLabel.Text = "Your score: " + userScore;
        }
        private void boxSelected(object sender, EventArgs e)
        {
            PictureBox button = sender as PictureBox;
            int buttonId = flowLayoutPanel1.Controls.GetChildIndex(button);

            if (firstButtonId == null)
            {
                button.BackColor = Color.MediumVioletRed;
                firstButtonId = buttonId;

            }
            else if (secondButtonId == null)
            {
                button.BackColor = Color.MediumVioletRed;
                secondButtonId = buttonId;

                if (secondButtonId == firstButtonId)
                {
                    clearBoard();
                }
            }
            else if (buttonId != firstButtonId && buttonId != secondButtonId)
            {
                PictureBox prevButton = (PictureBox)flowLayoutPanel1.Controls[(int)secondButtonId];
                prevButton.BackColor = getDefaultBackColor((int)secondButtonId);

                button.BackColor = Color.MediumVioletRed;
                secondButtonId = buttonId;
            }
            else
            {
                clearBoard();
            }
        }
        private Color getDefaultBackColor(int index)
        {
            int row = (int)Math.Floor((double)index / 8);
            int col = index % 8;

            if ((row % 2 == 0 && col % 2 == 0) || (row % 2 != 0 && col % 2 != 0))
            {
                return Color.SaddleBrown;
            }
            else return Color.SandyBrown;
        }
        private void clearBoard()
        {
            PictureBox firstButton = (PictureBox)flowLayoutPanel1.Controls[(int)firstButtonId];
            PictureBox secondButton = (PictureBox)flowLayoutPanel1.Controls[(int)secondButtonId];

            firstButton.BackColor = getDefaultBackColor((int)firstButtonId);
            secondButton.BackColor = getDefaultBackColor((int)secondButtonId);

            firstButtonId = null;
            secondButtonId = null;
        }
    }
}
