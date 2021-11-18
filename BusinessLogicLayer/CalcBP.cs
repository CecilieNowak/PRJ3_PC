using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CalcBP
    {
        List<int> data = new List<int> { 1, 5, 4, 3, 2, 5, 7, 8, 4, 2, 1, 4 };

        List<int> sys = new List<int>();
        List<int> dia = new List<int>();

        public void CalcSys()
        {
            for (int i = 1; i <= data.Count - 2; i++)
            {
                if (data[i] > data[i - 1] && data[i] > data[i + 1])
                {
                    sys.Add(data[i]);
                }
            }
            foreach (int i in sys)
            {
                Console.WriteLine(i);
            }
        }

        public void CalcDia()
        {
            for (int i = 1; i <= data.Count - 2; i++)
            {
                if (data[i] < data[i - 1] && data[i] < data[i + 1])
                {
                    dia.Add(data[i]);
                }
            }
            foreach (int i in dia)
            {
                Console.WriteLine("Diastolisk blodtryk: " + i);
            }
        }
    }
}
