using System;
using SQLite;

namespace PaymentsApp.Models
{
    public class Payment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
    }
}