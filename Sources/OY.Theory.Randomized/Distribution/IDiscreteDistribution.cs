using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized.Distribution
{
    public interface IDiscreteDistribution
    {
        int Max { get;}
        double[] Distribution { get; }
        int Sample();
    }
}
