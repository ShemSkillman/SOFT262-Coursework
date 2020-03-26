using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SOFT262.Model;

namespace SOFT262
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainModel model = new MainModel();

            MainPage = new TopLevelPage(model);
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
