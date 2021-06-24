using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cs = @"Server=tcp:elplcserver.database.windows.net,1433;Initial Catalog=CHESS;Persist Security Info=False;User ID=admindatabase;Password=Verystrongpassword1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var stm1 = "INSERT INTO test VALUES('Jan','Kowalski');";
            var stm2 = "SELECT name FROM test ORDER BY id DESC;";
            var stm3 = "SELECT surname FROM test ORDER BY id DESC;";

            using var con = new SqlConnection(cs);
            con.Open();

            using var cmd1 = new SqlCommand(stm1, con);
            cmd1.ExecuteScalar();

            using var cmd2 = new SqlCommand(stm2, con);
            string response2 = cmd2.ExecuteScalar().ToString();

            using var cmd3 = new SqlCommand(stm3, con);
            string response3 = cmd3.ExecuteScalar().ToString();

            string response = response2 + response3;

            //Console.WriteLine(response2);
            //System.Diagnostics.Debug.WriteLine(response2);
            label1.Text = response;
            
        }
    }
}
