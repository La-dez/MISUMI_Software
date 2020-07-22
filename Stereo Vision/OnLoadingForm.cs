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
        public OnLoadingForm(bool p_ShowBorder = false)
        {

            ShowBorder = p_ShowBorder;
            InitializeComponent();
            PB_LoadingPicture.Image = LoadBMP;
            //BGW_onLoadWindowInit.RunWorkerAsync();
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
