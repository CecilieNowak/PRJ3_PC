using System;
using BusinessLogicLayer;
using DataAccessLayer;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcBP data = new CalcBP();
            TestIO test = new TestIO();
            data.CalcSyss();
            data.CalcSys();
            data.CalcDia();
            data.CalcDia();
            test.testIO();

            //Test af SendToDatabase-klasse
            SendToDatabase send = new SendToDatabase();
            send.SendData();
        }
    }
}
