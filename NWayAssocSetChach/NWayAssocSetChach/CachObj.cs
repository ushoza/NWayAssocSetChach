using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class CachObj
    {

        public int Id { get; private set; }
        public object Key { get; private set; }
        public object Data { get; private set; }
        public object ReplacementMark { get;  set; }
        public bool IsEmpty { get; private set; }

        public CachObj()
        {
            IsEmpty = true;
            Id = 0;
            Data = null;
            ReplacementMark = 0;
        }

        public CachObj(object key, object data, object rm, int id)
        {
            Key = key;
            Data = data;
            ReplacementMark = rm;
            IsEmpty = false;
            Id = id;
        }
    }
}
