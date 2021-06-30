using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using ServiceReference1;

namespace Chess
{
    public partial class Form2 : Form
    {

        WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());
        public Form2()
        {
            InitializeComponent();
        }
        public static IPAddress GetDefaultGateway() //Odczytanie adresu IP bramy sieciowej
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .FirstOrDefault();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            string roomName = roomNameTextBox.Text;
            string player1 = player1TextBox.Text;

            string routerIp = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .LastOrDefault()
                .ToString();

            string macAddress1 = NetworkInterface.GetAllNetworkInterfaces()
            .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            .LastOrDefault()
            .GetPhysicalAddress()
            .ToString();

            string ip1 = NetworkInterface.GetAllNetworkInterfaces()
               .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
               .SelectMany(m => m.GetIPProperties().UnicastAddresses)
               .Where(m => m.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
               .Select(p => p.Address)
               .LastOrDefault()
               .ToString();

            ////Odczytanie wireless adres IPv4
            //foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            //    {
            //        myMAC = ni.GetPhysicalAddress().ToString();

            //        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
            //        {
            //            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //            {
            //                myIP = ip.Address.ToString();
            //            }
            //        }
            //    }
            //}


            if(roomName != null && ip1 != null && macAddress1 != null)
            {
                client.PostSession(roomName, routerIp, player1, ip1, macAddress1);
            }

            Form4 form4 = new Form4();
            form4.Show();
            this.Close();

            //10.10.10.240 - IP
            //A4C494E777F0 - MAC
            //10.10.10.1 -  Gateway

            //Sprawdzenie poprawności regexem
            //string pattern = @"[A-Z0-9]"; 
            //Regex rg = new Regex(pattern);
            //MatchCollection matches = rg.Matches(myMAC);
            //System.Diagnostics.Debug.WriteLine("{0} matches found in:  {1}",matches.Count,myMAC);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
