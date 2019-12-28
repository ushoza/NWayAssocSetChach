using NWayAssocSetChach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProject
{
    
    public class UserReplacementAlgorithm : IGenericAlgo<int>
    {
        
        public int GetRemoveIndex(int[] ms)
        {
            int lruIndex = 0;
            int lruTimestamp = ms[0];
            for (int i = 0; i < ms.Length; i++)
            {
                int currentTimestamp = ms[i];
                if (currentTimestamp < lruTimestamp)
                {
                    lruIndex = i;
                    lruTimestamp = currentTimestamp;
                }
            }
            return lruIndex;
        }


        public int GetReplacementMark(int prevMark)
        {
          int res = prevMark + 1;
          return res;
           
           
        }
    }
}
