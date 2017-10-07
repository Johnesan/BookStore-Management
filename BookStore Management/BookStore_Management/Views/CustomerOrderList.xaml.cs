using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_Management.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerOrdersList : ContentPage
    {
        public CustomerOrdersList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtOrderId = -1;
            ObservableCollection<Order> orders = new ObservableCollection<Order>(App.database.GetAllOrders());

            if (orders.Count == 0)
            {
                NoneAvailableLabel.IsEnabled = true;
                NoneAvailableLabel.IsVisible = true;
            }
            OrdersListView.ItemsSource = orders;
        }

        private async void OnSingleOrderSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtBookId = (e.SelectedItem as Order).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as Order).ID);
            var order = e.SelectedItem as Order;
            var book = App.database.GetAllBooks().Single(book1 => book1.Title == order.BookTitle);
            
            await Navigation.PushAsync(new SingleCustomerOrder(book)
            {
                BindingContext =  order
            });
            //var imageUrl = book.CoverImage;
            //await Navigation.PushAsync(new SingleBook(imageUrl)
            //{

            //    BindingContext = e.SelectedItem as Book
            //});

        }
    }
}