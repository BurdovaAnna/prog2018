using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void TestThreeElements()
        {
            //Добавление трёх элементов, поиск трёх элементов
            var hashTable = new HashTable.HashTable(3);

            hashTable.PutPair(1, "aaa");
            hashTable.PutPair(2, "bbb");
            hashTable.PutPair(3, "ccc");

            Assert.AreEqual(hashTable.GetValueByKey(1), "aaa");
            Assert.AreEqual(hashTable.GetValueByKey(2), "bbb");
            Assert.AreEqual(hashTable.GetValueByKey(3), "ccc");
        }

        [TestMethod]
        public void TestEqualElements()
        {
            //Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
            var hashTable = new HashTable.HashTable(2);

            hashTable.PutPair(1, "aaa");
            hashTable.PutPair(1, "bbb");

            Assert.AreEqual(hashTable.GetValueByKey(1), "bbb");
        }

        [TestMethod]
        public void Test10000Elements()
        {
            //Добавление 10000 элементов в структуру и поиск одного из них
            var hashTable = new HashTable.HashTable(10000);

            for (var i = 0; i < 10000; i++)
                hashTable.PutPair(i, "a" + i);

            Assert.AreEqual(hashTable.GetValueByKey(100), "a100");
        }

        [TestMethod]
        public void TestNotAddedKeys()
        {
            //Добавление 10000 элементов в структуру и поиск 1000 недобавленных ключей, поиск которых должен вернуть null
            var hashTable = new HashTable.HashTable(10000);

            for (var i = 0; i < 10000; i++)
                hashTable.PutPair(i, "a" + i);

            for (var i = 10000; i < 11000; i++)
                Assert.AreEqual(hashTable.GetValueByKey(i), null);
        }
    }
}