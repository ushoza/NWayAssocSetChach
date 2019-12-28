using NWayAssocSetChach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProject
{
    
    public class UserReplacementAlgorithm : IAlgorithm
    {
        public int GetRemoveIndex(object[] ms)
        {
            int lruIndex = 0;
            int lruTimestamp = (int)ms[0];
            for (int i = 0; i < ms.Length; i++)
            {
                int currentTimestamp = (int)ms[i];
                if (currentTimestamp < lruTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }

        public object GetReplacementMark(object prevMark)
        {
            if (prevMark is int)
            {
                int res = (int)prevMark + 1;
                return res;
            }
            else if (prevMark == null)
            {
                return 0;
            }
            else
            {
                return prevMark;
            }
        }
    }
}
