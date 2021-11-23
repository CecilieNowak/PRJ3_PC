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
            //CalcBP calc = new CalcBP();
            //TestIO test = new TestIO();
            //data.CalcSys();
            //data.CalcDia();

            //test.Test();

            Alarm a1 = new Alarm();
            List<int> testSys = new List<int> { 1, 1, 1, 1, 1, 1, 1, 3, 3, 11, 1, 6 };
            a1.StartAlarm(testSys);
            

            //Test af SendToDatabase-klasse
            //SendToDatabase send = new SendToDatabase();
            //send.SendData();
        }
    }
}
