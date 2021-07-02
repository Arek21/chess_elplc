using System;
using System.Data;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Linq;
using ServiceReference1;

namespace Chess
{
    public partial class Form2 : Form
    {

        WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());
        string routerIp;
        string macAddress1;
        string ip1;
        public Form2()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            string roomName = roomNameTextBox.Text;
            string player1 = player1TextBox.Text;


            if (roomName != null && ip1 != null && macAddress1 != null)
            {
                client.PostSession(roomName, player1);
            }

            Form4 form4 = new Form4(roomName, player1, true);
            form4.Show();
            this.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            routerIp = getRouterIp();
            macAddress1 = getMac();
            ip1 = getIp();

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
