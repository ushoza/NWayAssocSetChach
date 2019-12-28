using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Collections;
using System.IO;
using NWayAssocSetChach;

namespace TestProject
{
    [TestFixture]
    public class TestBaseLogic
    {
        IGenericAlgo<long> algo;
        NWayAssocSetChach.NWayAssociateSetChache<string, TestPerson, long> cache;

        [SetUp]
        public void Init()
        {
            algo = new GLru();
            cache =
                new NWayAssocSetChach.NWayAssociateSetChache<string, TestPerson, long>(2, 5, algo);
            cache.Put("petrov", new TestPerson("petrov", "Петров П.П."));
            cache.Put("ivanov", new TestPerson("ivanov", "Иванов И.И."));
            cache.Put("sidorov", new TestPerson("sidorov", "Сидоров С.С."));
        }
        [Test]
        public void TestMethodGet()
        {
            TestPerson person = new TestPerson("petrov", "Петров П.П.");
            Assert.That(cache.Get("petrov").Equals(person));
        }
      

        [Test]
        public void TestMethodGetNull()
        {
            Assert.That(cache.Get("kilian") == null);
        }




    }
}
