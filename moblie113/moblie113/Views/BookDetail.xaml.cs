using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using moblie113.ViewsModels;
using moblie113.Models;

namespace moblie113.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetail : ContentPage
    {
        public BookDetail(BookModel book)
        {
            InitializeComponent();
            BindingContext = new BookDetailViewModel(book);
        }
    }
}
