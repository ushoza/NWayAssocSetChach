using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWayAssocSetChach
{
    public class NWayAssociateSetChach
    {
        public CachObj[][] CachMemory { get; private set; }

        private ICacheChangeAlgorithm changeAlgorithm;
        private int rowSetCount;
        private int waysCount;

        public NWayAssociateSetChach(ICacheChangeAlgorithm changeAlgorithm, int waysCount, int rowSetCount)
        {
            CachMemory = new CachObj[rowSetCount][];
            for (int i = 0; i < rowSetCount; i++)
            {
                CachMemory[i] = new CachObj[waysCount];
            }
            this.changeAlgorithm = changeAlgorithm;
            this.rowSetCount = rowSetCount;
            this.waysCount = waysCount;
        }

        public NWayAssociateSetChach(ICacheChangeAlgorithm changeAlgorithm)
        {
            CachMemory = new CachObj[8][];
            for (int i = 0; i < 8; i++)
            {
                CachMemory[i] = new CachObj[2];
            }
            
            this.changeAlgorithm = changeAlgorithm;
            this.rowSetCount = 8;
            this.waysCount = 2;
        }

        public virtual int GetHash(object key)
        {
            string input = key.ToString();
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            return BitConverter.ToInt32(hash, 0);
        }
        public Object Get(object key)
        {

        }

        public void Put(object key, object value)
        {

        }

        public void Clear()
        {
            for (int i = 0; i < CachMemory.Length; i++)
            {
                CachMemory[i] = new CachObj();
            }
        }
    }
}
