using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DTO_BloodPressureData;
using BusinessLogicLayer;

namespace Test_PRJ3_PC
{
    [TestFixture]

    class SmoothingTest
    {
        
        private Smoothing _smoothing;
        
        private List<BloodPressureData> list;

        [SetUp]
        public void Setup()
        {
            _smoothing = new Smoothing();
            list = new List<BloodPressureData>();

            for (int i = 0; i < 10; i++)
            {
                BloodPressureData bp = new BloodPressureData();
                bp.Værdi = i;
                list.Add(bp);
                
            }


        }

        [Test]
        public void testOfSmoothGraph()
        {
           double værdi = _smoothing.smoothGraph(list).Værdi;
            Assert.That(værdi, Is.EqualTo(4));
        }





    }
}
