using DataModel.GenericRepository;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class UnitofWork : IDisposable, IUnitofWork
    {
        private bool disposed;
        private readonly CustomerDbContext _context;
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Category> _categoryRepository;

        public UnitofWork(CustomerDbContext customerDbContext)
        {
            _context = customerDbContext;
        }       

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured " + ex.Message);
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new GenericRepository<Customer>(_context);
                }
                return _customerRepository;
            }
        }
    }
}
