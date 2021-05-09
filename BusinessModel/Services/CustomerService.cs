using AutoMapper;
using BusinessModel.Interfaces;
using BusinessModel.Models;
using DataModel;
using DataModel.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessModel.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        

        public CustomerService() { }
        public CustomerService(CustomerDbContext customerDbContext, IMapper autoMapper, IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            mapper = autoMapper;
            CustomerDbContext = customerDbContext;            
        }

        public CustomerDbContext CustomerDbContext { get; }

        public List<CategoryDTO> GetCategories(int categoryId = 0)
        {
            List<CategoryDTO> result = new List<CategoryDTO>();
            Expression<Func<Category, bool>> whereFilter = null;
            try
            {
                if (categoryId > 0)
                {
                    whereFilter = x => x.CategoryId == categoryId;
                }
                else
                {
                    // gets all requests
                    whereFilter = null;
                }

                var dbResult = unitofWork.CategoryRepository.Get(whereFilter, includeProperties: "Customer");
                dbResult.ToList();
                if (dbResult.Any())
                {
                    result = mapper.Map<List<CategoryDTO>>(dbResult);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine($"Exception Occured at GetCategories Method: {ex.Message}");
            }

            return result;
        }

        public List<CustomerDTO> GetCustomers(int categoryId = 0)
        {
            List<CustomerDTO> result = new List<CustomerDTO>();
            Expression<Func<Customer, bool>> whereFilter = null;
            //var dbResult = unitofWork.CustomerRepository.Get();
            try
            {
                var categories = unitofWork.CategoryRepository.GetAll();
                if (categoryId > 0)
                {
                    whereFilter = x => x.CategoryId == categoryId;
                }
                else
                {
                    whereFilter = null;
                }
                var dbResult = unitofWork.CustomerRepository.Get(whereFilter);
                dbResult.ToList();
                if (dbResult.Any())
                {
                    foreach (var customer in dbResult)
                    {
                        CustomerDTO customerDTO = new CustomerDTO()
                        {
                            CategoryId = customer.CategoryId,
                            Id = customer.Id,
                            CustomerName = customer.CustomerName,
                            CityName = customer.CityName,
                            PhoneNumber = customer.PhoneNumber,
                            PrimaryContact = customer.PhoneNumber,
                            CategoryName = categories.Where(x => x.CategoryId == customer.CategoryId).Select(x => x.CategoryName).FirstOrDefault()
                        };
                        result.Add(customerDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured at GetCategories Method: {ex.Message}");
            }
            return result;
        }

    }
}
