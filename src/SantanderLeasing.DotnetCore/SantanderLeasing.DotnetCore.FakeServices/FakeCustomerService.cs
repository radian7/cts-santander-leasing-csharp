using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SantanderLeasing.DotnetCore.FakeServices
{
    public class FakeCustomerService : ICustomerService
    {
        private ICollection<Customer> customers;

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
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
