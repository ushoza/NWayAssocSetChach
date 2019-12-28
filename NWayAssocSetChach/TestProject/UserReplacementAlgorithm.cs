using NWayAssocSetChach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProject
{
    public class UserReplacementAlgorithm : ICacheChangeAlgorithm
    {
        public int GetEvictedIndex(int startIndex, int endIndex, CacheObj[] CacheMemory)
        {
            int lruIndex = startIndex;
            int lruTimestamp = CacheMemory[startIndex].AD == null ? 0 : (int)CacheMemory[startIndex].AD;
            for (int i = startIndex; i <= endIndex; i++)
            {
                int currentTimestamp = CacheMemory[i].AD == null ? 0 : (int)CacheMemory[i].AD;
                if (currentTimestamp < lruTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }

        public object GetReplasmentMark(CacheObj cachObj)
        {
            
            if(cachObj.AD is int)
            {
                int res = (int)cachObj.AD + 1;
                return res;
            }
            else if(cachObj.AD == null)
            {
                return 0;
            }
            else
            {
                return cachObj.AD;
            }
            
        }
    }
}
