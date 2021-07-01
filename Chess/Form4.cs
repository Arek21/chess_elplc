using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Chess
{
    public partial class Form4 : Form
    {

        MqttClient mqttClient = null;
        Game game = null;

        private string mqqtConnectString;
        private int? selectedButtonId = null;

        //private string opponentScore = "0"; //Póżniej uzywac lokalnie
        //private string userScore = "0";     //Póżniej uzywac lokalnie

        private string roomName;
        private string playerName;
        private bool onStartTurn;

        public Form4(string roomName, string playerName, bool onStartTurn)
        {
            InitializeComponent();

            this.roomName = roomName;
            this.playerName = playerName;
            this.onStartTurn = onStartTurn;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            //string numOfSesions = string.Empty;
            //string opponentName = string.Empty;
            //string userName = string.Empty;

            //sessionIdLabel.Text = "Room nr: " + numOfSesions;
            //opponentNameLabel.Text = "Opponent name: " + opponentName;
            //oppoentScoreLabel.Text = "Opponent score: " + opponentScore;
            //userNameLabel.Text = "Your name: " + userName;
            //userScoreLabel.Text = "Your score: " + userScore;

            mqqtConnectString = "ELPLC/" + roomName;
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.hivemq.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                mqttClient.Subscribe(new string[] { mqqtConnectString + "/Chat" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Subscribe(new string[] { mqqtConnectString + "/Game" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect(playerName);
            });

            game = new Game(onStartTurn);
            CreateCanvasOnPictureBoxes();
            RefreshBoard();
        }
        private void BoxSelected(object sender, EventArgs e)
        {

            if (game.OnTurn.Equals(true))
            {
                PictureBox button = sender as PictureBox;
                int buttonId = flowLayoutPanel1.Controls.GetChildIndex(button);
                Position position = Position.GetPositionFromIndex(buttonId);
                List<Piece> pieces = Board.Pieces;

                if (selectedButtonId == null &&
                    !position.IsFieldEmpty() &&
                    pieces.Find(p => p.Position.Equals(position)).Color.Equals(game.PlayerColor))
                {
                    button.BackColor = System.Drawing.Color.MediumVioletRed;
                    selectedButtonId = buttonId;

                    Piece piece = pieces.Find(p => p.Position.Equals(position));
                    List<Position> possibleMoves = piece.PossibleMoves();

                    foreach (Position possibleMove in possibleMoves)
                    {
                        PictureBox btn = (PictureBox)flowLayoutPanel1.Controls[Position.GetIndexFromPosition(possibleMove)];
                        btn.BackColor = Color.PaleVioletRed;
                    }
                }
                else if (selectedButtonId != null)
                {
                    if (position.IsFieldEmpty())
                    {
                        Piece piece = pieces.Find(p => p.Position.Equals(Position.GetPositionFromIndex((int)selectedButtonId)));
                        piece.Position = position;
                        ClearBoardBackground();
                        selectedButtonId = null;
                        
                        // porusz sie
                    }
                    else if (pieces.Find(p => p.Position.Equals(position)).Color.Equals(game.PlayerColor))
                    {
                        //zmien figure
                    }
                    else
                    {
                        // zbij
                    }
                }


            }

            RefreshBoard();


            //    else if (secondButtonId == null)
            //    {
            //        button.BackColor = System.Drawing.Color.MediumVioletRed;
            //        secondButtonId = buttonId;

            //        if (secondButtonId == firstButtonId)
            //        {
            //            ClearBoardBackground();
            //        }
            //    }
            //    else if (buttonId != firstButtonId && buttonId != secondButtonId)
            //    {
            //        PictureBox prevButton = (PictureBox)flowLayoutPanel1.Controls[(int)secondButtonId];
            //        prevButton.BackColor = GetDefaultBackColor((int)secondButtonId);

            //        button.BackColor = System.Drawing.Color.MediumVioletRed;
            //        secondButtonId = buttonId;
            //    }
            //    else
            //    {
            //        ClearBoardBackground();
            //    }
            //}
            // </koniee> 
        }
        private System.Drawing.Color GetDefaultBackColor(int index)
        {
            int row = (int)Math.Floor((double)index / 8);
            int col = index % 8;

            if ((row % 2 == 0 && col % 2 == 0) || (row % 2 != 0 && col % 2 != 0))
            {
                return System.Drawing.Color.SandyBrown;
            }
            else return System.Drawing.Color.SaddleBrown;
        }
        private void ClearBoardBackground()
        {
           foreach(PictureBox pb in flowLayoutPanel1.Controls)
            {
                pb.BackColor = GetDefaultBackColor(flowLayoutPanel1.Controls.IndexOf(pb));
            }
        }
        private void CreateCanvasOnPictureBoxes()
        {
            foreach (PictureBox pictureBox in flowLayoutPanel1.Controls)
            {
                Bitmap bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox1.ClientSize.Height);
                pictureBox.Image = bmp;
            }
        }
        private void RefreshBoard()
        {
            CreateCanvasOnPictureBoxes();

            foreach (Piece piece in Board.Pieces)
            {
                PictureBox pictureBox = (PictureBox)flowLayoutPanel1.Controls[Position.GetIndexFromPosition(piece.Position)];

                Font font = new Font("FreeSerif", 24f);
                using (Graphics G = Graphics.FromImage(pictureBox.Image))
                {
                    G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                    G.DrawString(piece.Icon.ToString(), font, Brushes.Black, 5f, 10f);
                }

                pictureBox.Invalidate();
            }
        }
        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e.Topic.Equals(mqqtConnectString + "/Chat"))
            {
                var message = Encoding.UTF8.GetString(e.Message);
                chatListBox.Invoke((MethodInvoker)(() => chatListBox.Items.Add(message)));
            }
            else if (e.Topic.Equals(mqqtConnectString + "/Game"))
            {

            }
        }
        private void SendChatButton_Click(object sender, EventArgs e)
        {
            if (sendChatTextbox.Text.Length != 0)
            {
                string message = sendChatTextbox.Text;

                Task.Run(() =>
                {
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        mqttClient.Publish(mqqtConnectString + "/Chat", Encoding.UTF8.GetBytes(playerName + ": " + message));
                    }
                });

                sendChatTextbox.Text = string.Empty;
            }

        }

    }
}
