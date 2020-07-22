using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;

namespace SantanderLeasing.DotnetCore.Api.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/klienci")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        //[HttpGet]
        //public Customer Get()
        //{
        //    // inicjalizator
        //    return new Customer
        //    {
        //        Id = 1,
        //        FirstName = "John",
        //        LastName = "Smith",
        //        Gender = Gender.Man,
        //        IsRemoved = false
        //    };
        //}

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = customerService.Get();
            return customers;
        }
    }
}
