using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<CustomerDTO> Customer { get; set; }
    }
}
