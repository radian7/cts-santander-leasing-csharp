using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.ArrayvsList
{
    public class QueueStackTest
    {
        public static void Test()
        {
            DictionaryTest();
            QueueTest();
            StackTest();
        }

        // | Key (DateTime) | string


        private static void DictionaryTest()
        {
            IDictionary<DateTime, string> holidays = new Dictionary<DateTime, string>();

            holidays.Add(DateTime.Parse("2020-07-20"), "1 dzień");
            holidays.Add(DateTime.Parse("2020-07-21"), "2 dzień");
            holidays.Add(DateTime.Parse("2020-07-22"), "3 dzień");

            string name = holidays[DateTime.Parse("2020-07-21")];

            Console.WriteLine(name);

        }

        private static void QueueTest()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(100);
            queue.Enqueue(45);
            queue.Enqueue(30);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            int firstNumber = queue.Peek();

            while(queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void StackTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(100);
            stack.Push(45);
            stack.Push(30);

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }

            int firstNumber = stack.Peek();

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        private static void ConcurentQueueTest()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            queue.Enqueue(100);
            queue.Enqueue(45);
            queue.Enqueue(30);

            if (queue.TryDequeue(out int item))
            {
                Console.WriteLine(item);
            }
            else
            {

            }
        }

    }
}
