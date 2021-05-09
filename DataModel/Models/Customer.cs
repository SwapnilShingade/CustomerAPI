using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public string PrimaryContact { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
