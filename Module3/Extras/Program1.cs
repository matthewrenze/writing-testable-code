using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module3.Easy;
using TestableCodeDemos.Module3.Shared;

namespace TestableCodeDemos.Module3.Extras
{
    public class Program
    {
        static void Main_(string[] args)
        {
            var invoiceId = int.Parse(args[0]);

            var command = new PrintInvoiceCommand(
                new Database(), 
                new InvoiceWriter(
                    new Printer(), 
                    new PageLayout()));

            command.Execute(invoiceId);
        }
    }
}
