using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OY.Theory.DataStructures.Stack;

namespace OY.Theory.Graph.Basic
{
    public enum DepthFirstSearchVertexColor
    {
        WHITE,
        GRAY,
        BLACK,
    }
    public class DepthFirstSearchVertex
    {
        public int Label { get; set; }
        public DepthFirstSearchEdge[] AdjacentVertexEdges { get; set; }
        public DepthFirstSearchVertexColor Color { get; set; }

        public int DiscoverTime { get; set; }
        public int FinishTime { get; set; }
        public int ParentLabel { get; set; }
    }
    public class DepthFirstSearchEdge : IEdge<DepthFirstSearchVertex>
    {
        public DepthFirstSearchVertex Source {get;set;}

        public DepthFirstSearchVertex Destination {get;set;}
    }
    public static class DepthFirstSearchAlgorithm
    {

        public static void Run(DepthFirstSearchVertex[] graph)
        {
            IStack<DepthFirstSearchVertex> stack = new ResizingArrayStack<DepthFirstSearchVertex>(graph.Length);
            int time = 0;
            foreach (var v in graph)
            {
                if (v.Color == DepthFirstSearchVertexColor.WHITE)
                {
                    v.Color = DepthFirstSearchVertexColor.GRAY;
                    v.DiscoverTime = ++time;
                    stack.Push(v);
                    while(!stack.IsEmpty())
                    {
                        var w = stack.Peek();
                        int newNodeCnt = 0;
                        foreach (var e in w.AdjacentVertexEdges)
                        {
                            if (e.Source == w && e.Destination.Color == DepthFirstSearchVertexColor.WHITE)
                            {
                                e.Destination.ParentLabel = w.Label;
                                e.Destination.DiscoverTime = ++time;
                                e.Destination.Color = DepthFirstSearchVertexColor.GRAY;
                                stack.Push(e.Destination);
                                ++newNodeCnt;
                                break;
                            }
                        }

                        if(newNodeCnt == 0)
                        {
                            stack.Pop();
                            w.Color = DepthFirstSearchVertexColor.BLACK;
                            w.FinishTime = ++time;
                        }
                    }
                }
            }
        }
    }
}
