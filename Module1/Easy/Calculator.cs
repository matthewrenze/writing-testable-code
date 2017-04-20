using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module1.Easy
{
    public class Calculator
    {
        public decimal GetTotal(decimal parts, decimal service, decimal discount)
        {
            return parts + service - discount;
        }
    }
}