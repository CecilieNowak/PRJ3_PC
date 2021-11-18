using System;
using BusinessLogicLayer;
using WriteToFile;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcBP data = new CalcBP();
            TestIO test = new TestIO();
            data.CalcDia();
            data.CalcDia();
            test.testIO();
        }
    }
}
