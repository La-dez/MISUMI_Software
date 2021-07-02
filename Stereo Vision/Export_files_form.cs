using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Stereo_Vision
{
    public partial class Export_files_form : Form
    {
        List<string> mass_from;
        List<string> mass_to;
        int ticks = 0;
        int lastfile = -1;

        public Export_files_form(List<string> pMass_from, List<string> pMass_to)
        {
            mass_from = pMass_from;
            mass_to = pMass_to;
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            
        }

        private void Export_files_form_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            StartAsync();
            
        }

        private void B_Abort_Click(object sender, EventArgs e)
        {
           if(backgroundWorker1.IsBusy) CancelAsync();
        }
        private void StartAsync()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void CancelAsync()
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                this.Text = "Отмена...";
                System.Threading.Thread.Sleep(1000);
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool wasError = false;
            for (int i = 0; i < mass_from.Count(); i++)
            {
                try
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        if(File.Exists(mass_to[i]))
                        {
                            try { File.Delete(mass_to[i]); }
                            catch { }
                        }
                        File.Copy(mass_from[i], mass_to[i]);
                        lastfile = i;
                        worker.ReportProgress((int)((((float)i+1) / (float)(mass_from.Count())) * 100));
                    }                   
                }
                catch
                {
                    //Ignore, try next...
                    wasError = true;
                }
            }
            if (wasError) throw new Exception("Во время экспорта произошла ошибка.");
        }
        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.Text = "Экспорт отменен.";
            }
            else if (e.Error != null)
            {
                this.Text = "Экспорт завершен с ошибками.";
            }
            else
            {
               this.Text = "Экспорт завершен!";
            }     
            Start_Window_Close_Timer();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            L_CurrentProgress.Text = (lastfile + 1).ToString() + " из " + mass_from.Count;
            ProgB_Export.Value = e.ProgressPercentage;
        }

        private void Start_Window_Close_Timer()
        {
            Timer_for_Closing.Enabled = true;
        }

        private void Timer_for_Closing_Tick(object sender, EventArgs e)
        {
            ticks++;
            if(ticks==10) this.Close();
        }

        private void Export_files_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (backgroundWorker1.IsBusy) CancelAsync();
        }
    }
}
