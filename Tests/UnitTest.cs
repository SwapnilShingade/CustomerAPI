using APITEST.Controllers;
using BusinessModel.Interfaces;
using BusinessModel.Models;
using BusinessModel.Services;
using DataModel;
using DataModel.GenericRepository;
using DataModel.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class CustomerServiceTest
    {
        #region Variables

        private ICustomerService customerService;
        private UnitofWork _unitOfWork;
        private List<Category> categories;
        private List<Customer> customers;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Category> categoryRepository;


        #endregion

        [SetUp]
        public void ReInitializeTest()
        {
            customers = Helper.GetCustomers();
            categories = Helper.GetCategories();            
            customerRepository = SetUpCustomerRepository();
            categoryRepository = SetUpCategoryRepository();
            var unitOfWork = new Mock<IUnitofWork>();
            unitOfWork.Setup(s => s.CustomerRepository).Returns(customerRepository);
            unitOfWork.Setup(s => s.CategoryRepository).Returns(categoryRepository);
            _unitOfWork = (UnitofWork)unitOfWork.Object;
            customerService = new CustomerService(null,null,_unitOfWork);

        }

        private GenericRepository<Customer> SetUpCustomerRepository()
        {
            var mockRepo = new Mock<GenericRepository<Customer>>(MockBehavior.Default);

            // Setup mocking behavior
            mockRepo.Setup(p => p.GetAll()).Returns(customers);

            mockRepo.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Customer>(
                             id => customers.Find(p => p.Id.Equals(id))));
            mockRepo.Setup(p => p.Get()).Returns(customers);
            return mockRepo.Object;
        }

        private GenericRepository<Category> SetUpCategoryRepository()
        {
            var mockRepo = new Mock<GenericRepository<Category>>(MockBehavior.Default);

            // Setup mocking behavior
            mockRepo.Setup(p => p.GetAll()).Returns(categories);

            mockRepo.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Category>(
                             id => categories.Find(p => p.CategoryId.Equals(id))));
            mockRepo.Setup(p => p.Get()).Returns(categories);
            return mockRepo.Object;
        }
        [SetUp]
        public void Setup()
        {
            customers = Helper.GetCustomers();
            categories = Helper.GetCategories();
        }

        [Test]
        public void GetAllCategoriesTest()
        {
            var result = customerService.GetCategories();
            if (result != null)
            {
                Assert.AreEqual(result.Count, categories.Count);
                Assert.AreEqual(result[0].CategoryId, categories[0].CategoryId);
                Assert.AreEqual(result[0].CategoryName, categories[0].CategoryName);
            }
        }

        [Test]
        public void GetAllCustomersTest()
        {
            var result = customerService.GetCustomers();
            if (result != null)
            {
                Assert.AreEqual(result.Count, customers.Count);
                Assert.AreEqual(result[0].CategoryId, customers[0].CategoryId);
                Assert.AreEqual(result[0].CustomerName, customers[0].CustomerName);
                Assert.AreEqual(result[0].PrimaryContact, customers[0].PrimaryContact);
            }
        }

    }
}