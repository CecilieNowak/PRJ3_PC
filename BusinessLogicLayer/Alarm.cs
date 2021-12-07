using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Shapes;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class Alarm
    {
        List<int> sys = new List<int>();

        SoundPlayer alarm = new SoundPlayer("alarm1.wav");
        Ellipse alarm1;

        List<BloodPressureData> syst = new List<BloodPressureData>();
        List<BloodPressureData> dia = new List<BloodPressureData>();
        private BloodPressureData bp;

        public Alarm(Ellipse alarm1)
        {
            this.alarm1 = alarm1;
            bp = new BloodPressureData();
        }
        
        public void Alarmblink(List<double> SysList, List<double> DiaList, int length, int repetition)
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



            for (int i = 5; i <= SysList.Count - 5; i++)
            {
                if (SysList[i] > 1.3 * SysList[i - 5] || SysList[i] < 0.7 * SysList[i - 5])
                {
                    alarm1.Visibility = Visibility.Visible;
                    storyboard.Begin(alarm1);
                }
            }

            for (int i = 5; i <= DiaList.Count - 5; i++)
            {
                if (DiaList[i] > 1.3 * DiaList[i - 5] || DiaList[i] < 0.7 * DiaList[i - 5])
                {
                    alarm1.Visibility = Visibility.Visible;
                    storyboard.Begin(alarm1);
                }
            }
        }

        public void StartAlarm(List<double> SysList, List<double> DiaList)
        {

            for (int i = 5; i <= SysList.Count - 5; i++)
            {
                if (SysList[i] > 1.3 * SysList[i - 5] || SysList[i] < 0.7 * SysList[i - 5])
                {
                    alarm.PlayLooping();
                }
            }
            for (int i = 5; i <= DiaList.Count - 5; i++)
            {
                if (DiaList[i] > 1.3 * DiaList[i - 5] || DiaList[i] < 0.7 * DiaList[i - 5])
                {
                    alarm.PlayLooping();
                }
            }
        }

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
    }


 

