using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public string PrimaryContact { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
