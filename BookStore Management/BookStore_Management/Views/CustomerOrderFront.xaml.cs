using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_Management.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerOrderFront : ContentPage
    {
        public Book SelectedBook { get; set; }
        public CustomerOrderFront(Book book)
        {
            InitializeComponent();

            GenderPicker.Items.Add("Male");
            GenderPicker.Items.Add("Female");


            DateLabel.Text = DateTime.Now.ToString();
            CoverImage.Source = ImageSource.FromFile(book.CoverImage);
            BookTitleLabel.Text = book.Title;
            BookAuthorLabel.Text = book.Author;
            BookPriceLabel.Text = book.Price;
            SelectedBook = book;

        }

        public async void RentButtonClicked(object sender, EventArgs e)
        {
            if (GenderPicker == null)
            {
                await DisplayAlert("Invalid Field", "Please Select Your Gender", "OK");
                return;
            }
            if (FullNameEntry.Text == null || AddressEntry == null || PhoneNumberEntry.Text == null)
            {
                await DisplayAlert("Invalid Field", "Please Fill in all Fields", "OK");
                return;
            }

            var order = new Order();
            order.OrderType = OrderType.Rent;
            order.FullName = FullNameEntry.Text;
            order.Address = AddressEntry.Text;
            order.PhoneNumber = PhoneNumberEntry.Text;
            order.Gender = GenderPicker.SelectedItem.ToString();
            order.BookTitle = BookTitleLabel.Text;
            order.Date = DateTime.Now;
            order.Completed = false;
            

            App.database.SaveOrder(order);
            SelectedBook.NumberOfCopies -= 1;
            App.database.SaveBook(SelectedBook);
            await Navigation.PopAsync();

        }

        private async void BuyButtonClicked(object sender, EventArgs e)
        {
            if (GenderPicker.SelectedItem == null)
            {
                await DisplayAlert("Invalid Field", "Please Select Your Gender", "OK");
                return;
            }
            if (FullNameEntry.Text == null || AddressEntry == null || PhoneNumberEntry.Text == null)
            {
                await DisplayAlert("Invalid Field", "Please Fill in all Fields", "OK");
                return;
            }

            var order = new Order();
            order.OrderType = OrderType.Buy;
            order.FullName = FullNameEntry.Text;
            order.Address = AddressEntry.Text;
            order.PhoneNumber = PhoneNumberEntry.Text;
            order.Gender = GenderPicker.SelectedItem.ToString();
            order.BookTitle = BookTitleLabel.Text;
            order.Date = DateTime.Now;
            order.Completed = false;




            App.database.SaveOrder(order);
            SelectedBook.NumberOfCopies -= 1;
            App.database.SaveBook(SelectedBook);
            await Navigation.PopAsync();

        }
    }
}
