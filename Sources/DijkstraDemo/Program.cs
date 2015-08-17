using OY.Theory.Graph.ShortestPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 
                //int.Parse(args[0]);
                200;
            string Path = 
                //args[1];
                "dijkstraData.txt";
            DijkstraVertex[] graph = new DijkstraVertex[n];
            for (int i = 0; i < n; ++i)
                graph[i] = new DijkstraVertex{Label = i + 1};

            var lines = File.ReadLines(Path).ToArray();
            foreach(var line in lines)
            {
                var parts = line.Split('\t');
                int label = int.Parse(parts[0]);
                List<DijkstraEdge> edges = new List<DijkstraEdge>();
                for (int i = 1; i < parts.Length; ++i)
                {
                    if (string.IsNullOrEmpty(parts[i])) continue;
                    var subparts = parts[i].Split(',');
                    edges.Add(
                    new DijkstraEdge{
                        Source = graph[label - 1],
                        Destination = graph[int.Parse(subparts[0]) - 1],
                        Weight = int.Parse(subparts[1]),
                    });
                }

                graph[label - 1].AdjacentVertexEdges = edges.ToArray();
            }

            var result = DijkstraAlgorithm.Run(graph, graph[0]);
            var result2 = string.Join(",", "7,37,59,82,99,115,133,165,188,197".Split(',').Select(s => result[int.Parse(s)].ToString()).ToArray());
            Console.WriteLine(result2);

            //foreach(var item in result2)
            //{
            //    Console.WriteLine("{0}: {1}", keyvalue.Key, keyvalue.Value);
            //}
        }
    }
}
