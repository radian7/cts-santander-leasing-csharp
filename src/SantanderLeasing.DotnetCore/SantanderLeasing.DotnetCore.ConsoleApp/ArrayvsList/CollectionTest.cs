using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.ArrayvsList
{
    public class CollectionTest
    {
        public static void Test()
        {
            IList<int> numbers = new Collection<int>();

            numbers.Add(100);
            numbers.Add(5);
            numbers.Add(44);
            numbers.Add(53);

            numbers[0] = 99;

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
