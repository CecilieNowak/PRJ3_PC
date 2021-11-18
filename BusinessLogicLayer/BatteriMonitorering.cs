﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    class BatteriMonitorering
    {
        //Kode tyvstjålet fra Gustavs semesterprojekt
        //Passende værdier kan indsættes senere

        private int batteristatus;
        //private Battery batteryData;

        public BatteriMonitorering()
        {
            //batteryData = new Battery(); Værdien hentes ikke fra data pga RPi
        }
        public int requestbatterystatus(int ADCValue)
        {
            double sample = ((Convert.ToDouble(ADCValue) / 2048.0) * 6.144);

            if (sample >= 2.9)
            {
                batteristatus = 100;
            }
            else if (sample >= 2.765 && sample < 2.9)
            {
                batteristatus = 80;
            }
            else if (sample >= 2.701 && sample < 2.765)
            {
                batteristatus = 60;
            }
            else if (sample >= 2.657 && sample < 2.701)
            {
                batteristatus = 40;
            }
            else if (sample >= 2.593 && sample < 2.657)
            {
                batteristatus = 20;
            }
            else if (sample >= 2.506 && sample < 2.593)
            {
                batteristatus = 10;
            }
            else if (sample < 2.506)
            {
                batteristatus = 1;
            }

            //batteristatus = batteryData.getbatterystatus(); - sample skulle gerne have været hentet fra datalag, men det kan ikke pga RPi

            return batteristatus;

        }
    }
}
}
