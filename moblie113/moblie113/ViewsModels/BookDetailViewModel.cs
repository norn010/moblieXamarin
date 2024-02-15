using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using moblie113.Models;
using moblie113.APIs;

namespace moblie113.ViewsModels
{
    public class BookDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BookModel Book { get; set; }
        public Command SaveCommand { get; }

        ApiService apiService;

       
        public BookDetailViewModel(BookModel book)
        {
            Book = book;
            apiService = new ApiService();

            SaveCommand = new Command(async () =>
            {
                await UpdateBook();
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        async Task UpdateBook()
        {
            try
            {
                var response = await apiService.UpdateBook(Book);
                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("UpdateBook", "UPDATED!!!", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating book: {ex.Message}");
            }
        }
    }
}
