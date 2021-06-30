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
using ServiceReference1;

namespace Chess
{
    public partial class Form1 : Form
    {
        List<SessionDto> sessionList = new List<SessionDto>();
        BindingSource bindingSource = new BindingSource();
        WebServiceSoapClient client = new WebServiceSoapClient(new WebServiceSoapClient.EndpointConfiguration());

        public Form1()
        {
            InitializeComponent();
        }

        private void AddSessionButton_Click(object sender, EventArgs e)
        { 
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sessionList = client.GetSessions().ToList();
            bindingSource.DataSource = sessionList;
            dataGridView1.DataSource = bindingSource;
        }
    }
}
