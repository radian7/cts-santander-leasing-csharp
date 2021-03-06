﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SantanderLeasing.DotnetCore.ConsoleApp.Tasks
{
    public class TaskTest
    {
        public static void Test()
        {
            Console.WriteLine($"#{ThreadId} Test");

            // SyncTest();

            // TaskRunTest();

            // SyncCalculateTest();

            ParallerWhenAllTasksTest();

            // AsyncAwaitTest();

            // TaskCalculateTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void TaskRunTest()
        {
            //Task task1 = new Task(() => Send("Hello World!"));
            // ...
            //task1.Start();

            Task task1 = Task.Run(() => Send("Hello World!"));

            //Task task2 = new Task(() => Send("Hello .NET Core"));
            // ...
            //task2.Start();

            Task task2 = Task.Run(() => Send("Hello .NET Core"));

            // Task.WaitAll(task1, task2);
        }

        private static void SyncTest()
        {
            Send("Hello World!");
            Send("Hello .NET Core");
        }

        //private static void TaskCalculateTest()
        //{
        //    int pages = 10;

        //    Task<decimal> task1 = Task.Run(() => Calculate(pages));

        //    // task1.ContinueWith(t => Console.WriteLine(t.Result));

        //    task1
        //        .ContinueWith(t => Task.Run(() => CalculateTax(t.Result))
        //            .ContinueWith(t => Console.WriteLine(t.Result)));

        //    //task1.Wait();
        //    //Console.WriteLine(task1.Result);
        //}

        private static void TaskCalculateTest()
        {
            int pages = 10;

            CalculateTask(pages)
                .ContinueWith(t => CalculateTaxTask(t.Result))
                    .ContinueWith(t => Console.WriteLine(t.Result));
        }

        private static void SyncCalculateTest()
        {
            int pages = 10;

            decimal cost = Calculate(pages);

            cost = CalculateTax(cost);

            Console.WriteLine(cost);
        }

        // wykonanie sekwencyjne
        private static async void AsyncAwaitTest()
        {
            Console.WriteLine($"#{ThreadId} Test 1");
            await AsyncAwaitCalculateTestAsync();

            Console.WriteLine($"#{ThreadId} Test 2");
            await AsyncAwaitCalculateTestAsync();

            Console.WriteLine("Press any key to exit from AsyncAwaitTest.");
            Console.ReadKey();
        }

        // wykonanie równolegle
        private static void ParallerTasksTest()
        {
            Console.WriteLine($"#{ThreadId} Test 1");
            AsyncAwaitCalculateTestAsync();

            Console.WriteLine($"#{ThreadId} Test 2");
            AsyncAwaitCalculateTestAsync();

            Console.WriteLine("Press any key to exit from AsyncAwaitTest.");
            Console.ReadKey();
        }

        // Thread, ThreadPool

        // TPL Task Paraller Library
        private static async void ParallerWhenAllTasksTest()
        {
            Console.WriteLine($"#{ThreadId} Test 1");
            Task task1 = AsyncAwaitCalculateTestAsync();

            Console.WriteLine($"#{ThreadId} Test 2");
            Task task2 = AsyncAwaitCalculateTestAsync();

            // blokuje Task.WaitAll(task1, task2);

            await Task.WhenAll(task1, task2);

            Console.WriteLine("Press any key to exit from AsyncAwaitTest.");
            Console.ReadKey();
        }

        private static async Task AsyncAwaitCalculateTestAsync()
        {
            int pages = 10;

            decimal cost = await CalculateTask(pages);

            Console.WriteLine("Do work");

            cost = await CalculateTaxTask(cost); 

            Console.WriteLine(cost);
        }

        private static Task<decimal> CalculateTask(int pages)
        {
            return Task.Run(() => Calculate(pages));
        }

        private static Task<decimal> CalculateTaxTask(decimal amount)
        {
            return Task.Run(() => CalculateTax(amount));
        }

       

        private static decimal CalculateTax(decimal amount)
        {
            Console.WriteLine($"#{ThreadId} Calculating Tax {amount}");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine($"#{ThreadId} Calculated.");
            return amount * 1.23m;
        }

        private static decimal Calculate(int pages)
        {
            Console.WriteLine($"#{ThreadId} Calculating {pages}");
            decimal cost = pages * 0.99m;
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"#{ThreadId} Calculated.");

            return cost;
        }


        // private static int ThreadId => Thread.CurrentThread.ManagedThreadId;

        private static int ThreadId
        {
            get
            {
                return Thread.CurrentThread.ManagedThreadId;
            }
        }

        private void Print(string message) => Console.WriteLine(message);

        //private void Print(string message)
        //{
        //    Console.WriteLine(message);
        //}

        private static void Send(string message)
        {
            Console.WriteLine($"#{ThreadId} sending... {message}");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"#{ThreadId} sent {message}.");
        }
    }
}
