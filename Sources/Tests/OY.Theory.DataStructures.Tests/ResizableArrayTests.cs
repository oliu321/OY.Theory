using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OY.Theory.DataStructures.Tests
{
    [TestClass]
    public class ResizableArrayTests
    {
        [TestMethod]
        public void TestResizableArrayCreation()
        {
            var obj = new ResizableArray<int>();
            Assert.AreEqual(ResizableArray<int>.DefaultCapacity, obj.Length);
            obj = new ResizableArray<int>(0);
            Assert.AreEqual(1, obj.Length);
            obj = new ResizableArray<int>(-1);
            Assert.AreEqual(1, obj.Length);

            int len = 2 * ResizableArray<int>.DefaultCapacity + 1;
            obj = new ResizableArray<int>(len);
            Assert.AreEqual(len, obj.Length);
        }

        [TestMethod]
        public void TestResizableArrayExpansion()
        {
            var obj = new ResizableArray<int>();
            obj.Expand();
            Assert.AreEqual(ResizableArray<int>.DefaultCapacity * 2, obj.Length);

            obj = new ResizableArray<int>(1);
            obj[0] = 2319;
            obj.Expand();
            Assert.AreEqual(2319, obj[0]);
            Assert.AreEqual(2, obj.Length);
            obj.Expand();
            Assert.AreEqual(2319, obj[0]);
            Assert.AreEqual(4, obj.Length);
            obj[3] = 2317;
            int len = 2 * ResizableArray<int>.DefaultCapacity + 1;
            obj.Expand(len);
            Assert.AreEqual(2319, obj[0]);
            Assert.AreEqual(2317, obj[3]);
            Assert.AreEqual(len, obj.Length);
        }

        [TestMethod]
        public void TestResizableArrayShrink()
        {
            var obj = new ResizableArray<int>();
            obj.Shrink();
            Assert.AreEqual(ResizableArray<int>.DefaultCapacity / 2, obj.Length);

            obj = new ResizableArray<int>(1);
            obj[0] = 2319;
            obj.Shrink();
            Assert.AreEqual(2319, obj[0]);
            Assert.AreEqual(1, obj.Length);
            obj = new ResizableArray<int>(3);
            obj[0] = 2319;
            obj.Shrink();
            Assert.AreEqual(2319, obj[0]);
            Assert.AreEqual(1, obj.Length);
            int len = 2 * ResizableArray<int>.DefaultCapacity + 3;
            obj.Expand(len);
            obj[ResizableArray<int>.DefaultCapacity] = 2316;
            obj.Shrink();
            Assert.AreEqual(2319, obj[0]);
            Assert.AreEqual(2316, obj[ResizableArray<int>.DefaultCapacity]);
            Assert.AreEqual(ResizableArray<int>.DefaultCapacity + 1, obj.Length);
        }
    }
}
