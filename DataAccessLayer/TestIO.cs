using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;


namespace WriteToFile
{
    public class TestIO
    {
        String text;
        String text1;

        public void testIO()
        {
            Console.Write("Type something: ");
            text = Convert.ToString(Console.ReadLine());
            text1 = text;
            string path = @"Julie.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text1);
                    sw.Dispose();
                }
            }
        }
    }
}

//Kører man programmet første gang, og skriver noget, kommer det ind i tekstfilen, men kører man programmet igen, og skriver noget nyt, kommer det ikke ind.
//Jeg kan ikke lige gennemskue hvorfor.