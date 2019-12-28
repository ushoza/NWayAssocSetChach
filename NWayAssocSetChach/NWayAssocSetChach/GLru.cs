using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class GLru : IGenericAlgo<long>
    {
        public int GetRemoveIndex(long[] ms)
        {
            int lruIndex = 0;
            long lruTimestamp = ms[0];
            for (int i = 0; i < ms.Length; i++)
            {
                long currentTimestamp = ms[i];
                if (lruTimestamp > currentTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }

        public long GetReplacementMark(long prevMark)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
    }
}
