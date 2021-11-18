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
            int s;
        }

        [Test]
        public void CalcSys()
        {
            List<int> data = new List<int> { 1, 5, 4, 3, 2, 5, 7, 8, 4, 2, 1, 4 };
            List<int> sys = new List<int>();
            List<int> dia = new List<int>();

            calcBP.CalcDia();
            calcBP.CalcDia();

            Assert.That(sys.Any(s => s == 8));
            
        }
    }
}