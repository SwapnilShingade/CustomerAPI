using BusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Interfaces
{
    public interface ICustomerService
    {
        List<CategoryDTO> GetCategories(int categoryId = 0);
        List<CustomerDTO> GetCustomers(int id = 0);
    }
}
