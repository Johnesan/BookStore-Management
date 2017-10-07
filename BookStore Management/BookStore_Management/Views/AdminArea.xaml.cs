using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminArea : ContentPage
    {
        public AdminArea()
        {
            InitializeComponent();
        }

        private async void BooksListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksList());
        }

        private async void CustomerOrdersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerOrdersList());
        }
    }
}