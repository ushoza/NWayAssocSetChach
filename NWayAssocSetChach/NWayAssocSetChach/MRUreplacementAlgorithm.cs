using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
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
