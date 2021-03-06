﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class LRUreplacementAlgorithm : ICacheChangeAlgorithm
    {
        public int GetEvictedIndex(int startIndex, int endIndex, CachObj[] CacheMemory)
        {
            int lruIndex = startIndex;
            long lruTimestamp = (long)CacheMemory[startIndex].AD;
            for (int i = startIndex; i <= endIndex; i++)
            {
                long currentTimestamp = (long)CacheMemory[i].AD;
                if (lruTimestamp > currentTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }

        public object GetReplasmentMark(CachObj cachObj)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
    }
}
