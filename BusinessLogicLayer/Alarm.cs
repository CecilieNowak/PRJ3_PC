using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;

namespace BusinessLogicLayer
{
    public class Alarm
    {
        List<int> sys = new List<int>();

        SoundPlayer alarm = new SoundPlayer("alarm1.wav");
        Ellipse alarm1;

        public Alarm(Ellipse alarm1)
        {
            this.alarm1 = alarm1;
        }

        public void Alarmblink(int length, int repetition)
        {
            DoubleAnimation opacityAlarm = new DoubleAnimation() 
            {
                From = 0.0,                                                         //Starter fra 0.0 (Gennemsigtig) til 1.0 (synlig) Det er metoder fra klassen DoubleAnimation
                To = 1.0,                                                           
                Duration = new Duration(TimeSpan.FromMilliseconds(length)),         
                AutoReverse = true,                                                 
                RepeatBehavior = new RepeatBehavior(repetition)
            };
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAlarm);
            Storyboard.SetTarget(opacityAlarm, alarm1);
            Storyboard.SetTargetProperty(opacityAlarm, new PropertyPath("Opacity"));
            storyboard.Begin(alarm1);
        }

        public void AlarmSound()
        {
            
            alarm.PlayLooping();

        }


        // nuværende metoder til test ^^ Nedenstående metoder skal bruges senere


        public void StartAlarm(List<int> sys)
        {
            for (int i = 5; i <= sys.Count - 5; i++)
            {
                if (sys[i] > 1.3 * sys[i - 5] || sys[i] < 0.7 * sys[i - 5])
                {
                   // alarm.PlayLooping();

                }

            }

        }

        public void ALLARM(List<int> sys)
        {
            for (int i = 5; i <= sys.Count - 5; i++)
            {
                if (sys[i] > sys[i - 1] && sys[i] > sys[i - 2] && sys[i] > sys[i - 3] && sys[i] > sys[i - 4] && sys[i] > sys[i + 1] && sys[i] > sys[i + 2] && sys[i] > sys[i + 3] && sys[i] > sys[i + 4])
                {
                    sys.Add(sys[i]);
                }
            }
        }


    }
}

 

