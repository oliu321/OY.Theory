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
        public int VisitedTime { get; set; }
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
            foreach (var v in graph)
            {
                if (v.Color == DepthFirstSearchVertexColor.WHITE)
                {
                    stack.Push(v);
                    while(!stack.IsEmpty())
                    {
                        var w = stack.Pop();
                        if (w.Color == DepthFirstSearchVertexColor.WHITE)
                        {
                            w.Color = DepthFirstSearchVertexColor.GRAY;
                            foreach (var e in w.AdjacentVertexEdges)
                            {
                                if (e.Destination.Color == DepthFirstSearchVertexColor.WHITE)
                                {
                                    e.Destination.ParentLabel = w.Label;
                                    stack.Push(e.Destination);
                                }
                            }
                        }
                        else
                        {
                            // Has to be GRAY
                            w.Color = DepthFirstSearchVertexColor.BLACK;                            
                        }
                    }
                }
            }
        }
    }
}
