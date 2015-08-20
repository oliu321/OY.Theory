﻿using OY.Theory.Shared;
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

    public class DepthFirstSearchVertexMarkedAsGrayEventArgs
    {
        public DepthFirstSearchVertex Vertex { get; protected set; }
        public DepthFirstSearchEdge Edge { get; protected set; }
        public DepthFirstSearchVertexMarkedAsGrayEventArgs(DepthFirstSearchVertex vertex, DepthFirstSearchEdge edge)
        {
            this.Vertex = vertex;
            this.Edge = edge;
        }
    }

    public class DepthFirstSearchVertexMarkedAsBlackEventArgs
    {
        public DepthFirstSearchVertex Vertex { get; protected set; }
        public DepthFirstSearchVertexMarkedAsBlackEventArgs(DepthFirstSearchVertex vertex)
        {
            this.Vertex = vertex;
        }
    }
    public class DepthFirstSearchAlgorithm
    {
        public static void GenerateGraph(DepthFirstSearchVertex[] vertices, DepthFirstSearchEdge[] edges)
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
        protected void OnVertexMarkedAsGray(DepthFirstSearchVertexMarkedAsGrayEventArgs e)
        {
            EventHandler<DepthFirstSearchVertexMarkedAsGrayEventArgs> temp = Volatile.Read(ref this.VertexMarkedAsGray);
            if (temp != null)
                temp(this, e);
        }
        protected void OnVertexMarkedAsBlack(DepthFirstSearchVertexMarkedAsBlackEventArgs e)
        {
            EventHandler<DepthFirstSearchVertexMarkedAsBlackEventArgs> temp = Volatile.Read(ref this.VertexMarkedAsBlack);
            if (temp != null)
                temp(this, e);
        }

        public void Run(DepthFirstSearchVertex[] graph)
        {
            IStack<DepthFirstSearchVertex> stack = new ResizingArrayStack<DepthFirstSearchVertex>(graph.Length);
            int time = 0;
            foreach (var v in graph)
            {
                if (v.Color == DepthFirstSearchVertexColor.WHITE)
                {
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
