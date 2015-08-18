using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.DataStructures.Queue;

namespace OY.Theory.DataStructures.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void TestResizingArrayQueueNormalOperation()
        {
            var queue = new ResizingArrayQueue<int>(0);
            Assert.AreEqual(0, queue.Count);
            Assert.IsTrue(queue.IsEmpty());
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Peek());
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Peek());
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
            Assert.IsTrue(queue.IsEmpty());
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Peek());
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Peek());
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
