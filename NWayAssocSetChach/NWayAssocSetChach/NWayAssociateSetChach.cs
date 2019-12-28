using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class NWayAssociateSetChache<T,V,M> 
    {
        CacheObj<T, V, M>[,] cacheMemory;
        //IAlgorithm algorithm;
        IGenericAlgo<M> algorithm;
        int rows;
        int cols;
        public NWayAssociateSetChache(int cols, int rows, IGenericAlgo<M> algorithm)
        {
            this.algorithm = algorithm;
            cacheMemory = new CacheObj<T, V, M>[rows, cols];
            this.rows = rows;
            this.cols = cols;

        }

        public V Get(T key)
        {
            int id = Math.Abs(key.GetHashCode());
            int r = GetRow(id);
            V res = default(V);
            for (int i = 0; i < cols; i++)
            {
                if (cacheMemory[r,i]?.Id == id)
                {
                    res= cacheMemory[r, i].Value;
                    break;
                }
            }
            return res;
        }
        public void Put(T key, V value)
        {
            int id = Math.Abs(key.GetHashCode());
            int r = GetRow(id);
            bool IsFound = false;
            for (int i = 0; i < cols; i++)
            {
                if (cacheMemory[r, i]?.Id == id)
                {
                    IsFound = true;
                    //cacheMemory[r, i].Mark = algorithm.GetReplacementMark(cacheMemory[r, i].Mark);
                    cacheMemory[r, i].Mark = algorithm.GetReplacementMark(cacheMemory[r, i].Mark);
                    cacheMemory[r, i].Value = value;
                }
                
            }
            bool isFoundFreePlace = false;
            if (!IsFound)
            {
                for (int i = 0; i < cols; i++)
                {
                    if (cacheMemory[r, i] == null)
                    {
                        isFoundFreePlace = true;
                        cacheMemory[r, i] = new CacheObj<T, V, M>(key, value, default(M));
                        cacheMemory[r, i].Mark = algorithm.GetReplacementMark(cacheMemory[r, i].Mark);
                    }
                }
            }
            if(!isFoundFreePlace)
            {
                M[] ms = new M[cols];
                for (int i = 0; i < cols; i++)
                {
                    ms[i] = cacheMemory[r, i].Mark;
                }
                int removeIndex = algorithm.GetRemoveIndex(ms);
                cacheMemory[r, removeIndex] = new CacheObj<T, V, M>(key, value, default(M));
                cacheMemory[r, removeIndex].Mark = algorithm.GetReplacementMark(cacheMemory[r, removeIndex].Mark);
            }
        }

        private int GetRow(int id)
        {
            return id % rows;
        }
    }

    
}
