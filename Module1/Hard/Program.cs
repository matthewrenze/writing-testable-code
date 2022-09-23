using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module1.Hard
{
    class Program
    {
        static void Main_Hard(string[] args)
        {
            var parts = decimal.Parse(args[0]);

            var service = decimal.Parse(args[1]);

            var discount = decimal.Parse(args[2]);

            var total = parts + service - discount;

            Console.WriteLine("Total Price: $" + total);
        }
    }
}
