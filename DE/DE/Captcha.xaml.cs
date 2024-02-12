using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace DE
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
            makeCaptcha();
        }
        private void completeCaptcha_Click(object sender, RoutedEventArgs e)
        {
            string captcha = "";
            captcha = captchaL1.Content.ToString() + captchaL2.Content.ToString() + captchaL3.Content.ToString() + captchaL4.Content.ToString();
            if (captchaTB.Text.ToString().ToLower() == captcha.ToLower())
            {
                MainWindow w1 = new MainWindow();
                w1.Show();
                this.Close();
            }
            else
            {
                int timer = 10;
                MessageBox.Show("Неверная капча, повторите попытку через 10 секунд", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                Thread.Sleep(300);
                for (int i = 0; i < 10; i++)
                {
                    makeCaptcha();
                    timerL.Content = timer.ToString();
                    timer--;

                }
            }

        }

        private void makeCaptcha()
        {
            string[] captchaSample = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            Random rnd = new Random();
            captchaL1.Content = captchaSample[rnd.Next(captchaSample.Length)];
            captchaL2.Content = captchaSample[rnd.Next(captchaSample.Length)];
            captchaL3.Content = captchaSample[rnd.Next(captchaSample.Length)];
            captchaL4.Content = captchaSample[rnd.Next(captchaSample.Length)];

            captchaL1.Margin = new Thickness(0, rnd.Next(-30, 30), 150, 0);
            captchaL2.Margin = new Thickness(0, rnd.Next(-30, 30), 50, 0);
            captchaL3.Margin = new Thickness(0, rnd.Next(-30, 30), -50, 0);
            captchaL4.Margin = new Thickness(0, rnd.Next(-30, 30), -150, 0);

            captchaL1.RenderTransform = new RotateTransform(rnd.Next(-30, 30));
            captchaL2.RenderTransform = new RotateTransform(rnd.Next(-30, 30));
            captchaL3.RenderTransform = new RotateTransform(rnd.Next(-30, 30));
            captchaL4.RenderTransform = new RotateTransform(rnd.Next(-30, 30));
        }

        private void refreshCaptcha_Click(object sender, RoutedEventArgs e)
        {
            makeCaptcha();
        }
    }
}
