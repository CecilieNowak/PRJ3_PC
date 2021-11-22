using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;

namespace BusinessLogicLayer
{
    class Alarm
    {
        List<int> sys = new List<int>();
        SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");

        

        public void StartAlarm(List<int> sys)
        {
            for (int i = 1; i <= sys.Count - 2; i++)
            {
                if (sys[i] > 1.3 * sys[i - 5] || sys[i] < 0.7 * sys[i - 5])
                {
                    alarm.PlayLooping();
                }
            }
                
        }

        }


    }
}
 

