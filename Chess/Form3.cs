using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ServiceReference1;

namespace Chess
{
    public partial class Form3 : Form
    {
        SessionDto session;
        WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());

        public Form3(SessionDto sessionDto)
        {
            InitializeComponent();
            this.session = sessionDto;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string playerName = player2TextBox.Text;

            if (session.FirstPlayer != null && session.SecondPlayer == null && session.FirstPlayer != playerName)
            {
                SessionDto updatedSession = client.UpdateSession(session.Id, playerName);
                Form4 form4 = new Form4(updatedSession, updatedSession.SecondPlayer);
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
            else if (session.FirstPlayer == playerName || session.SecondPlayer == playerName)
            {
                Form4 form4 = new Form4(session, playerName);
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }

        }
    }
}
