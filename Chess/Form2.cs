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

namespace Chess
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string roomName;
            string myIP = string.Empty;
            roomName = AddRoomTextbox.Text;

            //Odczytanie wireless adres IPv4
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            myIP = ip.Address.ToString();

                        }
                    }
                }
            }

            var cs1 = @"Server=tcp:elplcserver.database.windows.net,1433;Initial Catalog=CHESS;Persist Security Info=False;User ID=admindatabase;Password=Verystrongpassword1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string stm = "INSERT INTO Sessions VALUES(" + "'"+ roomName + "'" + "," + "'" + myIP + "'" + ");";

            using var con = new SqlConnection(cs1);
            con.Open();

            using var cmd = new SqlCommand(stm, con);
            cmd.ExecuteScalar();

            con.Close();

            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }
    }
}
