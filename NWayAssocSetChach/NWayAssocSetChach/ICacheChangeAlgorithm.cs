using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public interface ICacheChangeAlgorithm
    {
        void GetRemoveIndex(object[] ways, ref int wayIndex, ref int rowSetIndex);
            
    }
}
