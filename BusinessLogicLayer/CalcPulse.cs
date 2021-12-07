using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    class CalcPulse
    {
        int DTOsBetweenEverySys;

        public int GetNoOfDTOBetweenSys()
        {
            return DTOsBetweenEverySys;
        }
        

        public int GetPulse()
        {
            int pulse = 15 / DTOsBetweenEverySys * 60;         // 15 er antal DTO's pr sekund. Ganger med 60 for at få pulsslag pr min
            return pulse;
        }


    }
}
