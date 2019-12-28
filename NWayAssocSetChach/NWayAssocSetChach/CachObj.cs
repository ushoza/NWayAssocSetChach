using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    //public class CacheObj
    //{

    //    public int Id { get; private set; }
    //    public object Key { get; private set; }
    //    public object Data { get; private set; }
    //    public object AD { get;  set; }
    //    public bool IsEmpty { get; private set; }

    //    public CacheObj()
    //    {
    //        IsEmpty = true;
    //        Id = 0;
    //        Data = null;
    //        AD = 0;
    //    }

    //    public CacheObj(object key, object data, object ad, int id)
    //    {
    //        Key = key;
    //        Data = data;
    //        AD = ad;
    //        IsEmpty = false;
    //        Id = id;
    //    }
    //}
    public class CacheObj<T,V>
    {
        public int Id { get; private set; }
        public T Key { get; private set; }
        public V Value { get; set; }
        public object Mark { get; set; }

        public CacheObj(T key, V value, object mark)
        {
            Id = Math.Abs(key.GetHashCode());
            Key = key;
            Value = value;
            Mark = mark;
        }
        public CacheObj()
        {
                        
        }
    }
}
