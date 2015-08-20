using OY.Theory.Graph.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OY.Theory.Graph.Basic;
using OY.Theory.DataStructures.Heap;
using OY.Theory.Shared;

namespace SCCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertices = new StronglyConnectedComponentsAlgorithmVertex[875714];
            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices[i] = new OY.Theory.Graph.Basic.StronglyConnectedComponentsAlgorithmVertex
                {
                    Label = i + 1,
                };
            }
            System.IO.StreamReader file = new System.IO.StreamReader("SCC.txt");
            string line = null;
            List<DepthFirstSearchEdge> edges = new List<DepthFirstSearchEdge>();
            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(' ');
                edges.Add(new OY.Theory.Graph.Basic.DepthFirstSearchEdge
                    {
                        Source = vertices[int.Parse(parts[0]) - 1],
                        Destination = vertices[int.Parse(parts[1]) - 1],
                    });
            }
            DepthFirstSearchAlgorithm.GenerateGraph(vertices, edges);

            var scc = new StronglyConnectedComponentsAlgorithm();
            var heap = new BinaryHeap<int>(new ReverseComparer2<int>());
            int currentComponentVerticesCount = 0;
            scc.StartingNewComponent += (s, e) => { heap.Insert(currentComponentVerticesCount); currentComponentVerticesCount = 0; };
            scc.AddedVertexToComponent += (s, e) => { ++currentComponentVerticesCount; };
            scc.Run(vertices);
            int[] result = new int[5];
            for (int i = 0; i < 5; ++i)
                result[i] = heap.ExtractMin();
            Console.WriteLine(string.Join(",", result));
        }
    }
}
