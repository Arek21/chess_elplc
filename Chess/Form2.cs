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

namespace Chess
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static IPAddress GetDefaultGateway()//Odczytanie adresu IP bramy sieciowej
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
            string roomName;
            string myIP = string.Empty;
            string myMAC = string.Empty;
            roomName = AddRoomTextbox.Text;

            //Odczytanie wireless adres IPv4
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {

                    myMAC =  ni.GetPhysicalAddress().ToString();
                    
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            myIP = ip.Address.ToString();

                        }
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine(myIP);
            System.Diagnostics.Debug.WriteLine(myMAC);
            System.Diagnostics.Debug.WriteLine(GetDefaultGateway());

            //10.10.10.240 - IP
            //A4C494E777F0 - MAC
            //10.10.10.1 -  Gateway

            //Sprawdzenie poprawności regexem
            //string pattern = @"[A-Z0-9]"; 
            //Regex rg = new Regex(pattern);
            //MatchCollection matches = rg.Matches(myMAC);
            //System.Diagnostics.Debug.WriteLine("{0} matches found in:  {1}",matches.Count,myMAC);
        }
    }
}
