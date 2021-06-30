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
        private string mqqtConnectString;
        private int? firstButtonId = null;
        private int? secondButtonId = null;

        private string opponentScore = "0"; //Póżniej uzywac lokalnie
        private string userScore = "0";     //Póżniej uzywac lokalnie

        private string roomName;
        private string playerName;

        public Form4(string roomName, string playerName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.playerName = playerName;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            string numOfSesions = string.Empty;
            string opponentName = string.Empty;
            string userName = string.Empty;

            sessionIdLabel.Text = "Room nr: " + numOfSesions;
            opponentNameLabel.Text = "Opponent name: " + opponentName;
            oppoentScoreLabel.Text = "Opponent score: " + opponentScore;
            userNameLabel.Text = "Your name: " + userName;
            userScoreLabel.Text = "Your score: " + userScore;

            // <MQTT>

            mqqtConnectString = "ELPLC/" + roomName;
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.hivemq.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                mqttClient.Subscribe(new string[] { mqqtConnectString + "/Chat" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Subscribe(new string[] { mqqtConnectString + "/Game" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect(playerName);
            });
            // </MQTT>
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


        private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            if(e.Topic.Equals(mqqtConnectString + "/Chat"))
            {
                var message = Encoding.UTF8.GetString(e.Message);
                chatListBox.Invoke((MethodInvoker)(() => chatListBox.Items.Add(message)));
            }         
        }

        private void sendChatButton_Click(object sender, EventArgs e)
        {
            if(sendChatTextbox.Text.Length != 0)
            {
                Task.Run(() =>
                {
                    if (mqttClient != null && mqttClient.IsConnected)
                    {
                        mqttClient.Publish(mqqtConnectString + "/Chat", Encoding.UTF8.GetBytes(playerName + ": " + sendChatTextbox.Text));
                    }
                });
            }
   
        }
    }
}
