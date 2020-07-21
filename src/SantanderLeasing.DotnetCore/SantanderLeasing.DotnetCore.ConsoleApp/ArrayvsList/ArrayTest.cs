using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.ArrayvsList
{
    public class ArrayTest
    {

        public static void Test()
        {
            int[] numbers = new int[10];

            numbers[0] = 100;
            numbers[1] = 5;
            numbers[2] = 56;
            numbers[3] = 29;

            // snippet: for
            for (int i = 0; i < numbers.Count() ; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // Linq
            numbers = numbers.OrderByDescending(n => n).ToArray();

            // snippet: foreach
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
