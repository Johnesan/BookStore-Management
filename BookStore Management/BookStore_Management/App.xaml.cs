using BookStore_Management.Data;
using BookStore_Management.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BookStore_Management
{
    public partial class App : Application
    {

        private static StoreDB _database;
        public static StoreDB database
        {
            get
            {
                if (_database == null)
                {
                    _database = new StoreDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("storedb.db3"));
                }
                return _database;
            }
        }
        public int ResumeAtBookId { get; set; }
        public int ResumeAtOrderId { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new RootPage();
        }
    }
}
