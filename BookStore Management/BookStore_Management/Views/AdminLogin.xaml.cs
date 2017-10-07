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
    public partial class AdminLogin : ContentPage
    {
        public AdminLogin()
        {
            InitializeComponent();
            var loginCredentials = App.database.GetLoginCredentials();
            UserName.Text = loginCredentials.Username;
            Password.Text = loginCredentials.Password;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (UserName.Text == "Admin" && Password.Text == "Admin")
            {
                var loginCredentials = new LoginCredentials {Username = "Admin", Password = "Admin"};
                App.database.SaveLoginCredentials(loginCredentials);
                await Navigation.PushAsync(new AdminArea());
            }
            else
            {
               await DisplayAlert("Unsuccessful!", "The Username or Password is Incorrect. Please provide correct admin credentials", "OK");
            }
        }
    }
}