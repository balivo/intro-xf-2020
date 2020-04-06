﻿using BuscaCep.Mobile.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuscaCep.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //MainPage = new BuscaCepPage();
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
