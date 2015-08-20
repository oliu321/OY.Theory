using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.Graph.Basic;

namespace OY.Theory.Graph.Tests
{
    [TestClass]
    public class StronglyConnectedComponentsTests
    {
        [TestMethod]
        public void TestStronglyConnectedComponentsAlgorithm()
        {
            var a = new StronglyConnectedComponentsAlgorithmVertex { Label = 1, };
            var b = new StronglyConnectedComponentsAlgorithmVertex { Label = 2, };
            var c = new StronglyConnectedComponentsAlgorithmVertex { Label = 3, };
            var d = new StronglyConnectedComponentsAlgorithmVertex { Label = 4, };
            var e = new StronglyConnectedComponentsAlgorithmVertex { Label = 5, };
            var f = new StronglyConnectedComponentsAlgorithmVertex { Label = 6, };
            var g = new StronglyConnectedComponentsAlgorithmVertex { Label = 7, };
            var h = new StronglyConnectedComponentsAlgorithmVertex { Label = 8, };
            var edges = new DepthFirstSearchEdge[]
            {
                new DepthFirstSearchEdge { Source = a, Destination = b },
                new DepthFirstSearchEdge { Source = b, Destination = c },
                new DepthFirstSearchEdge { Source = c, Destination = d },
                new DepthFirstSearchEdge { Source = d, Destination = c },
                new DepthFirstSearchEdge { Source = e, Destination = f },
                new DepthFirstSearchEdge { Source = f, Destination = g },
                new DepthFirstSearchEdge { Source = g, Destination = f },
                new DepthFirstSearchEdge { Source = g, Destination = h },
                new DepthFirstSearchEdge { Source = h, Destination = h },
                new DepthFirstSearchEdge { Source = e, Destination = a },
                new DepthFirstSearchEdge { Source = b, Destination = e },
                new DepthFirstSearchEdge { Source = b, Destination = f },
                new DepthFirstSearchEdge { Source = c, Destination = g },
                new DepthFirstSearchEdge { Source = d, Destination = h },
            };
            var graph = new StronglyConnectedComponentsAlgorithmVertex[] { a, b, c, d, e, f, g, h };
            DepthFirstSearchAlgorithm.GenerateGraph(graph, edges);
            StronglyConnectedComponentsAlgorithm.Run(graph);

            Assert.AreEqual(a.ComponentId, b.ComponentId);
            Assert.AreEqual(a.ComponentId, e.ComponentId);
            Assert.AreEqual(f.ComponentId, g.ComponentId);
            Assert.AreEqual(c.ComponentId, d.ComponentId);

            Assert.AreNotEqual(e.ComponentId, f.ComponentId);
            Assert.AreNotEqual(e.ComponentId, c.ComponentId);
            Assert.AreNotEqual(e.ComponentId, h.ComponentId);

            Assert.AreNotEqual(d.ComponentId, g.ComponentId);
            Assert.AreNotEqual(d.ComponentId, h.ComponentId);

            Assert.AreNotEqual(f.ComponentId, h.ComponentId);

            foreach(var v in graph)
            {
                Assert.IsTrue(a.ComponentId >= 1 && a.ComponentId <= 4);
            }
        }
    }
}
