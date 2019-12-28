using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public  interface IAlgorithm
    {
        int GetRemoveIndex(object[] ms);
        object GetReplacementMark(object prevMark);
    }
}
