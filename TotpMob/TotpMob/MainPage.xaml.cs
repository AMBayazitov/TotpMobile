using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TOTP_Framework1;
using TOTP_Framework1.Algorithms;
using Xamarin.Forms;

namespace TotpMob
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //var timer = new Timer() { AutoReset = true, Enabled = true, Interval = 5000 };
            //timer.Elapsed += Generate;
            //timer.Start();
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                Generate();
                return true;
            });

        }

        public void Generate()
        {
            var generator = new OtpGenerator("ambayazitov", 30, 10, 6, new HmacSha256());
            PasswordLabel.Text = generator.GenerateCode();
        }
    }
}
