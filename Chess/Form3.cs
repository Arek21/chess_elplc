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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            if (!bgw1.IsBusy)
            {
                bgw1.WorkerReportsProgress = true;    //Odblokowanie możliwości informowania o progresie
                bgw1.WorkerSupportsCancellation = true;
                bgw1.RunWorkerAsync();                //Uruchomienie procedury Backgroundworkera
            }
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            if (bgw1.IsBusy)//Zatrzymanie workera
            {
                bgw1.CancelAsync();
            }
            this.Close();//Zamkniecie formularza
        }
        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            //obsługa timera
            BackgroundWorker worker = sender as BackgroundWorker;

            int delay = 100;
            int timHour = 0;
            int timMin = 0;
            int timSec = 0;
            int timMils = 0;

            while (!worker.CancellationPending)//pętla sprawdzająca czy nie zostało wysłane żądanie zakończenia workera
            {
                timMils++;
                if (timMils > 9)
                {
                    timMils = 0;
                    timSec++;
                }
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
                    timHour = 0;
                    timMin = 0;
                    timSec = 0;
                    worker.CancelAsync();
                }
                int[] timTime = { timMils, timSec, timMin, timHour };
                bgw1.ReportProgress(0, timTime);
                System.Threading.Thread.Sleep(delay);
            }
            timHour = 0;
            timMin = 0;
            timSec = 0;
            timMils = 0;
            int[] timTime2 = { timMils, timSec, timMin, timHour };

            bgw1.ReportProgress(0, timTime2);
        }
        private void bgw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //wyswietlenie timera
            int[] tab = e.UserState as int[];
            periodTimeLabel.Text = tab[3] + " : " + tab[2] + " : " + tab[1] + " : " + tab[0];
        }
    }
}
