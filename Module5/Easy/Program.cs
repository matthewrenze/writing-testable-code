using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;

namespace TestableCodeDemos.Module5.Easy
{
    public class Program
    {
        static void Main_(string[] args)
        {
            var invoiceId = int.Parse(args[0]);

            var container = new StandardKernel();

            container.Bind(p =>
            {
                p.FromThisAssembly()
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });

            container.Bind<ISecurity>()
                .To<Security>()
                .InSingletonScope();

            var command = container.Get<PrintInvoiceCommand>();

            command.Execute(invoiceId);
        }
    }
}
