using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CheckCPR
    {
        public bool CheckSocSecNb(string number)
        {
            int[] integer = new int[10];

            if (number.Length != 10) // Hvis antal cifre er forkert returnes false
                return false;

            for (int index = 0; index < 10; index++)
            {
                if (number[index] < '0' ||
                    '9' < number[
                        index]) // Hvis karakteren på plads index i den modtagne streng ikke er et tal returnes false
                    return false;

                integer[index] =
                    Convert.ToInt16(number[index]) -
                    48; // Karakteren på plads index konverteres til den tilhørende integer - eksempel '6' konverteres til 6
            }

            return true;
        }
    }
}
