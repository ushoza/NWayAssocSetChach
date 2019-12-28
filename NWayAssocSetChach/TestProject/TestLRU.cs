using NUnit.Framework;
using NWayAssocSetChach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class TestAlgorithms
    {
        [Test]
        public void TestMethodDelLastAdded()
        {
            IGenericAlgo<long> algo = new GLru();
            NWayAssociateSetChache<string, TestPerson, long> cache = new NWayAssociateSetChache<string, TestPerson, long>(2, 4, algo);
            TestPerson personIvanov = new TestPerson("ivanov", "Иванов И.И.");
            cache.Put(personIvanov.NickName, personIvanov);
            System.Threading.Thread.Sleep(50);
            TestPerson personPetrov = new TestPerson("petrov", "Петров П.П.");
            cache.Put(personPetrov.NickName, personPetrov);
            System.Threading.Thread.Sleep(50);
            TestPerson personSidorov = new TestPerson("sidorov", "Сидоров П.П.");
            cache.Put(personSidorov.NickName, personSidorov);
            Assert.That(cache.Get("ivanov") == null);
            Assert.That(cache.Get("petrov").Equals(personPetrov));
            Assert.That(cache.Get("sidorov").Equals(personSidorov));

        }

        [Test]
        public void TestMethodDelResentAdded()
        {
            IGenericAlgo<long> algo = new GMru();
            NWayAssociateSetChache<string, TestPerson, long> cache = new NWayAssociateSetChache<string, TestPerson, long>(2, 4, algo);
            TestPerson personIvanov = new TestPerson("ivanov", "Иванов И.И.");
            cache.Put(personIvanov.NickName, personIvanov);
            System.Threading.Thread.Sleep(50);
            TestPerson personPetrov = new TestPerson("petrov", "Петров П.П.");
            cache.Put(personPetrov.NickName, personPetrov);
            System.Threading.Thread.Sleep(50);
            TestPerson personSidorov = new TestPerson("sidorov", "Сидоров П.П.");
            cache.Put(personSidorov.NickName, personSidorov);
            Assert.That(cache.Get("ivanov").Equals(personIvanov));
            Assert.That(cache.Get("petrov") == null);
            Assert.That(cache.Get("sidorov").Equals(personSidorov));

        }

        [Test]
        public void TestUserAlgorithm()
        {
            IGenericAlgo<int> algo = new UserReplacementAlgorithm();
            NWayAssociateSetChache<string, TestPerson, int> cache = new NWayAssociateSetChache<string, TestPerson, int>(2, 4, algo);
            TestPerson personIvanov = new TestPerson("ivanov", "Иванов И.И.");
            cache.Put(personIvanov.NickName, personIvanov);
            System.Threading.Thread.Sleep(50);
            TestPerson personPetrov = new TestPerson("petrov", "Петров П.П.");
            cache.Put(personPetrov.NickName, personPetrov);
            System.Threading.Thread.Sleep(50);
            cache.Get("ivanov");
            TestPerson personSidorov = new TestPerson("sidorov", "Сидоров П.П.");
            cache.Put(personSidorov.NickName, personSidorov);
            Assert.That(cache.Get("ivanov").Equals(personIvanov));
            Assert.That(cache.Get("petrov") == null);
            Assert.That(cache.Get("sidorov").Equals(personSidorov));

        }

    }
}
