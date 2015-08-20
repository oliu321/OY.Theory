using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized.Distribution
{
    public class UniformDiscreteDistribution : IDiscreteDistribution
    {
        private int max;
        private IRandomGenerator rand;
        public UniformDiscreteDistribution(int max, IRandomGenerator rand)
        {
            this.max = max;
            this.rand = rand;
            if (this.rand == null)
                this.rand = new DefaultRandomGenerator();
        }

        public int Max
        {
            get { return this.max; }
        }

        public double[] Distribution
        {
            get 
            {
                double[] result = new double[this.max];
                for (int i = 0; i < this.max; ++i)
                    result[i] = 1.0 / (double)this.max;
                return result;
            }
        }

        public int Sample()
        {
            return this.rand.Next(this.max);
        }
    }
}
