using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Media;
using System.Threading;

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

            //Alarm a1 = new Alarm();
            //List<int> testSys = new List<int> { 1, 1, 1, 1, 11, 1, 1, 3, 3, 11, 1, 6 };
            //a1.StartAlarm(testSys);
            //Console.ReadKey();
            

            //Test af SendToDatabase-klasse
            //SendToDatabase send = new SendToDatabase();
            //send.SendData();

            //Test af lineær regression
            //double[] adcValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };                   //Array with x-values (adc [V])
            //double[] pressureValues = { 2, 3, 5, 6, 8, 9, 10, 12, 14, 15 };                 //Array with y-values (pressure [mmHg]

            //LinearRegression regression = new LinearRegression(adcValues, pressureValues);

            //Console.WriteLine(regression.GetSlope());
            //Console.WriteLine(regression.GetIntercept());
            //Console.WriteLine(regression.GetRSquared());

            var rand = new Random();
            List<int> sys = new List<int>();

            var data = new List<int>();  //Laver en liste og putter random værdier ind

            for (int i = 0; i < 300; i++)
            {
                data.Add(rand.Next(100));
            }

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            
            {
                for (int i = 5; i <= data.Count - 5; i++)
                {
                    if (data[i] > data[i - 1] && data[i] > data[i - 2] && data[i] > data[i - 3] && data[i] > data[i - 4] && data[i] > data[i + 1] && data[i] > data[i + 2] && data[i] > data[i + 3] && data[i] > data[i + 4])
                    {
                        sys.Add(data[i]);
                    }
                }
            }

            void WriteSys()
            {
                foreach (var item in sys)
                {
                    Console.WriteLine("Sys = " + item);

                }
            }

            SoundPlayer alarm = new SoundPlayer("alarm1.wav");
            Thread t1 = new Thread(WriteSys);
            t1.Start();




                for (int i = 5; i <= sys.Count - 5; i++)
                {
                    if (sys[i] > 1.3 * sys[i - 5] || sys[i] < 0.7 * sys[i - 5])
                    {
                        alarm.Play();
                    Console.WriteLine("Alarm: " + Convert.ToString(sys[i]));

                    }

                }
            

            Console.ReadLine();
        }
    }
}
