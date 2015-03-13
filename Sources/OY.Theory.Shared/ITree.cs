using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    public interface ITree<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
    }
}
