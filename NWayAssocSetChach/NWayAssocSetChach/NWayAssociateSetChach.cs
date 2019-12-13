using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class NWayAssociateSetChach
    {
        public readonly CachObj[] CacheMemory;
        public readonly ICacheChangeAlgorithm replacementAlgo;
        private readonly int setCount;
        private readonly int entryCount;

        public NWayAssociateSetChach(ICacheChangeAlgorithm changeAlgorithm, int setCount, int rowInSetCount)
        {
            this.setCount = setCount;
            this.entryCount = rowInSetCount;
            this.replacementAlgo = changeAlgorithm;
            CacheMemory = new CachObj[this.setCount * this.entryCount];
            Clear();
        }

        public virtual int GetHash(object key)
        {
            return key.GetHashCode();
        }
        /// <summary>
        /// Получить данные из кеша
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Object Get(object key)
        {
            //Пустые поля
            Object data = null;
            int emptyIndex = 0;
            Boolean isSingleEntryEmpty = false;
            Boolean cacheUpdated = false;

            //Получить Id и на его основании кусок массива в котором искать
            int ID = GetHash(key);
            int startIndex = GetStartIndex(ID);
            int endIndex = GetEndIndex(startIndex);



            for (int i = startIndex; i <= endIndex; i++)
            {
                // Если нашлась пустая строка в массиве, запомнить ее
                if (CacheMemory[i].IsEmpty && !isSingleEntryEmpty)
                {
                    emptyIndex = i;
                    isSingleEntryEmpty = true;
                    continue;
                }

                // Если нашлись данные, то обновить метку времени обращения
                if (CacheMemory[i].Id == ID)
                {
                    data = CacheMemory[i].Data;
                    CacheMemory[i].AD = replacementAlgo.GetTimeStamp();
                    cacheUpdated = true;
                    break;
                }
            }

            // Если есть свободные строки в наборе, пометить кеш обновленным
            if (isSingleEntryEmpty)
            {
                cacheUpdated = true;
            }

            // Если кеш не был обновлен, значит все строки заняты, почистить строку
            if (!cacheUpdated)
            {
                int evictedIndex = replacementAlgo.GetEvictedIndex(startIndex, endIndex);
                CacheMemory[evictedIndex] = new CachObj();
            }

            return data;
        }
        /// <summary>
        /// Положить данные в кеш
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(object key, object value)
        {
            //Initializing fields
            int emptyIndex = 0;
            Boolean isSingleEntryEmpty = false;
            Boolean cacheUpdated = false;
            //Получить промежуток массива на основе Id
            int ID = GetHash(key);
            int startIndex = GetStartIndex(ID);
            int endIndex = GetEndIndex(startIndex);

            CachObj newCacheEntry = new CachObj(key, value, replacementAlgo.GetTimeStamp(), ID);

            for (int i = startIndex; i <= endIndex; i++)
            {

                // Определить есть ли свободная строка в этом промежутке 
                if (CacheMemory[i].IsEmpty && !isSingleEntryEmpty)
                {
                    emptyIndex = i;
                    isSingleEntryEmpty = true;
                    continue;
                }

                // Обновить данные в кеше
                if (CacheMemory[i].Id == ID)
                {
                    CacheMemory[i] = newCacheEntry;
                    cacheUpdated = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

            // Если не нашли еще объект в кеше и есть пуста строка, то положить объект в пустую строку
            if (isSingleEntryEmpty && !cacheUpdated)
            {
                CacheMemory[emptyIndex] = newCacheEntry;
                cacheUpdated = true;
            }

            // Если кеш не был обновлен, значит все строки заняты, почистить строку и положить туда объект
            if (!cacheUpdated)
            {
                int evictedIndex = replacementAlgo.GetEvictedIndex(startIndex, endIndex);
                CacheMemory[evictedIndex] = newCacheEntry;
            }
        }
        /// <summary>
        /// Очистить кеш
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < CacheMemory.Length; i++)
            {
                CacheMemory[i] = new CachObj();
            }
        }

        private int GetStartIndex(int ID)
        {
            return (ID % setCount) * entryCount;
        }

        
        private int GetEndIndex(int startIndex)
        {
            return startIndex + entryCount - 1;
        }

    }
}
