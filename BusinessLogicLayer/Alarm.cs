using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;

namespace BusinessLogicLayer
{
    public class Alarm
    {
        List<int> _sys = new List<int>();
        

        

        public void StartAlarm(List<int> sys)
        {
            _sys = sys;
            SoundPlayer alarm = new SoundPlayer("sonnette_reveil.wav");

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

 

