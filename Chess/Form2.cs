using System;
using System.Data;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Linq;
using ServiceReference1;
using System.Collections.Generic;

namespace Chess
{
    public partial class Form2 : Form
    {

        WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());

        public Form2()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            string roomName = roomNameTextBox.Text;
            string playerName = player1TextBox.Text;

            SessionDto sessionDto = new SessionDto();

            if (roomName != null && playerName != null && roomName != "" && playerName != "")
            {
                sessionDto = client.PostSession(roomName, playerName);
                List<BoardDto> board = client.GetStartingBoard().ToList();
                client.SaveGameState(sessionDto, board.ToArray());
                Form4 form4 = new Form4(sessionDto, sessionDto.FirstPlayer);
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private string getIp()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
               .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
               .SelectMany(m => m.GetIPProperties().UnicastAddresses)
               .Where(m => m.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
               .Select(p => p.Address)
               .LastOrDefault()
               .ToString();
        }

        private string getMac()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
            .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            .LastOrDefault()
            .GetPhysicalAddress()
            .ToString();
        }

        private string getRouterIp()
        {
            return NetworkInterface
           .GetAllNetworkInterfaces()
           .Where(n => n.OperationalStatus == OperationalStatus.Up)
           .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
           .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
           .Select(g => g?.Address)
           .Where(a => a != null)
           .LastOrDefault()
           .ToString();
        }

    }
}
