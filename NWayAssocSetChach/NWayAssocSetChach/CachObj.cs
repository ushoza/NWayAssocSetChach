using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class CacheObj<T,V, M>
    {
        public int Id { get; private set; }
        public T Key { get; private set; }
        public V Value { get; set; }
        public M Mark { get; set; }

        public CacheObj(T key, V value, M mark)
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
