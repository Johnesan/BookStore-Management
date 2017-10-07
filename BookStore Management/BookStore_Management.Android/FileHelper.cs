using System.IO;
using Xamarin.Forms;
using BookStore_Management.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace BookStore_Management.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}