using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class CachObj
    {
        public object Id { get; private set; }
        public object Data { get; private set; }
        public object AD { get; private set; }

        public CachObj()
        {
            Id = 0;
            Data = null;
            AD = 0;
        }

        public CachObj(object id, object data, object ad)
        {
            Id = id;
            Data = data;
            AD = ad;
        }
    }
}
