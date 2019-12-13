using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class NWayAssociateSetChach
    {
        public readonly CachObj[] CacheMemory;
        public readonly EnumAlgorithms replacementAlgo;
        private readonly int setCount;
        private readonly int entryCount;

        public NWayAssociateSetChach(EnumAlgorithms changeAlgorithm, int setCount, int rowInSetCount)
        {
            this.setCount = setCount;
            this.entryCount = rowInSetCount;
            this.replacementAlgo = changeAlgorithm;
            CacheMemory = new CachObj[this.setCount * this.entryCount];
            Clear();
        }

        public virtual int GetHash(object key)
        {
            return Math.Abs(key.GetHashCode());
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
            
            //Получить Id и на его основании кусок массива в котором искать
            int ID = GetHash(key);
            int startIndex = getStartIndex(ID);
            int endIndex = getEndIndex(startIndex);



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
                    CacheMemory[i].ReplacementMark = GetReplasmentMark(CacheMemory[i]);
                    
                    break;
                }
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
            int emptyIndex = 0;
            Boolean isSingleEntryEmpty = false;
            Boolean cacheUpdated = false;
            //Получить промежуток массива на основе Id
            int ID = GetHash(key);
            int startIndex = getStartIndex(ID);
            int endIndex = getEndIndex(startIndex);

            CachObj newCacheEntry = new CachObj(key, value, null, ID);
            newCacheEntry.ReplacementMark = GetReplasmentMark(newCacheEntry);

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
                int evictedIndex = getRemoveIndex(startIndex, endIndex);
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

        private int getStartIndex(int ID)
        {
            return (ID % setCount) * entryCount;
        }

        
        private int getEndIndex(int startIndex)
        {
            return startIndex + entryCount - 1;
        }

        private int getRemoveIndex(int startIndex, int endIndex)
        {
            switch (replacementAlgo)
            {
                case EnumAlgorithms.LRU:
                    return lruReplacementAlgo(startIndex, endIndex);
                    
                case EnumAlgorithms.MRU:
                    return mruReplacementAlgo(startIndex, endIndex);
                    
                case EnumAlgorithms.Castom:
                    return CustomReplacementAlgo(startIndex, endIndex);
                    
                default:
                    throw new NotSupportedException("Unsupported Replacement alogorithm usage.");
                    
            }
           
        }

        private int lruReplacementAlgo(int startIndex, int endIndex)
        {
            int lruIndex = startIndex;
            long lruTimestamp = (long)CacheMemory[startIndex].ReplacementMark;
            for (int i = startIndex; i <= endIndex; i++)
            {
                long currentTimestamp = (long)CacheMemory[i].ReplacementMark;
                if (lruTimestamp > currentTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }

        private int mruReplacementAlgo(int startIndex, int endIndex)
        {
            int mruIndex = startIndex;
            long mruTimestamp = (long)CacheMemory[startIndex].ReplacementMark;
            for (int i = startIndex; i <= endIndex; i++)
            {
                long currentTimestamp = (long)CacheMemory[i].ReplacementMark;
                if (mruTimestamp < currentTimestamp)
                {
                    mruIndex = i;
                    mruTimestamp = currentTimestamp;
                }
            }
            return mruIndex;
        }

        public virtual int CustomReplacementAlgo(int startIndex, int endIndex)
        {
            return mruReplacementAlgo(startIndex, endIndex);
        }

        private long getCurrentTime()
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }

        public virtual object GetReplasmentMark(CachObj cachObj)
        {
            return getCurrentTime();
        }

    }
}
