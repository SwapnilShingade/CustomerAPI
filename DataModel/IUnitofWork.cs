using DataModel.GenericRepository;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public interface IUnitofWork
    {
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Customer> CustomerRepository { get; }
        void Save();
    }          

}
