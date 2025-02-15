using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module1.Easy
{
    class Program
    {
        static void Main_Easy(string[] args)
        {
            var parts = decimal.Parse(args[0]);

            var service = decimal.Parse(args[1]);

            var discount = decimal.Parse(args[2]);

            var calculator = new Calculator();

            var total = calculator.GetTotal(parts, service, discount);

            Console.WriteLine("Total Price: $" + total);
        }
    }
}
