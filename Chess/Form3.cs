using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form3 : Form
    {
        private string roomName;
        private string player2;
        public Form3(string roomName)
        {
            InitializeComponent();
            this.roomName = roomName;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            player2 = player2TextBox.Text;
            Form4 form4 = new Form4(roomName, player2, false);
            form4.Show();
            this.Hide();
        }
    }
}
