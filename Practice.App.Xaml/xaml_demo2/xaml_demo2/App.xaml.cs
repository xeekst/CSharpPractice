using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xaml_demo2.Services;
using xaml_demo2.Views;

namespace xaml_demo2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
