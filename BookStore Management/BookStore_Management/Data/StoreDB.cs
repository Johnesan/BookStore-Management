using BookStore_Management.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Management.Data
{
    public class StoreDB
    {
        SQLiteConnection database;

        public StoreDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Book>();
            database.CreateTable<Order>();
            database.CreateTable<LoginCredentials>();
        }

        #region Books Repository
        public List<Book> GetAllBooks()
        {
            return database.Table<Book>().ToList();
        }

        //public List<Book> GetExpiredBooks()
        //{
        //    var result = database.Table<Book>().Where(s => s.Expired == true).ToList();

        //    return result;
        //}
        public Book GetSingleBook(int id)
        {
            return database.Table<Book>().Where(i => i.ID == id).FirstOrDefault();

        }
        public int SaveBook(Book book)
        {
            if (book.ID != 0)
            {
                return database.Update(book);
            }
            else
            {
                return database.Insert(book);
            }
        }

        public int DeleteBook(Book book)
        {
            return database.Delete(book);
        }
        #endregion

        #region Orders Repository
        public List<Order> GetAllOrders()
        {
            return database.Table<Order>().ToList();
        }

        public Order GetSingleOrder(int id)
        {
            return database.Table<Order>().Where(i => i.ID == id).FirstOrDefault();

        }
        public int SaveOrder(Order order)
        {
            if (order.ID != 0)
            {
                return database.Update(order);
            }
            else
            {
                return database.Insert(order);
            }
        }

        public int DeleteOrder(Order order)
        {
            return database.Delete(order);
        }
        #endregion

        #region Login Credentials
        public LoginCredentials GetLoginCredentials()
        {
            return database.Table<LoginCredentials>().FirstOrDefault();
        }

        public void SaveLoginCredentials(LoginCredentials loginCredentials)
        {
            database.InsertOrReplace(loginCredentials);
        }
        #endregion

    }
}
