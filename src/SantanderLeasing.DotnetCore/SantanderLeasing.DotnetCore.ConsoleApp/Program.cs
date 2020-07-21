using SantanderLeasing.DotnetCore.ConsoleApp.ArrayvsList;
using SantanderLeasing.DotnetCore.ConsoleApp.Delegates;
using SantanderLeasing.DotnetCore.ConsoleApp.ExtensionMethods;
using SantanderLeasing.DotnetCore.ConsoleApp.GenericTypes;
using SantanderLeasing.DotnetCore.Models;
using System;

namespace SantanderLeasing.DotnetCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegatesTest.Test();

            ExtensionMethodTest.Test();

            QueueStackTest.Test();
            CollectionTest.Test();

            ArrayTest.Test();

            GenericTypesMethodTest();
            GenericTypesClassTest();
        }

        static void GenericTypesMethodTest()
        {
            Printer printer = new Printer();

            printer.Print<DateTime>(DateTime.Now);

            printer.Print<int>(100);

            Customer customer = new Customer { Id = 1, FirstName = "John" };
            printer.Print<Customer>(customer);

        }

        static void GenericTypesClassTest()
        {
            Printer<DateTime> datetimePrinter = new Printer<DateTime>();
            datetimePrinter.Print(DateTime.Now);

            DateTime lastItem = datetimePrinter.GetLast();

            // snippet: cw + 2 x Tab
            Console.WriteLine(lastItem);

            Printer<int> intPrinter = new Printer<int>();
            intPrinter.Print(100);

            Console.WriteLine(intPrinter.GetLast());

            // TODO: utworz klienta i go wydrukuj

            Customer customer = new Customer { Id = 1, FirstName = "John" };

            Printer<Customer> printer = new Printer<Customer>();

            printer.Print(customer);

            Customer lastCustomer = printer.GetLast();

            Console.WriteLine(lastCustomer);

        }
    }
}
