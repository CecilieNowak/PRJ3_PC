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

namespace PresentationLayer
{
    public class Alarm
    {

        SoundPlayer alarm = new SoundPlayer("alarm1.wav");
        Ellipse _alarm;
        //private readonly MainWindow _mw;
        private readonly BloodPressureData bp;
        private Storyboard _st;
        private Dispatcher d;

        public Alarm(Ellipse alarm1, Storyboard st, Dispatcher d)
        {
            _alarm = alarm1;
            bp = new BloodPressureData();
            _st = new Storyboard();
            this.d = d;
        }


        DoubleAnimation opacityAlarm = new DoubleAnimation()
        {
            From = 0.0,                                                         //Starter fra 0.0 (Gennemsigtig) til 1.0 (synlig) Det er metoder fra klassen DoubleAnimation
            To = 1.0,
            Duration = new Duration(TimeSpan.FromMilliseconds(250)),
            AutoReverse = true,
            RepeatBehavior = new RepeatBehavior(10)
        };

        //public bool visible;
        //public bool Visible()
        //{
        //    if (_alarm.Visibility == Visibility.Visible)
        //    {
        //        visible = true;
        //    }
        //    else
        //    {
        //        visible = false;
        //    }
        //    return visible;
        //}

        public void StartAlarm(List<double> SysList, List<double> DiaList)
        {
            _st.Children.Add(opacityAlarm);
            Storyboard.SetTarget(opacityAlarm, _alarm);
            Storyboard.SetTargetProperty(opacityAlarm, new PropertyPath("Opacity"));


            for (int i = 1; i <= SysList.Count - 1; i++)
            {
                if (SysList[i] >= 1.01 * SysList[i - 1] || SysList[i] <= 0.99 * SysList[i - 1])
                {
                    _alarm.Visibility = Visibility.Visible;
                    alarm.PlayLooping();
                    _st.Begin(_alarm);
                    SysList.RemoveAt(0);
                    Thread t = new Thread(Unshow);
                    t.Start();
                }
            }




            //    for (int i = 5; i <= DiaList.Count - 5; i++)
            //    {
            //        if (DiaList[i] >= 1.3 * DiaList[i - 5] || DiaList[i] <= 0.7 * DiaList[i - 5])
            //        {
            //            _alarm.Visibility = Visibility.Visible;
            //            _st.Begin(_alarm);
            //        }
            //    }
            //}

            //public void StartAlarm(List<double> SysList, List<double> DiaList)
            //{

            //    for (int i = 1; i <= SysList.Count - 1; i++)
            //    {
            //        if (SysList[i] >= 1.3 * SysList[i - 1] || SysList[i] <= 0.7 * SysList[i - 1])
            //        {
            //            for (int a = 0; a < 5; a++)
            //            {
            //                alarm.Play();
            //            }
            //        }
            //    }
            //    for (int i = 5; i <= DiaList.Count - 5; i++)
            //    {
            //        if (DiaList[i] > 1.3 * DiaList[i - 5] || DiaList[i] < 0.7 * DiaList[i - 5])
            //        {
            //            alarm.PlayLooping();
            //        }
            //    }
            //}

            //public void AlarmSound()
            //{

            //    alarm.PlayLooping();

            //}


            // nuværende metoder til test ^^ Nedenstående metoder skal bruges senere

            //List<int> SysList = new List<int>();
            //public void MakeSysList(List<BloodPressureData> data)
            //{
            //    //for (int i = 5; i <= sys.Count - 5; i++)
            //    //{
            //    //    if (sys[i] > 1.3 * sys[i - 5] || sys[i] < 0.7 * sys[i - 5])
            //    //    {
            //    //       alarm.PlayLooping();

            //    //    }

            //    //}

            //    for (int i = 5; i <= data.Count - 5; i++)
            //    {
            //        if (data[i].Værdi > data[i - 1].Værdi && data[i].Værdi > data[i - 2].Værdi && data[i].Værdi > data[i - 3].Værdi && data[i].Værdi > data[i - 4].Værdi && data[i].Værdi > data[i + 1].Værdi && data[i].Værdi > data[i + 2].Værdi && data[i].Værdi > data[i + 3].Værdi && data[i].Værdi > data[i + 4].Værdi)
            //        {
            //            SysList.Add(i);
            //        }
            //    }



            //}





            //    public void ALLARM(List<int> sys)
            //{
            //    for (int i = 5; i <= sys.Count - 5; i++)
            //    {
            //        if (sys[i] > sys[i - 1] && sys[i] > sys[i - 2] && sys[i] > sys[i - 3] && sys[i] > sys[i - 4] && sys[i] > sys[i + 1] && sys[i] > sys[i + 2] && sys[i] > sys[i + 3] && sys[i] > sys[i + 4])
            //        {
            //            sys.Add(sys[i]);
            //        }
            //    }
            //}


        }
        void Unshow()
        {
            Thread.Sleep(5000);
            d.Invoke(() =>
            {
                _alarm.Visibility = Visibility.Hidden;
                alarm.Stop();
            });
        }

    }
}


 

