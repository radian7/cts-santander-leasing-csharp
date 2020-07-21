using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SantanderLeasing.DotnetCore.ConsoleApp.Delegates
{
 

    public class DelegatesTest
    {
        public static void Test()
        {
            LaserPrinter printer = new LaserPrinter();

            printer.Log += LogConsole;
            printer.Log += LogColorConsole;
            printer.Log += LogFile;
            // printer.Log += LogColorConsoleEx;
            printer.Log += Console.WriteLine;

            // Metoda anonimowa
            printer.Log += delegate (string message)
            {
                Console.WriteLine("Send email {0}", message);
            };

            // Wyrażenia lambda -> Linq


            printer.CalculateCost += CalculateStandardCost;

            printer.Print("Hello World!", 5);

            printer.Log -= LogColorConsole;
            printer.Print("Hello .NET!");

            printer.Log = null;
            printer.Print("Hello .NET Core!");
        }

        public static decimal CalculateStandardCost(int pages)
        {
            decimal unitPrice = 1.00m;
            return pages * unitPrice;
        }

        public static void EmptyConsole()
        {

        }

        public static void LogConsole(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogColorConsoleEx(string message, ConsoleColor background = ConsoleColor.Green)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void LogColorConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void LogFile(string message)
        {
            System.IO.File.AppendAllText(@"c:\temp\log.txt", message + Environment.NewLine);
        }
    }

   
    public class LaserPrinter
    {
        public delegate void LogDelegate(string message);

        public LogDelegate Log;

        public delegate decimal CalculateCostDelegate(int pages);

        public CalculateCostDelegate CalculateCost;

        //public decimal CalculateCost(int pages)
        //{
        //    decimal unitPrice = 1.00m;

        //    return pages * unitPrice;
        //}

        public void Print(string content, int pages = 1)
        {
            for (int i = 1; i <= pages; i++)
            {
                Console.WriteLine("Printing {0} number copy {1}", content, i);

                Log?.Invoke(content);

                if (Log != null)
                    Log.Invoke(content);

                Delegate[] delegates = Log.GetInvocationList();

                //LogConsole(content);
                //LogColorConsole(content);
                //LogFile(content);
            }

            decimal? totalAmount = CalculateCost?.Invoke(pages);

            if (totalAmount.HasValue)
                Console.WriteLine($"Cost {totalAmount}");
        }

      
    }
}
