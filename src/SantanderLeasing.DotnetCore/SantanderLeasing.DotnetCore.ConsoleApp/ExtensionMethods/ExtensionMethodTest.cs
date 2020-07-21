using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.ExtensionMethods
{
    public class ExtensionMethodTest
    {
        public static void Test()
        {
            DateTime dateTime = DateTime.Today;

            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Juz weekend!");
            }

            if (DateTimeHelper.IsHoliday(dateTime))
            {
                Console.WriteLine("Juz weekend!");
            }

            if (dateTime.IsHoliday())
            {
                Console.WriteLine("Juz weekend!");
            }

            DateTime myDate = DateTime.Today.AddWorkDays(3);

            string result = DateTime.Now.ToZeroUTCOffset();


            // TODO:
            // konwersja tekstu "2020-07-21T09-11-33.982Z" na DateTime

            result.ToDateTime();

            DateTime offsetDate = DateTime.Now.ToLocalTime();

        }
    }


    public static class StringExtensions
    {
        public static DateTime ToDateTime(this string input)
        {
            return DateTime.Today;
        }
    }

    // Metody rozszerzające (Extension Methods)
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime dateTime)
        {
            return dateTime.AddHours(2);
        }

        public static bool IsHoliday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkDays(this DateTime dateTime, int days)
        {
            return dateTime.AddDays(days);
        }

        // YYYY-MM-DDThh:mm:ss.SSSZ (np. 1997-07-16T19:20:30.123Z)

        public static string ToZeroUTCOffset(this DateTime dateTime)
        {
            return String.Format("{0:yyyy-MM-ddThh-mm-ss.fffZ}", dateTime.ToUniversalTime()) ;
        }

    }

   
    public class DateTimeHelper
    {
        public static bool IsHoliday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }

}
