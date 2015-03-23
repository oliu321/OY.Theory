using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OY.Theory.DataStructures.Tests
{
    [TestClass]
    public class DisjointSetsTests
    {
        [TestMethod]
        public void TestNormalOperations()
        {
            var disjointSets = new DisjointSets<string>();
            var nodeA = disjointSets.MakeSet("a");
            var nodeB = disjointSets.MakeSet("b");
            var nodeC = disjointSets.MakeSet("c");
            var nodeD = disjointSets.MakeSet("d");
            var nodeE = disjointSets.MakeSet("e");

            Assert.IsFalse(disjointSets.IsInSameSet(nodeA, nodeB));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeB, nodeC));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeC, nodeD));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeD, nodeE));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeE, nodeA));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeA, nodeD));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeD, nodeB));

            disjointSets.Union(nodeA, nodeB);
            disjointSets.Union(nodeA, nodeC);
            disjointSets.Union(nodeB, nodeC);
            disjointSets.Union(nodeD, nodeE);

            Assert.IsTrue(disjointSets.IsInSameSet(nodeA, nodeB));
            Assert.IsTrue(disjointSets.IsInSameSet(nodeB, nodeC));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeC, nodeD));
            Assert.IsTrue(disjointSets.IsInSameSet(nodeD, nodeE));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeE, nodeA));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeA, nodeD));
            Assert.IsFalse(disjointSets.IsInSameSet(nodeD, nodeB));
        }
    }
}
