using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class MRUreplacementAlgorithm : ICacheChangeAlgorithm
    {
        public int GetEvictedIndex(int startIndex, int endIndex, CacheObj[] CacheMemory)
        {
            int mruIndex = startIndex;
            long mruTimestamp = (long)CacheMemory[startIndex].AD;
            for (int i = startIndex; i <= endIndex; i++)
            {
                long currentTimestamp = (long)CacheMemory[i].AD;
                if (mruTimestamp < currentTimestamp)
                {
                    mruIndex = i;
                    mruTimestamp = currentTimestamp;
                }
            }
            return mruIndex;
        }

        public object GetReplasmentMark(CacheObj cachObj)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
    }
}
