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
            //SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");
            //alarm.PlayLooping();

            Alarm a1 = new Alarm();
            List<int> liste = new List<int> { 1, 1, 1, 1, 1, 5, 5, 5, 5, 5, 1, 11, 1, 6 };
            a1.StartAlarm(liste);


            Console.ReadKey();
            //CalcBP calc = new CalcBP();
            //TestIO test = new TestIO();
            //data.CalcSys();
            //data.CalcDia();
            
            //test.Test();

            //Test af SendToDatabase-klasse
            //SendToDatabase send = new SendToDatabase();
            //send.SendData();
        }
    }
}
