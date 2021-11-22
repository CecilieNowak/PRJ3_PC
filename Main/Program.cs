using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Media;

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

            //test.Test();

            Alarm a1 = new Alarm();
            List<int> testSys = new List<int> { 1, 2, 3, 45, 23, 23, 24, 25, 1, 2, 3, 45, 23, 23, 24, 25, 1, 2, 3, 45, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, 1, 2, 3, 200, 23, 23, 24, 25, };
            a1.StartAlarm(testSys);
            

            //Test af SendToDatabase-klasse
            //SendToDatabase send = new SendToDatabase();
            //send.SendData();
        }
    }
}
