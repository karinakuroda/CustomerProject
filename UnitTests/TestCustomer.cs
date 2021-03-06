using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service;
using Xunit;

namespace UnitTests
{
	[TestClass]
    public class TestCustomer
    {
		Mock<ICustomerRepository> _mockCustomerRepository;
		ICustomerService _customerService;
		Mock<IOrderRepository> _mockOrderRepository;

		[TestInitialize]
		public void Init()
		{
			_mockCustomerRepository = new Mock<ICustomerRepository>();
			_mockOrderRepository = new Mock<IOrderRepository>();
			_customerService = new CustomerService(_mockCustomerRepository.Object, _mockOrderRepository.Object);
		}

		[TestMethod]
		public void ShouldCallGetCustomerOnlyOnce()
        {
			//Arrange
			_mockCustomerRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(GetCustomerMock());
			//Act
			var resp = _customerService.Get(It.IsAny<Guid>());
			//Assert
			_mockCustomerRepository.Verify(o => o.Get(It.IsAny<Guid>()), Times.Once());
		}
		[TestMethod]
		public void ShouldCallGetAllCustomersRepository()
		{
			//Arrange
			_mockCustomerRepository.Setup(s => s.GetAll()).Returns(GetCustomerMockList());
			//Act
			var resp = _customerService.GetAll();
			//Assert
			_mockCustomerRepository.Verify(o => o.Get(It.IsAny<Guid>()), Times.Once());
		}
		[TestMethod]
		public void ShouldGetCustomer()
		{
			//Arrange
			_mockCustomerRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(GetCustomerMock());
			//Act
			var resp = _customerService.Get(It.IsAny<Guid>());
			//Assert
			resp.Email.Equals(GetCustomerMock().Email);
		}
		[TestMethod]
		public void ShouldCallGetByCustomer()
		{
			//Arrange
			_mockOrderRepository.Setup(s => s.GetByCustomer(It.IsAny<Guid>())).Returns(new List<Order>());
			//Act
			var resp = _customerService.GetWithOrders(It.IsAny<Guid>());
			//Assert
			_mockOrderRepository.Verify(o => o.GetByCustomer(It.IsAny<Guid>()), Times.Once());
		}
		[TestMethod]
		public void ShouldCallGetByCustomerRepository()
		{
			//Arrange
			_mockCustomerRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(GetCustomerMock());
			//Act
			var resp = _customerService.GetWithOrders(It.IsAny<Guid>());
			//Assert
			_mockCustomerRepository.Verify(o => o.Get(It.IsAny<Guid>()), Times.Once());
		}
		[TestMethod]
		public void ShouldUpdateCustomer()
		{
			//Arrange
			_mockCustomerRepository.Setup(s => s.Update(It.IsAny<Customer>())).Returns(true);
			//Act
			var resp = _customerService.Update(It.IsAny<Customer>());
			//Assert
			//resp.Email.Equals(GetCustomerMock().Email);
		}
		private static Customer GetCustomerMock()
		{
			return Customer.Create("Test", "Test@t.com");
		}
		private static List<Customer> GetCustomerMockList()
		{
			var list = new List<Customer>();
			list.Add(Customer.Create("Test", "Test@t.com"));
			return list;
		}
	}
}
