using System;
using NUnit.Framework;
using Task1;
using System.Diagnostics;

namespace Task1.Test
{
    public class NUnitTest1
    {
        #region Euclidean algorithm Tests
        [TestCase(8, 15, 1)]
        [TestCase(40, 30, 10)]
        [TestCase(-5, 10, 5)]
        [TestCase(24, 24, 24)]
        public void GCD_With_Two_Params_PositiveTest(int a, int b, int expectedResult)
        {
            TimeSpan time;
            Assert.AreEqual(Task1.GCD(a,b,out time),expectedResult);
        }
        [TestCase(8, 15, 17, 1)]
        [TestCase(40, 30, 50, 10)]
        [TestCase(-5, 10, 25, 5)]
        [TestCase(24, 24, 24, 24)]
        public void GCD_With_Three_Params_PositiveTest(int a, int b, int c, int expectedResult)
        {
            TimeSpan time;
            Assert.AreEqual(Task1.GCD(a, b,c,out time), expectedResult);
        }
        [TestCase(6, 78, 294, 570, 36)]
        public void GCD_With_Array_Params_PositiveTest(int expectedResult, params int[] numbers)
        {
            TimeSpan time;
            Assert.AreEqual(Task1.GCD(out time,numbers),expectedResult);
        }
        [TestCase(0, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(0,0,0,0,0,0)]
        public void GCD_With_Array_Params_ThrowsArgumentException(params int[] numbers)
        {
            TimeSpan time;
            Assert.Throws<ArgumentException>(() =>Task1.GCD(out time,numbers)) ;
        }
        #endregion

        #region Binary algorithm
        [TestCase(8, 15, 1)]
        [TestCase(40, 30, 10)]
        [TestCase(-5, 10, 5)]
        [TestCase(24, 24, 24)]
        public void BinaryGCD_With_Two_Params_PositiveTest(int a, int b, int expectedResult)
        {
            TimeSpan time;
            Assert.AreEqual(Task1.BinaryGCD(a, b, out time), expectedResult);
        }
        [TestCase(8, 15, 17, 1)]
        [TestCase(40, 30, 50, 10)]
        [TestCase(-5, 10, 25, 5)]
        [TestCase(24, 24, 24, 24)]
        public void BinaryGCD_With_Three_Params_PositiveTest(int a, int b, int c, int expectedResult)
        {
            TimeSpan time;
            Assert.AreEqual(Task1.BinaryGCD(a, b, c, out time), expectedResult);
        }

        [TestCase(6, 78, 294, 570, 36)]
        public void BinaryGCD_With_Array_Params_PositiveTest(int expectedResult, params int[] numbers)
        {
            TimeSpan time;
            Assert.AreEqual(expectedResult,Task1.BinaryGCD(out time, numbers));
        }

#endregion
    }
}