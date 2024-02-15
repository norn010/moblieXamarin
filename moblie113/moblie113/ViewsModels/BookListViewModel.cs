using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using moblie113.Models;
using Xamarin.Forms;
using mobile113.Views;
using moblie113.APIs;
using moblie113.Views;

namespace moblie113.ViewsModels
{
    internal class BookListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<BookModel> Book
        {
            get
            {
                return myproducts;
            }
            set
            {
                myproducts = value;
                var args = new PropertyChangedEventArgs(nameof(Book));
                PropertyChanged?.Invoke(this, args);
            }
        }

        ObservableCollection<BookModel> myproducts;
        public Command SelectCommnd { get; }
        public BookModel selectedProduct { get; set; }

        ApiService apiService;

        public BookListViewModel()
        {
            Book = new ObservableCollection<BookModel>();
            apiService = new ApiService();

            GetProduct();

            SelectCommnd = new Command(async () =>
            {
                var BookDetail = new BookDetail
                {
                    BindingContext = selectedProduct
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(BookDetail);
            });
        }

        async void GetProduct()
        {
            Book = await apiService.GetBooks();
        }

        private async void AddBook_Clicked(object sender, EventArgs e)
        {
            var addBookPage = new AddBook();
            await Application.Current.MainPage.Navigation.PushAsync(addBookPage);
        }
    }
}

/*using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using moblie113.Models;

namespace moblie113.ViewsModels
{
    public class BookListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BookModel> Products { get; set; }
        public BookModel SelectedProduct { get; set; }

        public ICommand SelectCommnd { get; set; }

        public BookListViewModel()
        {
            // Initialize the command
            SelectCommnd = new Command(OnItemSelected);

            // Load some sample data (5 books)
            LoadBooks();
        }

        void LoadBooks()
        {
            Products = new ObservableCollection<BookModel>
            {
                new BookModel
                {
                    book_Id = 1,
                    book_Name = "Book 1",
                    author = "Author 1",
                    price = 10.99,
                    image = "book1.jpg",
                    detail = "Details about Book 1",
                    download = "Download link for Book 1",
                    type = "Type of Book 1"
                },
                new BookModel
                {
                    book_Id = 2,
                    book_Name = "Book 2",
                    author = "Author 2",
                    price = 15.99,
                    image = "book2.jpg",
                    detail = "Details about Book 2",
                    download = "Download link for Book 2",
                    type = "Type of Book 2"
                },
                new BookModel
                {
                    book_Id = 3,
                    book_Name = "Book 3",
                    author = "Author 3",
                    price = 12.49,
                    image = "book3.jpg",
                    detail = "Details about Book 3",
                    download = "Download link for Book 3",
                    type = "Type of Book 3"
                },
                new BookModel
                {
                    book_Id = 4,
                    book_Name = "Book 4",
                    author = "Author 4",
                    price = 9.99,
                    image = "book4.jpg",
                    detail = "Details about Book 4",
                    download = "Download link for Book 4",
                    type = "Type of Book 4"
                },
                new BookModel
                {
                    book_Id = 5,
                    book_Name = "Book 5",
                    author = "Author 5",
                    price = 14.99,
                    image = "book5.jpg",
                    detail = "Details about Book 5",
                    download = "Download link for Book 5",
                    type = "Type of Book 5"
                }
            };
        }

        void OnItemSelected()
        {
            // Handle item selection logic here
        }
    }
}*/