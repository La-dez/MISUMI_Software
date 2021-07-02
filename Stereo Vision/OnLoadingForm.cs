using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stereo_Vision
{
    public partial class OnLoadingForm : Form
    {
        bool ShowBorder = true;
        Bitmap LoadBMP = new Bitmap("Resources\\OnLoad.bmp");
        public OnLoadingForm(string version,bool p_ShowBorder = false)
        {
            // ref Action<int, string> pReportProgress
            InitializeComponent();     
            ShowBorder = p_ShowBorder;
            PB_LoadingPicture.Image = LoadBMP;

            L_DevInfo.Text = "HD Vision v" + version;
            L_DevInfo.Text += "\nРазработчики:";
            L_DevInfo.Text += "\nНТЦ УП РАН";
            L_DevInfo.Text += "\nНПП СиМТ";
            L_DevInfo.Text += "\nНИУ МЭИ";

            //BGW_onLoadWindowInit.RunWorkerAsync();
        }
        private void ReportProgress(int Progress, string Message)
        {
            if (PrB_LoadingProgress.InvokeRequired)
            {
                PrB_LoadingProgress.BeginInvoke(new Action(() => { PrB_LoadingProgress.Value = (Progress > 100 ? 100 : (Progress < 0 ? 0 : Progress)); }));
            }
            else
            {
                PrB_LoadingProgress.Value = (Progress > 100 ? 100 : (Progress < 0 ? 0 : Progress));
            }
            if (L_LoadingProgress.InvokeRequired)
            {
                L_LoadingProgress.BeginInvoke(new Action(() => { L_LoadingProgress.Text = Message; }));
            }
            else
            {
                L_LoadingProgress.Text = Message;
            }
           
        }
        public Action<int,string> GetReporter()
        {
            Action<int, string> RP = new Action<int, string>((int pr, string mes) => ReportProgress(pr, mes));
            return RP;
        }
        private void OnLoadingForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = ShowBorder ? FormBorderStyle.Sizable : FormBorderStyle.None;
        }

        private void BGW_onLoadWindowInit_DoWork(object sender, DoWorkEventArgs e)
        {
        }
    }
}
