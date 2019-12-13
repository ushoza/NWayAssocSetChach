using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public interface ICacheChangeAlgorithm
    {
        int GetEvictedIndex(int startIndex, int endIndex);
        object GetTimeStamp();
    }
}
