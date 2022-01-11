using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProfessionalLesson14Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 0;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            textBox.Text += await Task<string>.Run(() => $"Data were obtained {Environment.NewLine}");
            textBox.ScrollToEnd();
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            stopButton.IsEnabled = false;
            startButton.IsEnabled = false;
            label.Content = "Is connecting to Database...";

            while (progressBar.Value < 100)
                progressBar.Value = await ProgressBarMethod(50);

            label.Content = "";
            textBox.Text += $"Connection was established {Environment.NewLine}";
            textBox.ScrollToEnd();
            x = 0;
            progressBar.Value = x;
            timer.Start();
            stopButton.IsEnabled = true;
        }

        private async void stopButton_Click(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            stopButton.IsEnabled = false;
            timer.Stop();
            label.Content = "Database is disconnecting...";

            while (progressBar.Value < 100)
                progressBar.Value = await ProgressBarMethod(20);

            label.Content = "";
            textBox.Text += await Task<string>.Run(() => $"Connection was closed {Environment.NewLine}");
            textBox.ScrollToEnd();
            x = 0;
            progressBar.Value = x;
            startButton.IsEnabled = true;
        }

        async Task<double> ProgressBarMethod(int mil)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(mil);
                return x++;
            });
        }
    }
}
