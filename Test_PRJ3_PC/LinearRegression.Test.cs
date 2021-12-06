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
            pressureValues = new double[] { 0, 1, 2, 3, 4, 5 };
            adcValues = new double[] { 0, 1, 2, 3, 4, 5 };
            uut = new LinearRegression(pressureValues, adcValues);
        }

        [Test]
        public void RegressionTest()
        {
            Assert.That(uut.GetSlope(), Is.EqualTo(1));
            Assert.That(uut.GetIntercept(), Is.EqualTo(0));
            Assert.That(uut.GetRSquared(), Is.EqualTo(1));
        }
    }
}
