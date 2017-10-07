using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Management.Models
{
    public enum Gender
    {
        Male, Female
    }
    public enum OrderType
    {
       Rent, Buy
    }
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime Date { get; set; }
        public string BookTitle { get; set; }
        public OrderType OrderType { get; set; }
        public bool Completed { get; set; }

    }
}
