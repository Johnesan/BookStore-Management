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
    public partial class SingleCustomerOrder : ContentPage
    {
        public SingleCustomerOrder(Book book)
        {
            InitializeComponent();
            BookTitleLabel.Text = book.Title;
            BookAuthorLabel.Text = book.Author;
            BookPublisherLabel.Text = book.Publisher;
            BookPriceLabel.Text = book.Price;
            BookCoverImage.Source = ImageSource.FromFile(book.CoverImage);
            BindingContext = new Order();
        }

         public async void OnSaveClicked(Object sender, EventArgs e)
        {
            var order = (Order)BindingContext;
            App.database.SaveOrder(order);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var order = (Order)BindingContext;
            App.database.DeleteOrder(order);
            await Navigation.PopAsync();
        }

        //async void Back(object sender, EventArgs e)
        //{
        //    await Navigation.PopAsync();
        //}

    }
}