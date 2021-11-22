using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using DataAccessLayer;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcBP calc = new CalcBP();
            TestIO test = new TestIO();
            List<int> data = new List<int> { 1, 5, 4, 3, 2, 5, 7, 8, 4, 2, 1, 4 };
            calc.CalcSys(data);
            calc.CalcDia(data);
            test.testIO();

            //Test af SendToDatabase-klasse
            SendToDatabase send = new SendToDatabase();
            send.SendData();
        }
    }
}
