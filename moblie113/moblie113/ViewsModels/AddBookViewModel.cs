using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using moblie113.APIs;
using moblie113.Models;

namespace moblie113.ViewsModels
{
    public class AddBookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                }
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Author)));
                }
            }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                }
            }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                }
            }
        }

        private string _download;
        public string Download
        {
            get { return _download; }
            set
            {
                if (_download != value)
                {
                    _download = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Download)));
                }
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
                }
            }
        }

        public Command AddBookCommand { get; }

        ApiService apiService;

        public AddBookViewModel()
        {
            apiService = new ApiService();

            AddBookCommand = new Command(async () =>
            {
                await AddBook();
            });
        }

        async Task AddBook()
        {
            try
            {
                var newBook = new BookModel
                {
                    book_Name = Title,
                    author = Author,
                    image = Image,
                    detail = Description,
                    price = Price,
                    download = Download,
                    type = Type
                };

                var success = await apiService.AddBook(newBook);

                if (success)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Book added successfully", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to add book", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
            }
        }
    }
}
