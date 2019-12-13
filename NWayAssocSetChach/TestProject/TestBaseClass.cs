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
        //ICacheChangeAlgorithm algo;
        NWayAssociateSetChach cache;

        [SetUp]
        public void Init()
        {
           // algo = new LRUreplacementAlgorithm();
            cache = new NWayAssociateSetChach(EnumAlgorithms.LRU, 3, 8);
            TestPerson person = new TestPerson("petrov", "Петров П.П.");
            cache.Put(person.NickName, person);
            person = new TestPerson("sidorov", "Сидоров П.П.");
            cache.Put(person.NickName, person);
        }
        [Test]
        public void TestMethodPutGet()
        {
            TestPerson person = new TestPerson("SomeNickname", "Иванов И.И.");
            cache.Put(person.NickName, person);
            Assert.That(cache.Get("SomeNickname").Equals(person));
        }
      

        [Test]
        public void TestMethodGetNull()
        {
            Assert.That(cache.Get("kilian") == null);
        }




    }
}
