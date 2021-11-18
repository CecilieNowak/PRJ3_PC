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
            

            calcBP.CalcSys();

            
            Assert.That(calcBP.Contains(5));

        }
    }
}