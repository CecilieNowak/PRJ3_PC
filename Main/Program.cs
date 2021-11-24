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

            //Test af lineær regression
            double[] adcValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };                   //Array with x-values (adc [V])
            double[] pressureValues = { 2, 3, 5, 6, 8, 9, 10, 12, 14, 15 };                 //Array with y-values (pressure [mmHg]

            LinearRegression regression = new LinearRegression(adcValues, pressureValues);

            Console.WriteLine(regression.GetSlope());
            Console.WriteLine(regression.GetIntercept());
            Console.WriteLine(regression.GetRSquared());
        }
    }
}
