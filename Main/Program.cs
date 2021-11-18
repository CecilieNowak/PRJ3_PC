using System;
using BusinessLogicLayer;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcBP data = new CalcBP();
            data.CalcSys();
            data.CalcDia();
        }
    }
}
