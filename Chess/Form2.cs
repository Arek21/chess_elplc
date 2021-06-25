using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace Chess
{
    public partial class Form2 : Form
    {
        private int timHour = 0;
        private int timMin = 0;
        private int timSec = 0;

        public Form2()
        {
            InitializeComponent();

            //Uruchomienie timera
            timer1.Interval = 1;
            timer1.Start();
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer
            timSec++;
            if (timSec > 59)
            {
                timSec = 0;
                timMin++;
            }
            
            if (timMin > 59)
            {
                timMin = 0;
                timHour++;
            }

            if (timHour > 24)
            {
                eventLabel.Text = "You wait too long for opponent";
                timHour = 0;
                timMin = 0;
                timSec = 0;
            }
            periodTimeLabel.Text = timHour + " : " + timMin + " : " + timSec;
        }
    }
}
