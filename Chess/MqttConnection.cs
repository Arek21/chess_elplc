using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace Chess
{
    class MqttConnection
    {
        private MqttClient mqttClient = null;
        private Form4 form;

        private string playerName;
        private string roomName;
        private string mqqtConnectString = null;

        public MqttConnection(Form4 form4)
        {
            this.form = form4;
            this.playerName = form.PlayerName;
            this.roomName = form.RoomName;
            this.mqqtConnectString = "ELPLC/" + roomName;
        }

        public void Connect()
        {
            mqttClient = new MqttClient("broker.hivemq.com");

            Task.Run(() =>
            {
                mqttClient.MqttMsgPublishReceived += PublishReceived;
                mqttClient.Subscribe(new string[] { mqqtConnectString + "/Chat" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Subscribe(new string[] { mqqtConnectString + "/Game" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect(playerName);
            });
        }
        public void SendChatMesseage(string message)
        {
            Task.Run(() =>
            {
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    mqttClient.Publish(mqqtConnectString + "/Chat", Encoding.UTF8.GetBytes(playerName + ": " + message));
                }
            });
        }      
        public void SendGameProgress(Game game)
        {
            throw new NotImplementedException();
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

    }
}
