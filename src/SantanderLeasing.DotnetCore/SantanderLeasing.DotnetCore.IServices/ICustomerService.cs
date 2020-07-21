using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SantanderLeasing.DotnetCore.IServices
{
    //public interface ICustomerService
    //{
    //    IEnumerable<Customer> Get();
    //    Customer Get(int id);
    //    void Add(Customer customer);
    //    void Update(Customer customer);
    //    void Remove(int id);
    //}


    // F12 - przejście do definicji
    // ALT+F12 - podejrzenie definicji
    public interface ICustomerService : IEntityService<Customer>
    {

    }
}
