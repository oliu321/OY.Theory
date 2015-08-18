using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.Shared;
using OY.Theory.DataStructures.Heap;
using OY.Theory.Randomized;

namespace OY.Theory.DataStructures.Tests
{
    [TestClass]
    public class BinaryHeap2Tests
    {
        public class IntHeapNode : IComparable<IntHeapNode>, IHeapLocation
        {
            public int Value { get; set; }
            public int HeapLocation {get;set;}

            public IntHeapNode(int value)
            {
                this.Value = value;
            }

            public int CompareTo(IntHeapNode other)
            {
                return this.Value - other.Value;
            }
        }
        [TestMethod]
        public void TestBinaryHeap2Creation()
        {
            var heap = new BinaryHeap2<IntHeapNode>();
            Assert.AreEqual(0, heap.Count());
            heap = new BinaryHeap2<IntHeapNode>(6);
            Assert.AreEqual(0, heap.Count());
            heap = new BinaryHeap2<IntHeapNode>(new IntHeapNode[] { new IntHeapNode(1), new IntHeapNode(2), new IntHeapNode(3), new IntHeapNode(4), new IntHeapNode(5), new IntHeapNode(6) });
            Assert.AreEqual(6, heap.Count());            
        }

        [TestMethod]
        public void TestBinaryHeap2Insert()
        {
            var heap = new BinaryHeap2<IntHeapNode>(6);
            heap.Insert(new IntHeapNode(1));
            heap.Insert(new IntHeapNode(2));
            heap.Insert(new IntHeapNode(3));
            heap.Insert(new IntHeapNode(4));
            heap.Insert(new IntHeapNode(5));
            heap.Insert(new IntHeapNode(6));
            heap.Insert(new IntHeapNode(7));
            Assert.AreEqual(7, heap.Count()); 
        }

        [TestMethod]
        public void TestBinaryHeap2General()
        {
            var heap = new BinaryHeap2<IntHeapNode>(6);
            heap.Insert(new IntHeapNode(7));
            heap.Insert(new IntHeapNode(6));
            heap.Insert(new IntHeapNode(5));
            heap.Insert(new IntHeapNode(4));
            heap.Insert(new IntHeapNode(3));
            heap.Insert(new IntHeapNode(2));
            heap.Insert(new IntHeapNode(1));
            Assert.AreEqual(7, heap.Count());
            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(4, heap.ExtractMin().Value);
            Assert.AreEqual(5, heap.ExtractMin().Value);
            Assert.AreEqual(6, heap.ExtractMin().Value);
            Assert.AreEqual(7, heap.ExtractMin().Value);
            Assert.AreEqual(0, heap.Count());

            heap = new BinaryHeap2<IntHeapNode>(new IntHeapNode[] { new IntHeapNode(3), new IntHeapNode(5), new IntHeapNode(7), new IntHeapNode(2), new IntHeapNode(1), new IntHeapNode(6), new IntHeapNode(4) });
            Assert.AreEqual(7, heap.Count());
            Assert.AreEqual(1, heap.ExtractMin().Value);
            Assert.AreEqual(2, heap.ExtractMin().Value);
            Assert.AreEqual(3, heap.ExtractMin().Value);
            Assert.AreEqual(4, heap.ExtractMin().Value);
            Assert.AreEqual(5, heap.ExtractMin().Value);
            Assert.AreEqual(6, heap.ExtractMin().Value);
            Assert.AreEqual(7, heap.ExtractMin().Value);
            Assert.AreEqual(0, heap.Count());
        }

        [TestMethod]
        public void TestBinaryHeap2GeneralUsingRandom()
        {
            int[] data = RandomShuffleAlgorithm.GenerateRandomIntArray(23);
            IntHeapNode[] theData = new IntHeapNode[23];
            for (int i = 0; i < 23; ++i)
            {
                theData[i] = new IntHeapNode(i);
            }
            var heap = new BinaryHeap2<IntHeapNode>(theData);
            for (int i = 0; i < 23; ++i)
            {
                Assert.AreEqual(i, heap.ExtractMin().Value);
            }
            Assert.AreEqual(0, heap.Count());
        }

        [TestMethod]
        public void TestBinaryHeap2DecreaseValue()
        {
            var heap = new BinaryHeap2<IntHeapNode>();
            var node1 = new IntHeapNode(7);
            heap.Insert(node1);
            Assert.AreEqual(0, node1.HeapLocation);
            var node2 = new IntHeapNode(6);
            heap.Insert(node2);
            Assert.AreEqual(0, node2.HeapLocation);
            Assert.AreEqual(1, node1.HeapLocation);
            var node3 = new IntHeapNode(5);
            heap.Insert(node3);
            Assert.AreEqual(0, node3.HeapLocation);
            Assert.AreEqual(1, node1.HeapLocation);
            Assert.AreEqual(2, node2.HeapLocation);
            node1.Value = 1;
            heap.DecreaseValue(node1.HeapLocation);
            Assert.AreEqual(1, node3.HeapLocation);
            Assert.AreEqual(0, node1.HeapLocation);
            Assert.AreEqual(2, node2.HeapLocation);
        }
    }
}

