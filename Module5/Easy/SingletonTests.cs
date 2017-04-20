using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using NUnit.Framework;

namespace TestableCodeDemos.Module5.Easy
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void TestTransientScopeReturnsDifferentInstance()
        {
            var container = new StandardKernel();

            container.Bind<ISecurity>()
                .To<Security>();

            var security1 = container.Get<ISecurity>();

            var security2 = container.Get<ISecurity>();

            Assert.That(security1,
                Is.Not.SameAs(security2));
        }

        [Test]
        public void TestSingletonReturnsSameInstance()
        {
            var container = new StandardKernel();

            container.Bind<ISecurity>()
                .To<Security>()
                .InSingletonScope();

            var security1 = container.Get<ISecurity>();

            var security2 = container.Get<ISecurity>();

            Assert.That(security1,
                Is.SameAs(security2));
        }
    }
}
