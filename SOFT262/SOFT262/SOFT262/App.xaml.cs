using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SOFT262.Model;
using SQLite;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace SOFT262
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TopLevelPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
