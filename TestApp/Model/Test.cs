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
        private List<Question> questions = new List<Question>();

        public virtual double Score { get; set; }
        public virtual bool IsComplete { get; set; }

        public Test(long testID, string name)
        {
            this.TestID = testID;
            this.Name = name;
        }

        public Test()
        {

        }

        public long TestID { get => testID; set => testID = value; }
        public string Name { get => name; set => name = value; }
        public List<Question> Questions { get => questions; set => questions = value; }
    }
}
