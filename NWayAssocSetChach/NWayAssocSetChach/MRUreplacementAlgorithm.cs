using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    //public class MRUreplacementAlgorithm : ICacheChangeAlgorithm
    //{
    //    public int GetEvictedIndex(int startIndex, int endIndex, CacheObj[] CacheMemory)
    //    {
    //        int mruIndex = startIndex;
    //        long mruTimestamp = (long)CacheMemory[startIndex].AD;
    //        for (int i = startIndex; i <= endIndex; i++)
    //        {
    //            long currentTimestamp = (long)CacheMemory[i].AD;
    //            if (mruTimestamp < currentTimestamp)
    //            {
    //                mruIndex = i;
    //                mruTimestamp = currentTimestamp;
    //            }
    //        }
    //        return mruIndex;
    //    }

    //    public object GetReplasmentMark(CacheObj cachObj)
    //    {
    //        long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    //        return milliseconds;
    //    }
    //}

    public class MRUreplacementAlgorithm : IAlgorithm
    {
        public int GetRemoveIndex(object[] ms)
        {
            int mruIndex = 0;
            long mruTimestamp = (long)ms[0];
            for (int i = 0; i < ms.Length; i++)
            {
                long currentTimestamp = (long)ms[i];
                if (mruTimestamp < currentTimestamp)
                {
                    mruIndex = i;
                    mruTimestamp = currentTimestamp;
                }
            }
            return mruIndex;
        }

        public object GetReplacementMark(object m)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
    }
}
