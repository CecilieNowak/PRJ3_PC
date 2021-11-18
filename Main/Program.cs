using System;
using BusinessLogicLayer;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcBP data = new CalcBP();
            data.CalcDia();
            data.CalcDia();

            //Test af SendToDatabase-klasse
            SendToDatabase send = new SendToDatabase();
            send.SendData();
        }
    }
}
