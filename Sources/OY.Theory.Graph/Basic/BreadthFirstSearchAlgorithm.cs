using OY.Theory.DataStructures.Queue;
using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Graph.Basic
{
    public enum BreadthFirstSearchVertexColor
    {
        WHITE,
        GRAY,
        BLACK,
    }
    public class BreadthFirstSearchVertex
    {
        public int Label { get; set; }
        public BreadthFirstSearchEdge[] AdjacentVertexEdges { get; set; }
        public BreadthFirstSearchVertexColor Color { get; set; }
        public int Distance { get; set; }
        public int ParentLabel { get; set; }
    }
    public class BreadthFirstSearchEdge : IEdge<BreadthFirstSearchVertex>
    {
        public BreadthFirstSearchVertex Source { get; set; }

        public BreadthFirstSearchVertex Destination { get; set; }
    }
    public static class BreadthFirstSearchAlgorithm
    {
        public static void Run(BreadthFirstSearchVertex[] graph)
        {
            IQueue<BreadthFirstSearchVertex> queue = new ResizingArrayQueue<BreadthFirstSearchVertex>(graph.Length);
            foreach (var v in graph)
            {
                if (v.Color == BreadthFirstSearchVertexColor.WHITE)
                {
                    v.Color = BreadthFirstSearchVertexColor.GRAY;
                    queue.Enqueue(v);
                    while(!queue.IsEmpty())
                    {
                        var w = queue.Dequeue();
                        foreach (var e in w.AdjacentVertexEdges)
                        {
                            var otherEnd = e.Source == w ? e.Destination : e.Source;
                            if (otherEnd.Color == BreadthFirstSearchVertexColor.WHITE)
                            {
                                otherEnd.ParentLabel = w.Label;
                                otherEnd.Distance = w.Distance + 1;
                                otherEnd.Color = BreadthFirstSearchVertexColor.GRAY;
                                queue.Enqueue(otherEnd);
                            }
                        }

                        w.Color = BreadthFirstSearchVertexColor.BLACK;
                    }
                }
            }
        }
    }
}
