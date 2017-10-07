using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Management.Models
{
  

    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender gender { get; set; }
    }
}
