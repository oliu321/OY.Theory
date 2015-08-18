using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized.Distribution
{
    public class SystemRandomGenerator : IRandomGenerator
    {
        private Random r;
        public SystemRandomGenerator()
        {
            this.r = new Random();
        }
        public int Next(int maxValue)
        {
            return this.r.Next(maxValue);
        }
    }
}
