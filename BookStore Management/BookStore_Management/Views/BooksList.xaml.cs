using BookStore_Management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksList : ContentPage
    {
        public BooksList()
        {
            InitializeComponent();
            ObservableCollection<Book> books = new ObservableCollection<Book>(App.database.GetAllBooks());
            if (books.Count == 0)
            {
                NoneAvailableLabel.IsEnabled = true;
                NoneAvailableLabel.IsVisible = true;
            }
            else
            {

                NoneAvailableLabel.IsEnabled = false;
                NoneAvailableLabel.IsVisible = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtBookId = -1;
            ObservableCollection<Book> books = new ObservableCollection<Book>(App.database.GetAllBooks());
            if (books.Count == 0)
            {
                NoneAvailableLabel.IsEnabled = true;
                NoneAvailableLabel.IsVisible = true;
            }
            BooksListView.ItemsSource = books;
        }

        async private void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SingleBook()
            {
                Title = "Add New Book"
            });
        }

        async private void OnSingleBookSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtBookId = (e.SelectedItem as Book).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as Book).ID);
            var book = e.SelectedItem as Book;
            var imageUrl = book.CoverImage;
            await Navigation.PushAsync(new SingleBook(imageUrl)
            {
                BindingContext = e.SelectedItem as Book
            });

        }
    }
}