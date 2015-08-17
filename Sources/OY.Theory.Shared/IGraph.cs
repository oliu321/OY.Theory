using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    public interface IGraph<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
        bool IsDirected { get; }
        bool IsMulti { get; }

        TVertex[] GetAllVertex();
        int GetVertexCount();
        TEdge GetEdge(TVertex source, TVertex destination);
    }
}
