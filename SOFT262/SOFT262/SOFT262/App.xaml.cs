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
        public List<string> topicList = new List<string>();
        string dbPath => System.IO.Path.Combine(FileSystem.AppDataDirectory, "RevisionCards1.db3");
        public List<RevisionCardSQL> debug;
        public static SQLConnection revisionCards { get; private set; }
        public App()
        {
            //revisionCards = new SQLConnection(dbPath);

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
