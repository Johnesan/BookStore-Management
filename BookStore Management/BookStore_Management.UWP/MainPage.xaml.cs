namespace BookStore_Management.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new BookStore_Management.App());
        }
    }
}