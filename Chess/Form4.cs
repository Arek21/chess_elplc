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
        private int? firstSelectedButtonId = null;
        private int? secondSelectedButtonId = null;

        //private string opponentScore = "0"; //Póżniej uzywac lokalnie
        //private string userScore = "0";     //Póżniej uzywac lokalnie

        private string roomName;
        private string playerName;
        private bool onStartTurn;
        private MqttClient mqttClient = null;
        private string mqqtConnectionString;

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

            Game.initGame(onStartTurn);

            ClearBoardBackgrounds();
            RefreshBoardIcons();


            Task.Run(() =>
            {
                mqqtConnectionString = "ELPLC/" + roomName;
                mqttClient = new MqttClient("broker.hivemq.com");
                mqttClient.MqttMsgPublishReceived += PublishReceived;
                mqttClient.Subscribe(new string[] { mqqtConnectionString + "/Chat" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Subscribe(new string[] { mqqtConnectionString + "/Game" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect(playerName);
            });

        }
        private void PublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e.Topic.Equals(mqqtConnectString + "/Chat"))
            {
                var message = Encoding.UTF8.GetString(e.Message);

                form.GetChatListBox.Invoke((MethodInvoker)(() => form.GetChatListBox.Items.Add(message)));
            }
            else if (e.Topic.Equals(mqqtConnectString + "/Game"))
            {

            }
        }



        private void BoxSelected(object sender, EventArgs e)
        {
            PictureBox selectedButton = sender as PictureBox;
            int selectedButtonId = flowLayoutPanel1.Controls.GetChildIndex(selectedButton);

            System.Diagnostics.Debug.WriteLine(selectedButtonId);

            if (Game.IsMyTurn)
            {
                //flowLayoutPanel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                if (firstSelectedButtonId == null &&
                    Game.IsMyPiece(selectedButtonId))   //  SELECT PIECE TO MOVE
                {
                    firstSelectedButtonId = selectedButtonId;
                    HighlightSelectedButton(selectedButton);
                    HighlightPossibleMoves(Game.GetPossibleMoves(selectedButtonId));
                }

                else if (firstSelectedButtonId != null)
                {
                    if (Game.IsFieldEmpty(selectedButtonId) &&
                        Game.GetPossibleMoves((int)firstSelectedButtonId).Contains(selectedButtonId))   //  MOVE PIECE
                    {
                        secondSelectedButtonId = selectedButtonId;
                        Game.Move((int)firstSelectedButtonId, (int)secondSelectedButtonId);

                        ClearBoardBackgrounds();
                        firstSelectedButtonId = null;
                        secondSelectedButtonId = null;

                    }

                    else if (Game.IsMyPiece(selectedButtonId) &&
                        selectedButtonId != firstSelectedButtonId) //   CHANGE SELECTED PIECE
                    {
                        firstSelectedButtonId = selectedButtonId;
                        ClearBoardBackgrounds();
                        HighlightSelectedButton(selectedButton);
                        HighlightPossibleMoves(Game.GetPossibleMoves(selectedButtonId));
                    }

                    else if (Game.IsMyOpontentsPiece(selectedButtonId) &&
                        Game.GetPossibleMoves((int)firstSelectedButtonId).Contains(selectedButtonId)) //    CAPTURE PIECE
                    {
                        secondSelectedButtonId = selectedButtonId;
                        Game.Capture((int)firstSelectedButtonId, (int)secondSelectedButtonId);

                        ClearBoardBackgrounds();
                        firstSelectedButtonId = null;
                        secondSelectedButtonId = null;
                    }

                    else if (selectedButtonId == firstSelectedButtonId) // CLEAR PIECE SELECTION
                    {
                        firstSelectedButtonId = null;
                        ClearBoardBackgrounds();

                    }
                }

                RefreshBoardIcons();
            }
        }
        private void SendChatButton_Click(object sender, EventArgs e)
        {
            if (sendChatTextbox.Text.Length != 0)
            {
                Task.Run(() =>
                {
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        mqttClient.Publish(mqqtConnectionString + "/Chat", Encoding.UTF8.GetBytes(playerName + ": " + sendChatTextbox.Text));
                    }
                }); sendChatTextbox.Text = string.Empty;
            }

        }






        private Color GetDefaultBackColor(int index)
        {
            int row = (int)Math.Floor((double)index / 8);
            int col = index % 8;

            if ((row % 2 == 0 && col % 2 == 0) || (row % 2 != 0 && col % 2 != 0))
            {
                return System.Drawing.Color.SandyBrown;
            }
            else return System.Drawing.Color.SaddleBrown;
        }
        private void HighlightPossibleMoves(List<int> possibleMoves)
        {
            foreach (int possibleMove in possibleMoves)
            {
                PictureBox btn = (PictureBox)flowLayoutPanel1.Controls[possibleMove];
                btn.BackColor = Color.PaleVioletRed;
            }
        }
        private void HighlightSelectedButton(PictureBox selectedButton)
        {
            selectedButton.BackColor = Color.MediumVioletRed;
        }
        private void ClearBoardBackgrounds()
        {
            foreach (PictureBox pb in flowLayoutPanel1.Controls)
            {
                pb.BackColor = GetDefaultBackColor(flowLayoutPanel1.Controls.IndexOf(pb));
                pb.Invalidate();
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
        private void RefreshBoardIcons()
        {
            CreateCanvasOnPictureBoxes();

            foreach (Piece piece in Game.PiecesOnBoard)
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





        public ListBox GetChatListBox
        {
            get { return chatListBox; }
        }
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        public string PlayerName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        public bool OnStartTurn
        {
            get { return onStartTurn; }
            set { onStartTurn = value; }
        }
    }
}
