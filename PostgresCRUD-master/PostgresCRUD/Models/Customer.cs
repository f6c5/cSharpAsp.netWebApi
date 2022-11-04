using System;

namespace PostgresCRUD.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public char gender { get; set; }
        public string city { get; set; }
        public DateTime date_of_birth { get; set; }
        public string number_phone { get; set; }
        public string gmail { get; set; }
    }
}
