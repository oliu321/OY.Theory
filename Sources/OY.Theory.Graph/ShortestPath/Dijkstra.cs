/// <copyright file="Dijkstra.cs" company="Integration Co, Inc.">
///     Copyrights: ©2015   Integration Co, Inc. (DBA Finivation Software)
/// </copyright>
/// <author>Ou</author>

using OY.Theory.DataStructures.Heap;
using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Graph.ShortestPath
{
    public class DijkstraVertex
    {
        public int Label { get; set; }
        public DijkstraEdge[] AdjacentVertexEdges { get; set; }

        public DijkstraInfo Info { get; set; }
    }

    public class DijkstraEdge : IEdge<DijkstraVertex>
    {
        public int Weight { get; set; }

        public DijkstraVertex Source {get;set;}

        public DijkstraVertex Destination {get;set;}
    }
    public class DijkstraInfo : IComparable<DijkstraInfo>, IHeapLocation
    {
        public int HeapLocation { get; set; }
        public int CurrentShortestPathLength { get; set; }
        public DijkstraVertex Vertex { get; set; }

        public bool Visited { get; set; }

        public int CompareTo(DijkstraInfo other)
        {
            return this.CurrentShortestPathLength - other.CurrentShortestPathLength;
        }
    }

    public static class DijkstraAlgorithm
    {
        

        public static Dictionary<int, int> Run(DijkstraVertex[] graph, DijkstraVertex source)
        {
            int n = graph.Count();
            Dictionary<int, int> distances = new Dictionary<int, int>();
            BinaryHeap2<DijkstraInfo> heap = new BinaryHeap2<DijkstraInfo>();
            foreach (DijkstraVertex v in graph)
            {
                var node = new DijkstraInfo
                        {
                            Vertex = v,
                        };
                v.Info = node;

                if (v.Label == source.Label)
                {
                    node.CurrentShortestPathLength = 0;
                    node.HeapLocation = heap.InsertAndReturnLocation(node);
                }
                else
                {
                    node.CurrentShortestPathLength = int.MaxValue;
                    foreach(var e in source.AdjacentVertexEdges)
                    {
                        if (e.Destination.Label == source.Label)
                        {
                            node.CurrentShortestPathLength = e.Weight;
                            break;
                        }
                    }
                    
                    node.HeapLocation = heap.InsertAndReturnLocation(node);
                }
            }

            for (int i = 0; i < n; ++i)
            {
                var node = heap.ExtractMin();
                node.Visited = true;
                distances[node.Vertex.Label] = node.CurrentShortestPathLength;
                if (node.Vertex.AdjacentVertexEdges != null)
                {
                    foreach (var e in node.Vertex.AdjacentVertexEdges)
                    {
                        if (!e.Destination.Info.Visited && e.Destination.Info.CurrentShortestPathLength > node.CurrentShortestPathLength + e.Weight)
                        {
                            e.Destination.Info.CurrentShortestPathLength = node.CurrentShortestPathLength + e.Weight;
                            heap.DecreaseValue(e.Destination.Info.HeapLocation);
                        }
                    }
                }
            }

            return distances;
        }
    }
}