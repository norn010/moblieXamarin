using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using moblie113.ViewsModels;
using moblie113.Views;

namespace mobile113.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookList : ContentPage
    {
        public BookList()
        {
            InitializeComponent();
            BindingContext = new BookListViewModel();
        }

        private async void AddBook_Clicked(object sender, EventArgs e)
        {
            var addBookPage = new AddBook();
            await Navigation.PushAsync(addBookPage);
        }
    }
}
