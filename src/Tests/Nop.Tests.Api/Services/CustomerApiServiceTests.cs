using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Plugin.Api.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace Nop.Tests.Api.Services
{
    [TestFixture]
    public class CustomerApiServiceTests
    {
        private ICustomerApiService _customerApiService;

        [SetUp]
        public new void SetUp()
        {
            var customerRepository = MockRepository.GenerateMock<IRepository<Customer>>();

            customerRepository.Expect(x => x.Table).Return((new List<Customer>()
            {
                new Customer()
                {
                    Email = "test@customer1.com"
                },
                new Customer()
                {
                    Email = "test@customer2.com"
                }

            }).AsQueryable());

            _customerApiService = new CustomerApiService(customerRepository);
        }

        [Test]
        public void Get_customers_call_with_default_parameters()
        {
            var customersResult = _customerApiService.GetCustomersDtos();

            Assert.IsNotNull(customersResult);
            Assert.IsNotEmpty(customersResult);
            Assert.AreEqual(2, customersResult.Count);
            Assert.AreEqual("test@customer1.com", customersResult[0].Email);            
            Assert.AreEqual("test@customer2.com", customersResult[1].Email);
        }

        [Test]
        public void Get_customers_limit_set_to_1()
        {
            var customersResult = _customerApiService.GetCustomersDtos(limit: 1);

            Assert.IsNotNull(customersResult);
            Assert.IsNotEmpty(customersResult);
            Assert.AreEqual(1, customersResult.Count);
            Assert.AreEqual("test@customer1.com", customersResult[0].Email);
        }
    }
}