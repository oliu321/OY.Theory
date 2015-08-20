using OY.Theory.DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Graph.Basic
{
    public static class TopologicalSortAlgorithm
    {
        public static void Run(DepthFirstSearchVertex[] graph)
        {
            var stack = new ResizingArrayStack<DepthFirstSearchVertex>();
            var dfs = new DepthFirstSearchAlgorithm();
            dfs.VertexMarkedAsBlack += (s, e) => { stack.Push(e.Vertex); };
            dfs.Run(graph);
            for (int i = 0; i < graph.Length; ++i)
            {
                graph[i] = stack.Pop();
            }
        }
    }
}
