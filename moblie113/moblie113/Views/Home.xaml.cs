using mobile113.Views;
using System;
using Xamarin.Forms;

namespace moblie113.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void OnExploreBooksClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookList());
        }
    }
}