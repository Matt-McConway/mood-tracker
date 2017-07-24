﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MoodTracker
{
    public partial class App : Application
    {
        public static IList<string> PastMoods { get; set; }

        public App()
        {
            InitializeComponent();
            PastMoods = new List<string>();
            MainPage = new MoodTracker.MainPage(); // Starting page.
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
