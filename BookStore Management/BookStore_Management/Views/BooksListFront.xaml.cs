using BookStore_Management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace BookStore_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksListFront : ContentPage
    {
        List<Image> images = new List<Image>();
        public BooksListFront()
        {
            InitializeComponent();
            ObservableCollection<Book> books = new ObservableCollection<Book>(App.database.GetAllBooks());

            //foreach(Book book in books)
            //{
            //    Image image = new Image();
            //    image.Source = ImageSource.FromFile(book.CoverImage);
            //}
            if (books.Count == 0)
            {
                NoneAvailableLabel.IsEnabled = true;
                NoneAvailableLabel.IsVisible = true;
            }
            BooksListView.ItemsSource = books;
            

        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Reset the 'resume' id, since we just want to re-start here
        //    ((App)App.Current).ResumeAtBookId = -1;
        //    ObservableCollection<Book> books = new ObservableCollection<Book>(App.database.GetAllBooks());
        //    BooksListView.ItemsSource = books;            
        //}

        async private void OnSingleBookSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtBookId = (e.SelectedItem as Book).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as Book).ID);
            var book = e.SelectedItem as Book;
            if (book.NumberOfCopies == 0)
            {
               await  DisplayAlert("Unavailable", "This book is currently out of stock. Try again later", "OK");
                return;
            }
            await Navigation.PushAsync(new CustomerOrderFront(book));
           
        }
    }
}