using System.Web.Http;
using System.Web.Http.Description;
using Nop.Plugin.Api.DTOs.Customers;
using Nop.Plugin.Api.Models.CustomersParameters;
using Nop.Plugin.Api.MVC;
using Nop.Plugin.Api.Services;
using Nop.Services.Common;
using Nop.Services.Customers;

namespace Nop.Plugin.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerApiService _customerApiService;

        public CustomersController(ICustomerService customerService, 
            ICustomerApiService customerApiService)
        {
            _customerService = customerService;
            _customerApiService = customerApiService;
        }

        [HttpGet]
        [ResponseType(typeof(CustomersRootObject))]
        public IHttpActionResult GetCustomers(CustomersParametersModel parameters)
        {
            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(CustomersCountRootObject))]
        public IHttpActionResult GetCustomersCount()
        {
            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(CustomersRootObject))]
        public IHttpActionResult GetCustomerById(CustomerParametersModel parameters)
        {
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Search(CustomersSearchParametersModel parameters)
        {
            return Ok();
        }
    }
}