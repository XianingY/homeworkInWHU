using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLib;

namespace UnitTest
{
    [TestClass]
    public class Class1Tests
    {
        [TestMethod]
        public void PrimeFactors1()
        {
            var result = Class1.PrimeFactors(4);
            Assert.AreEqual("2×2", result); 
        }

        [TestMethod]
        public void PrimeFactors2()
        {
            var result = Class1.PrimeFactors(30);
            Assert.AreEqual("2×3×5", result); 
        }

        [TestMethod]
        public void PrimeFactors3()
        {
            var result = Class1.PrimeFactors(16);
            Assert.AreEqual("2×2×2×2", result);
        }

        [TestMethod]
        public void PrimeFactors4()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Class1.PrimeFactors(1001)); 
        }

        [TestMethod]
        public void PrimeFactors5()
        {
            // 非整数输入
            Assert.ThrowsException<FormatException>(() => int.Parse("whu"));
        }

    }
}
