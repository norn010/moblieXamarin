using moblie113.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace mobile113.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetail : ContentPage
    {
        public BookDetail()
        {
            InitializeComponent();
            BindingContext = new BookDetailViewModel();

        }

        
    }
}