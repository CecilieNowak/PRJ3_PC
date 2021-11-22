using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DataAccessLayer
{
    public class TestIO
    {
        string text;
        string text1;

        public void Test()
        {
            Console.Write("Type something: ");
            text = Convert.ToString(Console.ReadLine());
            text1 = text;
            string path = @"Data.txt";

            if (File.Exists(path))
            {
                using StreamWriter sw = File.AppendText(path);
                sw.WriteLine(text1);
                sw.WriteLine();
                sw.Flush();
            }
        }
    }
}

