using OY.Theory.DataStructures.Queue;
using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

    public class BreadthFirstSearchVertexMarkedAsGrayEventArgs
    {
        public BreadthFirstSearchVertex Vertex { get; protected set;} 
        public BreadthFirstSearchEdge Edge { get; protected set;}
        public BreadthFirstSearchVertexMarkedAsGrayEventArgs(BreadthFirstSearchVertex vertex, BreadthFirstSearchEdge edge)
        {
            this.Vertex = vertex;
            this.Edge = edge;
        }
    }

    public class BreadthFirstSearchVertexMarkedAsBlackEventArgs
    {
        public BreadthFirstSearchVertex Vertex { get; protected set; }
        public BreadthFirstSearchVertexMarkedAsBlackEventArgs(BreadthFirstSearchVertex vertex)
        {
            this.Vertex = vertex;
        }
    }
    public class BreadthFirstSearchAlgorithm
    {
        public event EventHandler<BreadthFirstSearchVertexMarkedAsGrayEventArgs> VertexMarkedAsGray;
        public event EventHandler<BreadthFirstSearchVertexMarkedAsBlackEventArgs> VertexMarkedAsWhite;
        protected void OnVertexMarkedAsGray(BreadthFirstSearchVertexMarkedAsGrayEventArgs e)
        {
            EventHandler<BreadthFirstSearchVertexMarkedAsGrayEventArgs> temp = Volatile.Read(ref this.VertexMarkedAsGray);
            if(temp != null)
                temp(this, e);
        }
        protected void OnVertexMarkedAsBlack(BreadthFirstSearchVertexMarkedAsBlackEventArgs e)
        {
            EventHandler<BreadthFirstSearchVertexMarkedAsBlackEventArgs> temp = Volatile.Read(ref this.VertexMarkedAsWhite);
            if (temp != null)
                temp(this, e);
        }
        public void Run(BreadthFirstSearchVertex[] graph)
        {
            IQueue<BreadthFirstSearchVertex> queue = new ResizingArrayQueue<BreadthFirstSearchVertex>(graph.Length);
            foreach (var v in graph)
            {
                if (v.Color == BreadthFirstSearchVertexColor.WHITE)
                {
                    v.Color = BreadthFirstSearchVertexColor.GRAY;
                    OnVertexMarkedAsGray(new BreadthFirstSearchVertexMarkedAsGrayEventArgs(v, null));
                    queue.Enqueue(v);
                    while(!queue.IsEmpty())
                    {
                        var w = queue.Dequeue();
                        if (w.AdjacentVertexEdges != null)
                        {
                            foreach (var e in w.AdjacentVertexEdges)
                            {
                                var otherEnd = e.Source == w ? e.Destination : e.Source;
                                if (otherEnd.Color == BreadthFirstSearchVertexColor.WHITE)
                                {
                                    otherEnd.ParentLabel = w.Label;
                                    otherEnd.Distance = w.Distance + 1;
                                    otherEnd.Color = BreadthFirstSearchVertexColor.GRAY;
                                    OnVertexMarkedAsGray(new BreadthFirstSearchVertexMarkedAsGrayEventArgs(w, e));
                                    queue.Enqueue(otherEnd);
                                }
                            }
                        }

                        w.Color = BreadthFirstSearchVertexColor.BLACK;
                        OnVertexMarkedAsBlack(new BreadthFirstSearchVertexMarkedAsBlackEventArgs(w));
                    }
                }
            }
        }
    }
}
