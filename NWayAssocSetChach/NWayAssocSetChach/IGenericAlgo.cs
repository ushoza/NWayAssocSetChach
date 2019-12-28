using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public interface IGenericAlgo<T>
    {
        int GetRemoveIndex(T[] ms);
        T GetReplacementMark(T prevMark);
    }
}
