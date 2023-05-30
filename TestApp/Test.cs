using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Test
    {
        private long testID;
        private string name;

        public Test(long testID, string name)
        {
            this.TestID = testID;
            this.Name = name;
        }

        public long TestID { get => testID; set => testID = value; }
        public string Name { get => name; set => name = value; }
    }
}
