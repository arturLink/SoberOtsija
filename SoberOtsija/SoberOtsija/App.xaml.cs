using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SoberOtsija.Models;
using System.IO;

namespace SoberOtsija
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "sobrad.db";
        public static SoberRepository database;
        public static SoberRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new SoberRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
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
