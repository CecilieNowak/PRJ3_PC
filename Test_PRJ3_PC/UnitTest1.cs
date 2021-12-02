using NUnit.Framework;
using BusinessLogicLayer;
using System.Collections.Generic;
using System.Linq;

namespace Test_PRJ3_PC
{
    [TestFixture]
    public class Tests
    {
        CalcBP calcBP;
        
        [SetUp]
        public void Setup()
        {
            calcBP = new CalcBP();

        }

        [Test]
        public void CalcSys()
        {
            List<int> data = new List<int> { 2, 3, 5, 4, 1, 7, 3, 9, 3 };
            List<int> sys = calcBP.CalcSys(data);

            
            Assert.That(sys.Contains(5));
            Assert.That(sys.Contains(7));
            Assert.That(sys.Contains(9));

        }
    }
}