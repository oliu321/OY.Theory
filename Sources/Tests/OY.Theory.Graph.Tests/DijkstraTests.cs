using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.Graph.ShortestPath;

namespace OY.Theory.Graph.Tests
{
    [TestClass]
    public class DijkstraTests
    {
        [TestMethod]
        public void TestSingleNode()
        {
            DijkstraVertex[] graph = new DijkstraVertex[1];
            graph[0] = new DijkstraVertex
            {
                Label = 1
            };

            var distances = DijkstraAlgorithm.Run(graph, graph[0]);
            Assert.AreEqual(1, distances.Count);
            Assert.AreEqual(0, distances[1]);
        }

        [TestMethod]
        public void TestTwoNodes()
        {
            DijkstraVertex[] graph = new DijkstraVertex[2];
            graph[0] = new DijkstraVertex
            {
                Label = 1
            };
            graph[1] = new DijkstraVertex
            {
                Label = 2
            };
            graph[0].AdjacentVertexEdges = new DijkstraEdge[] { new DijkstraEdge { Source = graph[0], Destination = graph[1], Weight = 7 } };

            var distances = DijkstraAlgorithm.Run(graph, graph[0]);
            Assert.AreEqual(2, distances.Count);
            Assert.AreEqual(0, distances[1]);
            Assert.AreEqual(7, distances[2]);
        }

        [TestMethod]
        public void TestAGraph()
        {
            DijkstraVertex[] graph = new DijkstraVertex[5];
            for (int i = 0; i < 5; ++i)
                graph[i] = new DijkstraVertex { Label = i + 1 };
            graph[0].AdjacentVertexEdges = new DijkstraEdge[]
            {
                new DijkstraEdge
                {
                    Source = graph[0],
                    Destination = graph[1],
                    Weight = 10,
                },
                new DijkstraEdge
                {
                    Source = graph[0],
                    Destination = graph[3],
                    Weight = 5,
                },
            };
            graph[1].AdjacentVertexEdges = new DijkstraEdge[]
            {
                new DijkstraEdge
                {
                    Source = graph[1],
                    Destination = graph[2],
                    Weight = 1,
                },
                new DijkstraEdge
                {
                    Source = graph[1],
                    Destination = graph[3],
                    Weight = 2,
                },
            };
            graph[2].AdjacentVertexEdges = new DijkstraEdge[]
            {
                new DijkstraEdge
                {
                    Source = graph[2],
                    Destination = graph[4],
                    Weight = 4,
                },                
            };
            graph[3].AdjacentVertexEdges = new DijkstraEdge[]
            {
                new DijkstraEdge
                {
                    Source = graph[3],
                    Destination = graph[4],
                    Weight = 2,
                },
                new DijkstraEdge
                {
                    Source = graph[3],
                    Destination = graph[1],
                    Weight = 3,
                },
                new DijkstraEdge
                {
                    Source = graph[3],
                    Destination = graph[2],
                    Weight = 9,
                },
            };
            graph[4].AdjacentVertexEdges = new DijkstraEdge[]
            {
                new DijkstraEdge
                {
                    Source = graph[4],
                    Destination = graph[0],
                    Weight = 7,
                },
                new DijkstraEdge
                {
                    Source = graph[4],
                    Destination = graph[2],
                    Weight = 6,
                },                
            };

            var distances = DijkstraAlgorithm.Run(graph, graph[0]);
            Assert.AreEqual(5, distances.Count);
            Assert.AreEqual(0, distances[1]);
            Assert.AreEqual(8, distances[2]);
            Assert.AreEqual(9, distances[3]);
            Assert.AreEqual(5, distances[4]);
            Assert.AreEqual(7, distances[5]);
        }
    }
}
