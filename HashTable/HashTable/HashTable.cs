using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable
    {
        class HashEntry
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        List<List<HashEntry>> list;

        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            list = new List<List<HashEntry>>();
            for (var i = 0; i < size; i++)
                list.Add(new List<HashEntry>());
        }

        /// 
        /// Метод складывающий пару ключь-значение в таблицу
        /// 
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var bucketNo = GetBucketNumber(key);
            foreach (var item in list[bucketNo])
            {
                if (Equals(item.Key, key))
                {
                    item.Value = value;
                    return;
                }
            }
            list[bucketNo].Add(new HashEntry { Key = key, Value = value });
        }
        private int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }

        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствуетreturns>
        public object GetValueByKey(object key)
        {
            var bucketNo = GetBucketNumber(key);
            foreach (var item in list[bucketNo])
            {
                if (Equals(item.Key, key))
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}

