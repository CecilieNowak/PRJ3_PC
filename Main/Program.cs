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
            data.CalcSys();
            data.CalcDia();
            
            test.testIO();

            //Test af SendToDatabase-klasse
            //SendToDatabase send = new SendToDatabase();
            //send.SendData();
        }
    }
}
