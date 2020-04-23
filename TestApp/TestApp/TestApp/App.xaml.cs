using System;
using TestApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    public partial class App : Application
    {
        internal static NavigationPage Navigator;
        internal static MasterPage Master;

        public App()
        {
            InitializeComponent();
            Current.MainPage = new MasterPage();
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
