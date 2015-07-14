using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OY.Theory.NumberTheory.Tests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        [TestMethod]
        public void TestGCDUnsigned()
        {
            uint actual = GreatestCommonDivisor.GCD_Unsigned(4, 6);
            Assert.AreEqual<uint>(2, actual);

            actual = GreatestCommonDivisor.GCD_Unsigned(4, 13);
            Assert.AreEqual<uint>(1, actual);

            actual = GreatestCommonDivisor.GCD_Unsigned(4, 0);
            Assert.AreEqual<uint>(4, actual);

            actual = GreatestCommonDivisor.GCD_Unsigned(0, 13);
            Assert.AreEqual<uint>(13, actual);

            actual = GreatestCommonDivisor.GCD_Unsigned(0, 0);
            Assert.AreEqual<uint>(0, actual);

            actual = GreatestCommonDivisor.GCD_Unsigned(1980*4, 1980*6);
            Assert.AreEqual<uint>(1980*2, actual);
        }

        [TestMethod]
        public void TestGCD()
        {
            uint actual = GreatestCommonDivisor.GCD(-4, 6);
            Assert.AreEqual<uint>(2, actual);

            actual = GreatestCommonDivisor.GCD(4, -13);
            Assert.AreEqual<uint>(1, actual);

            actual = GreatestCommonDivisor.GCD(-4, 0);
            Assert.AreEqual<uint>(4, actual);

            actual = GreatestCommonDivisor.GCD(0, -13);
            Assert.AreEqual<uint>(13, actual);

            actual = GreatestCommonDivisor.GCD(0, 0);
            Assert.AreEqual<uint>(0, actual);

            actual = GreatestCommonDivisor.GCD(-1980 * 4, -1980 * 6);
            Assert.AreEqual<uint>(1980 * 2, actual);
        }

        [TestMethod]
        public void TestPulverizeUnsigned()
        {
            var actual = GreatestCommonDivisor.Pulverize_Unsigned(4, 6);
            Assert.AreEqual<uint>(2, actual.Item1);
            Assert.AreEqual<int>(-1, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize_Unsigned(4, 13);
            Assert.AreEqual<uint>(1, actual.Item1);
            Assert.AreEqual<int>(-3, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize_Unsigned(4, 0);
            Assert.AreEqual<uint>(4, actual.Item1);
            Assert.AreEqual<int>(1, actual.Item2);
            Assert.AreEqual<int>(0, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize_Unsigned(0, 13);
            Assert.AreEqual<uint>(13, actual.Item1);
            Assert.AreEqual<int>(0, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize_Unsigned(0, 0);
            Assert.AreEqual<uint>(0, actual.Item1);
            Assert.AreEqual<int>(0, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize_Unsigned(1980 * 4, 1980 * 6);
            Assert.AreEqual<uint>(1980 * 2, actual.Item1);
            Assert.AreEqual<int>(-1, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);
        }

        [TestMethod]
        public void TestPulverize()
        {
            var actual = GreatestCommonDivisor.Pulverize(-4, -6);
            Assert.AreEqual<uint>(2, actual.Item1);
            Assert.AreEqual<int>(1, actual.Item2);
            Assert.AreEqual<int>(-1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize(-4, 13);
            Assert.AreEqual<uint>(1, actual.Item1);
            Assert.AreEqual<int>(3, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize(-4, 0);
            Assert.AreEqual<uint>(4, actual.Item1);
            Assert.AreEqual<int>(-1, actual.Item2);
            Assert.AreEqual<int>(0, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize(0, -13);
            Assert.AreEqual<uint>(13, actual.Item1);
            Assert.AreEqual<int>(0, actual.Item2);
            Assert.AreEqual<int>(-1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize(0, 0);
            Assert.AreEqual<uint>(0, actual.Item1);
            Assert.AreEqual<int>(0, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);

            actual = GreatestCommonDivisor.Pulverize(-1980 * 4, 1980 * 6);
            Assert.AreEqual<uint>(1980 * 2, actual.Item1);
            Assert.AreEqual<int>(1, actual.Item2);
            Assert.AreEqual<int>(1, actual.Item3);
        }
    }
}
