using NWayAssocSetChach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserNWayAssociateSetChach:NWayAssociateSetChach
    {
        public UserNWayAssociateSetChach(int setCount, int rowCount, EnumAlgorithms algorithm) : base(algorithm, setCount, rowCount)
        {
            
        }
        public override int customReplacementAlgo(int startIndex, int endIndex)
        {
            int lruIndex = startIndex;
            int lruTimestamp = CacheMemory[startIndex].ReplacementMark == null ? 0 : (int)CacheMemory[startIndex].ReplacementMark;
            for (int i = startIndex; i <= endIndex; i++)
            {
                int currentTimestamp = CacheMemory[i].ReplacementMark == null ? 0 : (int)CacheMemory[i].ReplacementMark;
                if (currentTimestamp < lruTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }
        public override object GetReplasmentMark(CachObj cachObj)
        {
            if (cachObj.ReplacementMark is int)
            {
                int res = (int)cachObj.ReplacementMark + 1;
                return res;
            }
            else if (cachObj.ReplacementMark == null)
            {
                return 0;
            }
            else
            {
                return cachObj.ReplacementMark;
            }
        }
    }
}
