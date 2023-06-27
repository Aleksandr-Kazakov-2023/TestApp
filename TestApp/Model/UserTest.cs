using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class UserTest : Test
    {
        private double score;
        private bool isComplete;
        public override double Score { get; set; }
        public override bool IsComplete { get; set; }

        public UserTest(long testID, string name, double score, bool isComplete) : base(testID, name)
        {
            this.Score = score;
            this.IsComplete = isComplete;
        }
    }
}
