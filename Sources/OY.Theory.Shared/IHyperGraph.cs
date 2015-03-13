using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    public interface IHyperGraph<TVertex, THyperEdge> where THyperEdge : IHyperEdge<TVertex>
    {
        bool IsMulti { get; }
    }
}
