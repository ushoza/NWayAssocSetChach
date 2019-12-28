using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public  interface IAlgorithm<M>
    {
        int GetRemoveIndex();
        M GetReplacementMark(M m);
        
        

    }
}
