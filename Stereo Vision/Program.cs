using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Stereo_Vision
{
    static class Program
    {
        static Form SplashScreen;
        static Form MainForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Creating of forms
            MainForm = new MainWindow();
            SplashScreen = new OnLoadingForm("2.71");

            //Show Splash Form
            var splashThread = new Thread(new ThreadStart(
                () => Application.Run(SplashScreen)));
            SplashScreen.StartPosition = FormStartPosition.CenterScreen;
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            var reporter = (SplashScreen as OnLoadingForm).GetReporter();
            (MainForm as MainWindow).SetReporter(reporter);

            //Show Main Form
            MainForm.Load += MainForm_LoadCompleted_CloseSplashScreen;
            Application.Run(MainForm);
        }
        private static void MainForm_LoadCompleted_CloseSplashScreen(object sender, EventArgs e)
        {
            if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
                SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
            MainForm.TopMost = true;
            MainForm.Activate();
            MainForm.TopMost = false;
        }
    }
}
