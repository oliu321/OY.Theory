using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OY.Theory.DataStructures.Stack;
using System.Threading;
using OY.Theory.DataStructures.Queue;

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

    public class DepthFirstSearchVertexMarkedAsGrayEventArgs : EventArgs
    {
        public DepthFirstSearchVertex Vertex { get; protected set; }
        public DepthFirstSearchEdge Edge { get; protected set; }
        public DepthFirstSearchVertexMarkedAsGrayEventArgs(DepthFirstSearchVertex vertex, DepthFirstSearchEdge edge)
        {
            this.Vertex = vertex;
            this.Edge = edge;
        }
    }

    public class DepthFirstSearchVertexMarkedAsBlackEventArgs : EventArgs
    {
        public DepthFirstSearchVertex Vertex { get; protected set; }
        public DepthFirstSearchVertexMarkedAsBlackEventArgs(DepthFirstSearchVertex vertex)
        {
            this.Vertex = vertex;
        }
    }

    public class DepthFirstSearchVertexStartingNewComponentEventArgs : EventArgs
    {
        public DepthFirstSearchVertex Vertex { get; protected set; }
        public DepthFirstSearchVertexStartingNewComponentEventArgs(DepthFirstSearchVertex vertex)
        {
            this.Vertex = vertex;
        }
    }
    public class DepthFirstSearchAlgorithm
    {
        public bool DoReverse { get; set; }
        public static void GenerateGraph(DepthFirstSearchVertex[] vertices, IEnumerable<DepthFirstSearchEdge> edges)
        {
            foreach(var v in vertices)
            {
                ResizingArrayQueue<DepthFirstSearchEdge> adjacent_edges = new ResizingArrayQueue<DepthFirstSearchEdge>();
                foreach(var e in edges)
                {
                    if (e.Source == v || e.Destination == v)
                    {
                        adjacent_edges.Enqueue(e);
                    }
                }
                v.AdjacentVertexEdges = adjacent_edges.ToArray();
            }
        }

        public event EventHandler<DepthFirstSearchVertexMarkedAsGrayEventArgs> VertexMarkedAsGray;
        public event EventHandler<DepthFirstSearchVertexMarkedAsBlackEventArgs> VertexMarkedAsBlack;
        public event EventHandler<DepthFirstSearchVertexStartingNewComponentEventArgs> StartingNewComponent;
        protected void OnVertexMarkedAsGray(DepthFirstSearchVertexMarkedAsGrayEventArgs e)
        {
            e.Raise(this, ref this.VertexMarkedAsGray);
        }
        protected void OnVertexMarkedAsBlack(DepthFirstSearchVertexMarkedAsBlackEventArgs e)
        {
            e.Raise(this, ref this.VertexMarkedAsBlack);
        }
        protected void OnStartingNewComponent(DepthFirstSearchVertexStartingNewComponentEventArgs e)
        {
            e.Raise(this, ref this.StartingNewComponent);
        }

        public void Run(DepthFirstSearchVertex[] graph)
        {
            IStack<DepthFirstSearchVertex> stack = new ResizingArrayStack<DepthFirstSearchVertex>(graph.Length);
            int time = 0;
            foreach (var v in graph)
            {
                if (v.Color == DepthFirstSearchVertexColor.WHITE)
                {
                    OnStartingNewComponent(new DepthFirstSearchVertexStartingNewComponentEventArgs(v));
                    v.Color = DepthFirstSearchVertexColor.GRAY;
                    v.DiscoverTime = ++time;
                    OnVertexMarkedAsGray(new DepthFirstSearchVertexMarkedAsGrayEventArgs(v, null));
                    stack.Push(v);
                    while(!stack.IsEmpty())
                    {
                        var w = stack.Peek();
                        bool hasAChild = false;
                        if (w.AdjacentVertexEdges != null)
                        {
                            foreach (var e in w.AdjacentVertexEdges)
                            {
                                if (this.DoReverse)
                                {
                                    if (e.Destination == w && e.Source.Color == DepthFirstSearchVertexColor.WHITE)
                                    {
                                        e.Source.ParentLabel = w.Label;
                                        e.Source.DiscoverTime = ++time;
                                        e.Source.Color = DepthFirstSearchVertexColor.GRAY;
                                        OnVertexMarkedAsGray(new DepthFirstSearchVertexMarkedAsGrayEventArgs(w, e));
                                        stack.Push(e.Source);
                                        hasAChild = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (e.Source == w && e.Destination.Color == DepthFirstSearchVertexColor.WHITE)
                                    {
                                        e.Destination.ParentLabel = w.Label;
                                        e.Destination.DiscoverTime = ++time;
                                        e.Destination.Color = DepthFirstSearchVertexColor.GRAY;
                                        OnVertexMarkedAsGray(new DepthFirstSearchVertexMarkedAsGrayEventArgs(w, e));
                                        stack.Push(e.Destination);
                                        hasAChild = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if(!hasAChild)
                        {
                            stack.Pop();
                            w.Color = DepthFirstSearchVertexColor.BLACK;
                            OnVertexMarkedAsBlack(new DepthFirstSearchVertexMarkedAsBlackEventArgs(w));
                            w.FinishTime = ++time;
                        }
                    }
                }
            }
        }
    }
}
