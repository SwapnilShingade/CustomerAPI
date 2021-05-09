using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.Models
{
    public class Category
    {
        public Category(){         
        }
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
