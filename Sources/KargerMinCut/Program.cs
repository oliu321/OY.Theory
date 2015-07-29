using OY.Theory.Combinatorics;
using OY.Theory.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargerMinCut
{
    class Program
    {

        static int KargerAlgorithm(int[,] graph, int size)
        {
            var ds = new DisjointSets<int>();
            var vertices = new Dictionary<int, DisjointSets<int>.DisjointTreeNode>();
            var edgeToVertices = new Dictionary<int, Tuple<DisjointSets<int>.DisjointTreeNode, DisjointSets<int>.DisjointTreeNode>>();

            // reading in the graph            
            for (int i = 0; i < size; ++i)
            {
                vertices.Add(i, ds.MakeSet(i));
            }
            int edgeCount = 0;
            for (int i = 0; i < size; ++i )
            {
                for (int j = i + 1; j < size; ++j)
                {
                    if (graph[i, j] == 1)
                    {
                        edgeToVertices.Add(edgeCount++, new Tuple<DisjointSets<int>.DisjointTreeNode, DisjointSets<int>.DisjointTreeNode>(vertices[i], vertices[j]));
                    }
                }
            }

            // random permute the edges, then based on the permutation contract vertices
            var edges = PermutationGenerator.GenerateRandomPermutation(edgeCount);
            int components = size;
            int cutSize = 0;
            foreach (int e in edges)
            {
                var vertex_pair = edgeToVertices[e];
                if (components > 2)
                {
                    if (!ds.IsInSameSet(vertex_pair.Item1, vertex_pair.Item2))
                    {
                        ds.Union(vertex_pair.Item1, vertex_pair.Item2);
                        --components;
                    }
                }
                else
                {
                    if (!ds.IsInSameSet(vertex_pair.Item1, vertex_pair.Item2))
                    {
                        ++cutSize;
                    }
                }
            }

            return cutSize;
        }
        static void Main(string[] args)
        {
            var adjacentGraph = File.ReadLines(args[0]).Where(s => !string.IsNullOrWhiteSpace(s)).Select(l => l.Split('\t').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => int.Parse(s) - 1).ToArray()).ToArray();
            var graph = new int[adjacentGraph.Count(), adjacentGraph.Count()];
            for (int i = 0; i < adjacentGraph.Count(); ++i)
            {
                for (int j = 1; j < adjacentGraph[i].Length; ++j)
                {
                    graph[i, adjacentGraph[i][j]] = graph[adjacentGraph[i][j], i] = 1;
                }
            }

            int minCutSize = int.MaxValue;
            for (int i = 0; i < (adjacentGraph.Count() * adjacentGraph.Count() * adjacentGraph.Count()); ++i)
            {
                int cutSize = KargerAlgorithm(graph, adjacentGraph.Count());
                if (cutSize < minCutSize)
                    minCutSize = cutSize;
            }
            
            Console.WriteLine("Min cut size is {0}", minCutSize);
        }
    }
}
