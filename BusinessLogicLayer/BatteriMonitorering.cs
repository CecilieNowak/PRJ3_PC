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

            if (sample >= 1796)
            {
                bp.battery = 100;
            }
            else if (sample >= 1706 && sample < 1796)
            {
                bp.battery = 90;
            }
            else if (sample >= 1641 && sample < 1706)
            {
                bp.battery = 80;
            }
            else if (sample >= 1621 && sample < 1641)
            {
                bp.battery = 70;
            }
            else if (sample >= 1600 && sample < 1621)
            {
                bp.battery = 60;
            }
            else if (sample >= 1586 && sample < 1600)
            {
                bp.battery = 50;
            }
            else if (sample >= 1576 && sample < 1586)
            {
                bp.battery = 40;
            }
            else if (sample >= 1556 && sample < 1576)
            {
                bp.battery = 30;
            }
            else if (sample >= 1536 && sample < 1556)
            {
                bp.battery = 20;
            }
            else if (sample >= 1481 && sample < 1536)
            {
                bp.battery = 10;
            }
            else
            {
                bp.battery = 0;
            }


            return bp;

        }
    }
}

