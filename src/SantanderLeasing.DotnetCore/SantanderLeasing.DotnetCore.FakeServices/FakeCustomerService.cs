using Microsoft.Extensions.Options;
using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;

namespace SantanderLeasing.DotnetCore.FakeServices
{
    public class CustomerOptions
    {
        public int Count { get; set; }
        public string DefaultLastName { get; set; }
    }

    public class FakeCustomerService : ICustomerService
    {
        private readonly ICollection<Customer> customers;

        private int count;

        // snippet: ctor
        // dotnet add package Microsoft.Extensions.Options
        public FakeCustomerService(IOptions<CustomerOptions> options)
        {
            this.count = options.Value.Count;

            string defaultLastName = options.Value.DefaultLastName; 

            customers = new Collection<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = defaultLastName, Gender = Gender.Man },
                new Customer { Id = 2, FirstName = "Kate", LastName = defaultLastName, Gender = Gender.Female },
                new Customer { Id = 3, FirstName = "Jack", LastName = defaultLastName, Gender = Gender.Man },
                new Customer { Id = 4, FirstName = "Ann", LastName = defaultLastName, Gender = Gender.Female },
                new Customer { Id = 5, FirstName = "Steven", LastName = defaultLastName, Gender = Gender.Man },
            };
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            // return customers.Where(p => p.Id == id).Single();
            // customers.FirstOrDefault(p => p.Id == id);
            return customers.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            Remove(customer.Id);
            Add(customer);
        }
    }
}
