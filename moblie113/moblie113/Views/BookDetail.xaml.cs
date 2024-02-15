using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using moblie113.ViewsModels;

namespace moblie113.Views
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