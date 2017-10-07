using BookStore_Management.Models;
using Plugin.Media;
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
    public partial class SingleBook : ContentPage
    {
        public SingleBook()
        {
            InitializeComponent();
            BindingContext = new Book();
        }

        public SingleBook(string imageUrl)
        {
            InitializeComponent();
            BindingContext = new Book();
            image.Source = ImageSource.FromFile(imageUrl);
        }

        async public void OnPickPhotoClicked(Object sender, EventArgs args)
        {

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full
            });


            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                var imagePath = file.Path;
                var book = BindingContext as Book;
                book.CoverImage = imagePath;
                file.Dispose();
                    //var url = file.Path;
                    //var url2 = file.ToString();
                    //DisplayAlert(url, ":( Permission ns.", "OK");
                    //DisplayAlert(url2, ":( Permission.", "OK");
                    return stream;
            });
        }

        async public void OnSaveClicked(Object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            App.database.SaveBook(book);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            App.database.DeleteBook(book);
            await Navigation.PopAsync();
        }

        async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}