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
            IAlgorithm algo = new LRUreplacementAlgorithm();
            NWayAssociateSetChache<string, TestPerson> cache = new NWayAssociateSetChache<string, TestPerson>(2, 4, algo);
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
            IAlgorithm algo = new MRUreplacementAlgorithm();
            NWayAssociateSetChache<string, TestPerson> cache = new NWayAssociateSetChache<string, TestPerson>(2, 4, algo);
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
            IAlgorithm algo = new UserReplacementAlgorithm();
            NWayAssociateSetChache<string, TestPerson> cache = new NWayAssociateSetChache<string, TestPerson>(2, 4, algo);
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
