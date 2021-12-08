using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BusinessLogicLayer;

namespace Test_PRJ3_PC
{
    [TestFixture]
    public class RegressionLinear
    {
        private LinearRegression uut;
        private double[] pressureValues;
        private double[] adcValues;

        [SetUp]
        public void Setup()
        {
            pressureValues = new double[] { 2, 3, 5, 6, 8, 9, 10, 12, 14, 15 };
            adcValues = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            uut = new LinearRegression(pressureValues, adcValues);
        }

        [Test]
        public void RegressionTest()
        {
            Assert.That((uut.GetSlope(), 4), Is.EqualTo(1.4667));
            Assert.That((uut.GetIntercept(),4), Is.EqualTo(0.3333));
            Assert.That((uut.GetRSquared(), 4), Is.EqualTo(0.9948));
        }
    }
}
