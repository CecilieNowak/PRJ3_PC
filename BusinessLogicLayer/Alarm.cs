using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;

namespace BusinessLogicLayer
{
    public class Alarm
    {
        List<int> sys = new List<int>();
        SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");




        public void StartAlarm(List<int> sys)
        {
            for (int i = 5; i <= sys.Count - 5; i++)
            {
                if (sys[i] > 1.3 * sys[i - 5] || sys[i] < 0.7 * sys[i - 5])
                {
                    alarm.PlayLooping();

                }

            }

        }

    }
}

 

