using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using moblie113.ViewsModels;
using moblie113.Views;
using moblie113.Models;

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
        private async void DeleteCommand(object sender, EventArgs e)
        {
            var viewModel = (BookListViewModel)BindingContext;
            var book = (sender as Button)?.BindingContext as BookModel;
            if (book != null)
                viewModel.DeleteCommand.Execute(book);
        }
    }
}
