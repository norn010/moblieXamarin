using mobile113.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace moblie113
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BookList());
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
