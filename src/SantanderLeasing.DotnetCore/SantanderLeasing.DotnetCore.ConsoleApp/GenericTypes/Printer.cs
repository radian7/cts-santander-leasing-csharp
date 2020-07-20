using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.GenericTypes
{
    public class ObjectPrinter
    {
        private object lastItem;

        public void Print(object item)
        {
            Console.WriteLine(item);

            lastItem = item;
        }

        public object GetLast()
        {
            return lastItem;
        }
    }


    public class Printer
    {
        //public void Print(DateTime item)
        //{
        //    Console.WriteLine(item);
        //}

        //public void Print(int item)
        //{
        //    Console.WriteLine(item);
        //}

        //public void Print(Customer item)
        //{
        //    Console.WriteLine(item);
        //}

        // Metoda generyczna

        // Metoda generyczna
        public void Print<TItem>(TItem item)
        {
            Console.WriteLine(item);
        }

        public void Send<T>(T item)
        {

        }
    }


    // Klasa generyczna (szablon)
    public class Printer<TItem>
    {
        private TItem lastItem;

        public void Print(TItem item)
        {
            Console.WriteLine(item);

            lastItem = item;
        }

        public TItem GetLast()
        {
            return lastItem;
        }

    }

    public class IntPrinter
    {
        private int lastNumber;

        public void Print(int number)
        {
            Console.WriteLine(number);

            lastNumber = number;
        }

        public int GetLast()
        {
            return lastNumber;
        }
    }

    public class CustomerPrinter
    {
        private Customer lastCustomer;

        public void Print(Customer customer)
        {
            Console.WriteLine(customer);

            lastCustomer = customer;
        }

        public Customer GetLast()
        {
            return lastCustomer;
        }
    }

    public class DateTimePrinter
    {
        private DateTime lastDateTime;

        public void Print(DateTime dateTime)
        {
            Console.WriteLine(dateTime);

            lastDateTime = dateTime;
        }

        public DateTime GetLast()
        {
            return lastDateTime;
        }
    }
}
