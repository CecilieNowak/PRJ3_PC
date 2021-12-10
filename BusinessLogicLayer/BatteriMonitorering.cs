using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class BatteryMonitorering
    {

        private int batteristatus;
        //private Battery batteryData;

        public BatteryMonitorering()
        {
            //batteryData = new Battery(); Værdien hentes ikke fra data pga RPi
        }

        public BloodPressureData RequestBatterystatus(BloodPressureData bp)
        {
            double sample = bp.battery;

            if (sample >= 2.9)
            {
                bp.battery = 100;
            }
            else if (sample >= 2.765 && sample < 2.9)
            {
                bp.battery = 80;
            }
            else if (sample >= 2.701 && sample < 2.765)
            {
                bp.battery = 60;
            }
            else if (sample >= 2.657 && sample < 2.701)
            {
                bp.battery = 40;
            }
            else if (sample >= 2.593 && sample < 2.657)
            {
                bp.battery = 20;
            }
            else if (sample >= 2.506 && sample < 2.593)
            {
                bp.battery = 10;
            }
            else if (sample < 2.506)
            {
                bp.battery = 1;
            }

            //batteristatus = batteryData.getbatterystatus(); - sample skulle gerne have været hentet fra datalag, men det kan ikke pga RPi

            return bp;

        }
    }
}

