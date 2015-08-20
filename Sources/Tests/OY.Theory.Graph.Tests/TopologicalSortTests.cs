using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.Graph.Basic;

namespace OY.Theory.Graph.Tests
{
    [TestClass]
    public class TopologicalSortTests
    {
        [TestMethod]
        public void TestTopologicalSort()
        {
            var u = new DepthFirstSearchVertex { Label = 1 };
            var p = new DepthFirstSearchVertex { Label = 2 };
            var b = new DepthFirstSearchVertex { Label = 3 };
            var s = new DepthFirstSearchVertex { Label = 4 };
            var t = new DepthFirstSearchVertex { Label = 5 };
            var j = new DepthFirstSearchVertex { Label = 6 };
            var so = new DepthFirstSearchVertex { Label = 7 };
            var sh = new DepthFirstSearchVertex { Label = 8 };
            var w = new DepthFirstSearchVertex { Label = 9 };
            var edges = new DepthFirstSearchEdge[]
            {
            new DepthFirstSearchEdge { Source = u, Destination = p },
            new DepthFirstSearchEdge { Source = p, Destination = b },
            new DepthFirstSearchEdge { Source = u, Destination = sh },
            new DepthFirstSearchEdge { Source = p, Destination = sh },
            new DepthFirstSearchEdge { Source = s, Destination = b },
            new DepthFirstSearchEdge { Source = s, Destination = t },
            new DepthFirstSearchEdge { Source = t, Destination = j },
            new DepthFirstSearchEdge { Source = so, Destination = sh },
            new DepthFirstSearchEdge { Source = b, Destination = j },
            };
            var graph = new DepthFirstSearchVertex[] { u, p, b, s, t, j, so, sh, w};
            DepthFirstSearchAlgorithm.GenerateGraph(graph, edges);
            TopologicalSortAlgorithm.Run(graph);
            foreach(var e in edges)
            {
                int sindex = 0;
                while(sindex != graph.Length)
                {
                    if (e.Source.Label == graph[sindex++].Label)
                        break;
                }

                int dindex = 0;
                while (dindex != graph.Length)
                {
                    if (e.Destination.Label == graph[dindex++].Label)
                        break;
                }

                Assert.IsTrue(sindex < dindex);
            }
        }
    }
}

