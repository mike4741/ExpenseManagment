using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetApp.Models;
using Xamarin.Forms;

namespace BudgetApp
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("Test.db3");

        public App()
        {
            InitializeComponent();

            MainPage = new BudgetApp.Views.HomePage()
            {
               // Text = dbPath,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
