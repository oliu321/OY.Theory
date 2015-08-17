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
            //IStack<DepthFirstSearchVertex> stack = new ;            
            //stack.Push(graph[0]);
        }
    }
}
