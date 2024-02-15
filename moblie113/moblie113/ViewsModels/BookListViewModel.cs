using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using moblie113.Models;
using Xamarin.Forms;
using moblie113.APIs;
using moblie113.Views;

namespace moblie113.ViewsModels
{
    internal class BookListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BookModel> Book
        {
            get { return myproducts; }
            set
            {
                myproducts = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        private ObservableCollection<BookModel> myproducts;
        public Command SelectCommnd { get; }
        public Command DeleteCommand { get; }


        private ApiService apiService;

        public BookListViewModel()
        {
            Book = new ObservableCollection<BookModel>();
            apiService = new ApiService();

            GetBooks();

            SelectCommnd = new Command(async () =>
            {
                if (selectedProduct != null)
                {
                    var BookDetail = new BookDetail(selectedProduct)
                    {
                        BindingContext = new BookDetailViewModel(selectedProduct)
                    };
                    await Application.Current.MainPage.Navigation.PushModalAsync(BookDetail);
                }
            });

            DeleteCommand = new Command(async () =>
            {
                if (selectedProduct != null)
                {
                    var confirmDelete = await Application.Current.MainPage.DisplayAlert("Confirm Delete", $"Are you sure you want to delete {selectedProduct.book_Name}?", "Yes", "No");
                    if (confirmDelete)
                    {
                        await DeleteBook(selectedProduct);
                    }
                }
            });
        }

        private async Task DeleteBook(BookModel book)
        {
            try
            {
                bool isSuccess = await apiService.DeleteBook(book.book_Id);
                if (isSuccess)
                {
                    Book.Remove(book);
                    selectedProduct = null;
                    OnPropertyChanged(nameof(Book));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete book", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        public async void GetBooks()
        {
            Book = await apiService.GetBooks();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BookModel selectedProduct { get; set; }
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