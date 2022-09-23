using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;
using TestableCodeDemos.Module3.Easy;

namespace TestableCodeDemos.Module3.Extras
{
    public class Program4
    {
        static void Main_(string[] args)
        {
            var container = new StandardKernel();

            container.Bind(p =>
            {
                p.FromThisAssembly()
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });

            var invoiceId = int.Parse(args[0]);

            var command = container.Get<PrintInvoiceCommand>();

            command.Execute(invoiceId);
        }
    }
}
