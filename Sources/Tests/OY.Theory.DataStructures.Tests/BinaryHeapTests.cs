using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.Shared;
using OY.Theory.DataStructures.Heap;
using OY.Theory.Combinatorics;

namespace OY.Theory.DataStructures.Tests
{
    [TestClass]
    public class BinaryHeapTests
    {
        [TestMethod]
        public void TestBinaryHeapCreation()
        {
            var heap = new BinaryHeap<int>();
            Assert.AreEqual(0, heap.Count());
            heap = new BinaryHeap<int>(6);
            Assert.AreEqual(0, heap.Count());
            heap = new BinaryHeap<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(6, heap.Count());            
        }

        [TestMethod]
        public void TestBinaryHeapInsert()
        {
            var heap = new BinaryHeap<int>(6);
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(3);
            heap.Insert(4);
            heap.Insert(5);
            heap.Insert(6);
            heap.Insert(7);
            Assert.AreEqual(7, heap.Count()); 
        }

        [TestMethod]
        public void TestBinaryHeapGeneral()
        {
            var heap = new BinaryHeap<int>(6);
            heap.Insert(7);
            heap.Insert(6);
            heap.Insert(5);
            heap.Insert(4);
            heap.Insert(3);
            heap.Insert(2);
            heap.Insert(1);
            Assert.AreEqual(7, heap.Count());
            Assert.AreEqual(1, heap.ExtractMin());
            Assert.AreEqual(2, heap.ExtractMin());
            Assert.AreEqual(3, heap.ExtractMin());
            Assert.AreEqual(4, heap.ExtractMin());
            Assert.AreEqual(5, heap.ExtractMin());
            Assert.AreEqual(6, heap.ExtractMin());
            Assert.AreEqual(7, heap.ExtractMin());
            Assert.AreEqual(0, heap.Count());

            heap = new BinaryHeap<int>(new int[] { 3, 5, 7, 2, 1, 6, 4 });
            Assert.AreEqual(7, heap.Count());
            Assert.AreEqual(1, heap.ExtractMin());
            Assert.AreEqual(2, heap.ExtractMin());
            Assert.AreEqual(3, heap.ExtractMin());
            Assert.AreEqual(4, heap.ExtractMin());
            Assert.AreEqual(5, heap.ExtractMin());
            Assert.AreEqual(6, heap.ExtractMin());
            Assert.AreEqual(7, heap.ExtractMin());
            Assert.AreEqual(0, heap.Count());
        }

        [TestMethod]
        public void TestBinaryHeapGeneralUsingRandom()
        {
            int[] data = PermutationGenerator.GenerateRandomPermutation(23);
            var heap = new BinaryHeap<int>(data);
            for (int i = 0; i < 23; ++i)
            {
                Assert.AreEqual(i, heap.ExtractMin());
            }
            Assert.AreEqual(0, heap.Count());
        }
    }
}
