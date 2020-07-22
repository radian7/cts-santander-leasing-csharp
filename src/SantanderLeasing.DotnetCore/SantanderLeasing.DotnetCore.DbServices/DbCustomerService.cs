using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SantanderLeasing.DotnetCore.DbServices
{
    public class DbCustomerService : ICustomerService
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
