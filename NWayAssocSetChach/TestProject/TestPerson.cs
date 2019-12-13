using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TestPerson
    {
        public string NickName { get; private set; }
        private string password;
        public string FullName { get; private set; }

        public TestPerson(string nickName, string fullName)
        {
            NickName = nickName;
            FullName = fullName;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            if(obj is TestPerson)
            {
                TestPerson testPerson = (TestPerson)obj;
                if (this.NickName == testPerson.NickName && this.password == testPerson.password && this.FullName == testPerson.FullName)
                    res = true;
            }
            return res;
            

        }
    }
}
