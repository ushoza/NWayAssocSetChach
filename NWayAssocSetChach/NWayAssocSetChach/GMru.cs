using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class GMru : IGenericAlgo<long>
    {
        public int GetRemoveIndex(long[] ms)
        {
            int mruIndex = 0;
            long mruTimestamp = ms[0];
            for (int i = 0; i < ms.Length; i++)
            {
                long currentTimestamp = ms[i];
                if (mruTimestamp < currentTimestamp)
                {
                    mruIndex = i;
                    mruTimestamp = currentTimestamp;
                }
            }
            return mruIndex;
        }

        public long GetReplacementMark(long prevMark)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
    }
}
