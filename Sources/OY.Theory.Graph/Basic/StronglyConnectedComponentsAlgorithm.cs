using OY.Theory.DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Graph.Basic
{
    public class StronglyConnectedComponentsAlgorithmVertex : DepthFirstSearchVertex
    {
        public int ComponentId { get; set; }
    }
    public static class StronglyConnectedComponentsAlgorithm
    {
        public static void Run(StronglyConnectedComponentsAlgorithmVertex[] graph)
        {
            var stack = new ResizingArrayStack<StronglyConnectedComponentsAlgorithmVertex>();
            var dfs1 = new DepthFirstSearchAlgorithm();
            dfs1.DoReverse = true;
            dfs1.VertexMarkedAsBlack += (s, e) => { stack.Push((StronglyConnectedComponentsAlgorithmVertex) e.Vertex); };
            dfs1.Run(graph);
            for (int i = 0; i < graph.Length; ++i)
            {
                graph[i] = stack.Pop();
                graph[i].Color = DepthFirstSearchVertexColor.WHITE;
            }

            var dfs2 = new DepthFirstSearchAlgorithm();
            int componentId = 0;
            dfs2.StartingNewComponent += 
                (s, e) => {
                    ++componentId;
                };
            dfs2.VertexMarkedAsBlack += (s, e) => { 
                ((StronglyConnectedComponentsAlgorithmVertex)e.Vertex).ComponentId = componentId; 
            };
            dfs2.Run(graph);
        }
    }
}
