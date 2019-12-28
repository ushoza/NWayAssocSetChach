using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class LRUreplacementAlgorithm : IAlgorithm
    {
        public int GetRemoveIndex(object[] ms)
        {
            int lruIndex = 0;
            long lruTimestamp = (long)ms[0];
            for (int i = 0; i < ms.Length; i++)
            {
                long currentTimestamp = (long)ms[i];
                if (lruTimestamp > currentTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }


        object IAlgorithm.GetReplacementMark(object m)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }

    }
}
