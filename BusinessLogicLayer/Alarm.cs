using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;
using DTO_BloodPressureData;
using System.Linq;
using System.Windows.Threading;
using System.Windows.Controls;

namespace BusinessLogicLayer
{
    public class Alarm
    {

        SoundPlayer alarm = new SoundPlayer("alarm1.wav");
        Ellipse _alarm;
        Label _alarmLabel;
        private readonly BloodPressureData bp;
        private Storyboard _st;
        private Dispatcher d;

        public Alarm(Ellipse alarm1, Label alarmLabel, Storyboard st, Dispatcher d)
        {
            _alarm = alarm1;
            _alarmLabel = alarmLabel;
            bp = new BloodPressureData();
            _st = new Storyboard();
            this.d = d;
        }


        DoubleAnimation opacityAlarm = new DoubleAnimation()
        {
            From = 0.0,                                                         //Starter fra 0.0 (Gennemsigtig) til 1.0 (synlig) Det er metoder fra klassen DoubleAnimation
            To = 1.0,
            Duration = new Duration(TimeSpan.FromMilliseconds(333)),
            AutoReverse = true,
            RepeatBehavior = new RepeatBehavior(10)
        };

        public void StartAlarm(List<double> SysList)
        {
            _st.Children.Add(opacityAlarm);
            Storyboard.SetTarget(opacityAlarm, _alarm);
            Storyboard.SetTargetProperty(opacityAlarm, new PropertyPath("Opacity"));


            for (int i = 5; i <= SysList.Count - 1; i++)
            {
                if (SysList[i] >= 1.3 * SysList[i - 5] || SysList[i] <= 0.7 * SysList[i - 5])
                {
                    _alarm.Visibility = Visibility.Visible;
                    _alarmLabel.Visibility = Visibility.Visible;
                    alarm.PlayLooping();
                    _st.Begin(_alarm);
                    Thread t = new Thread(Unshow);
                    t.Start();
                }
                SysList.RemoveAt(0);
            }
        }

        void Unshow()
        {
            Thread.Sleep(6400);
            d.Invoke(() =>
            {
                _alarm.Visibility = Visibility.Hidden;
                _alarmLabel.Visibility = Visibility.Hidden;
                alarm.Stop();
            });
        }

    }
}




