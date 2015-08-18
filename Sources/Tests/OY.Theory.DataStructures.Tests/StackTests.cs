using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Theory.DataStructures.Stack;

namespace OY.Theory.DataStructures.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestResizingArrayStackNormalOperation()
        {
            var stack = new ResizingArrayStack<int>(0);
            Assert.AreEqual(0, stack.Count);
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Peek());
            stack.Push(2);
            Assert.AreEqual(2, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Peek());
            stack.Push(3);
            Assert.AreEqual(3, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Peek());
            stack.Push(2);
            Assert.AreEqual(2, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Peek());
            stack.Push(3);
            Assert.AreEqual(3, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
