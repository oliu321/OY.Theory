using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.Graph.Basic;

namespace OY.Theory.Graph.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void TestDFS()
        {
            var u = new DepthFirstSearchVertex { Label = 1, };
            var v = new DepthFirstSearchVertex { Label = 2, };
            var w = new DepthFirstSearchVertex { Label = 3, };
            var x = new DepthFirstSearchVertex { Label = 4, };
            var y = new DepthFirstSearchVertex { Label = 5, };
            var z = new DepthFirstSearchVertex { Label = 6, };
            var edge1 = new DepthFirstSearchEdge { Source = u, Destination = v, };
            var edge2 = new DepthFirstSearchEdge { Source = u, Destination = x, };
            var edge3 = new DepthFirstSearchEdge { Source = v, Destination = y, };
            var edge4 = new DepthFirstSearchEdge { Source = x, Destination = v, };
            var edge5 = new DepthFirstSearchEdge { Source = y, Destination = x, };
            var edge6 = new DepthFirstSearchEdge { Source = w, Destination = y, };
            var edge7 = new DepthFirstSearchEdge { Source = w, Destination = z, };
            var edge8 = new DepthFirstSearchEdge { Source = z, Destination = z, };
            u.AdjacentVertexEdges = new DepthFirstSearchEdge[] { edge1, edge2 };
            v.AdjacentVertexEdges = new DepthFirstSearchEdge[] { edge1, edge3, edge4 };
            w.AdjacentVertexEdges = new DepthFirstSearchEdge[] { edge6, edge7 };
            x.AdjacentVertexEdges = new DepthFirstSearchEdge[] { edge2, edge4, edge5 };
            y.AdjacentVertexEdges = new DepthFirstSearchEdge[] { edge3, edge5, edge6 };
            z.AdjacentVertexEdges = new DepthFirstSearchEdge[] { edge7, edge8 };
            var graph = new DepthFirstSearchVertex[]
            {
                u, v, w, x, y, z
            };

            DepthFirstSearchAlgorithm.Run(graph);

            Assert.AreEqual(1, u.DiscoverTime);
            Assert.AreEqual(8, u.FinishTime);
            Assert.AreEqual(0, u.ParentLabel);

            Assert.AreEqual(2, v.DiscoverTime);
            Assert.AreEqual(7, v.FinishTime);
            Assert.AreEqual(1, v.ParentLabel);

            Assert.AreEqual(9, w.DiscoverTime);
            Assert.AreEqual(12, w.FinishTime);
            Assert.AreEqual(0, w.ParentLabel);

            Assert.AreEqual(4, x.DiscoverTime);
            Assert.AreEqual(5, x.FinishTime);
            Assert.AreEqual(5, x.ParentLabel);

            Assert.AreEqual(3, y.DiscoverTime);
            Assert.AreEqual(6, y.FinishTime);
            Assert.AreEqual(2, y.ParentLabel);

            Assert.AreEqual(10, z.DiscoverTime);
            Assert.AreEqual(11, z.FinishTime);
            Assert.AreEqual(3, z.ParentLabel);
        }
    }
}
