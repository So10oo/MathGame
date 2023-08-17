using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Логика взаимодействия для SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork +=worker_Dowork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void worker_Dowork(object? sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(160);
            }
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            //txt.Text = "вцу";
            switch (progressBar.Value)
            {
                case 0:
                    txt.Text = "Загружаем вирусы...";
                    break;
                    case 25:
                    txt.Text = "Удаляем системные файлы...";
                    break;
                case 40:
                    txt.Text = "Скачиваем пароли...";
                    break;
                case 70:
                    txt.Text = "Загружаем секретные материалы...";
                    break;
                case 88:
                    txt.Text = "Сообщаем об этом полиции........";
                    break;
                case 100:
                    MainWindow mainWindow = new();
                    Close();
                    mainWindow.ShowDialog();
                    break;
                default:
                    break;
            }
            //if (progressBar.Value==100)
            //{
            //    MainWindow mainWindow = new();
            //    Close();
            //    mainWindow.ShowDialog();
            //}
        }

        private void txt_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var tb = (TextBlock)sender;
            var l = 375;//Canvas.GetLeft(tb);
            var t = 255;//Canvas.GetTop(tb);
            var w = e.NewSize.Width;
            var h = e.NewSize.Height;

            Canvas.SetLeft(tb, l - w / 2.0);
            Canvas.SetTop(tb, t - h / 2.0);
        }
    }
}
