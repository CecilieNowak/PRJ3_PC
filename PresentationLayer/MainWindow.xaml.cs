using BusinessLogicLayer;
using LiveCharts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DTO_BloodPressureData;
//using SaveDataToTxtfile = BusinessLogicLayer.SaveDataToTxtfile;
using System.Windows.Media.Animation;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CheckLogin _logicobj;
        private readonly LoginWindow _loginW;
        public BloodPressureSubject _subject;
        private CalibrateWindow _calibrateW;
        public Filter _filter; //Har lavet denne public for at tilgå den i alarmobserver. Må jeg det?
        private SendToDatabase send;
        private SaveDataToTxtfile saveData;
        private CheckCPR _checkCPR;
        private LogFileObserver logFile;
        private Thread t4;
        private Testtråd testTråd;
        private Storyboard _st;
        private Alarm alarm1;

        public bool LoginOk { get; set; }
        public ChartValues<int> YValues { get; set; }   //YValues til puls graf
        public ChartValues<string> XValues { get; set; }   //XValues til puls graf

        public double A { get; set; } 
        public double B { get; set; }

        public MainWindow()
        {
            InitializeComponent();
           
            _logicobj = new CheckLogin();
            _loginW = new LoginWindow(this, _logicobj);

            _checkCPR = new CheckCPR();

            _subject = new BloodPressureSubject();
            
            YValues = new ChartValues<int>();
            XValues = new ChartValues<string>();
            DataContext = this;

            send = new SendToDatabase();
            A = 50;
            B = 1;

            saveData = new SaveDataToTxtfile();
            
            _filter = new Filter(_subject);
                testTråd = new Testtråd(this, _subject);
           
            
            DisplayObserver display = new DisplayObserver(_filter, this);

            //AlarmObserver aObserver = new AlarmObserver(_filter, this, alarm);

            BatteryObserver batteryObserver = new BatteryObserver(_filter, this);

            alarm1 = new Alarm(alarm, _st, Dispatcher);

            alarm1 = new Alarm(alarm, _st, Dispatcher);

            Storyboard st = new Storyboard();

            logFile = new LogFileObserver(_filter, saveData);

             BlockingCollection<BloodPressureData> dataQueue = new BlockingCollection<BloodPressureData>();

            // Må ikke slettes!!


            // LogFile med UDP-kommunikation
            //UDP_Listener_BLL udpListener = new UDP_Listener_BLL(dataQueue);
            //UDP_Consumer udpConsumer = new UDP_Consumer(dataQueue, _subject);
            //Thread t2 = new Thread(udpListener.startUDPListener);
            //Thread t3 = new Thread(udpConsumer.UpdateChart);

            //t2.Start();
            //t3.Start();


            //LogFile til alarm
            //Testtråd testtråd = new Testtråd(this, _subject);
            //Thread t5 = new Thread(testTråd.updateChart);
            //t5.Start();

            //LogFile med filter
            UDPmock udPmock = new UDPmock(this, _subject);
            Thread t6 = new Thread(udPmock.randomDTO);
            t6.Start();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Date_box.Text = DateTime.Now.ToString("dd/MM/yyyy");                        //Dato vises på UI                                                                   //Der skal måske også være kode til at vise tid her
            alarm.Visibility = Visibility.Hidden;
            //_filter.getAndSetCalibrationValues(A, B);
        }

        public void updateBatteryBar(double battery)
        {
            Dispatcher.Invoke(() =>
                {
                    BatteriBar.Value = battery;
                }
            );
        }

        private void SaveData_button_Click(object sender, RoutedEventArgs e)
        {
            string socSecNb = CPR_txtbox.Text;

            if (_checkCPR.CheckSocSecNb(socSecNb) == true) //Hvis det intastede CPR i tekstboksen er gyldig sker følgende:
            {
                send.SendData(socSecNb);
                dataSaved_Box.Text = "Data er sendt";
            }
            else
            {
                dataSaved_Box.Text = "Data kunne ikke sendes"; //Hvis det intastede CPR i tekstboksen er ugyldig sker følgende:
            }

            saveData.DeleteFromFile();  
        }

        public void PrepCalibrateWindow()
        {
            Dispatcher.Invoke(() =>         //DISPATCHER behøves ikke
            {
                _filter.Remove(logFile);
                _subject.Remove(_filter);
            }
            );
        }


        public void PrepMainWindow()
        {
            Dispatcher.Invoke(() =>     //Dispatcher behøves ikke
                {
                    _subject.Add(_filter);
                    _filter.Add(logFile);
                 _filter.getAndSetCalibrationValues(A,B); //TODO uncommunt
                }
            );
        }

        public void BatteryStatus(string text)
        {
            Dispatcher.Invoke(() =>     //Dispatcher behøves ikke
                {
                    Batteri_Status_Text.Text = text;
                }
            );
        }


        private void Calibrate_button_Click(object sender, RoutedEventArgs e)
        {
            PrepCalibrateWindow();

            _calibrateW = new CalibrateWindow(this, _subject);

            this.Hide(); //Når der klikkes på Kalibrer-knappen, lukker hovedvindue
            _loginW.ShowDialog(); //og Loginvindue vises

            if (LoginOk)
            {
                _calibrateW.ShowDialog(); //Hvis Login er ok, fuldføres login, og vi til kalibreringsvindue
              
            }
        }

        private void Close_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); //Program lukker, når der trkkes på Luk-knappen
        }

        public void UpdatePulseTextBox(string text)
        {
            //Fra stackoverflow - metoden opdaterer pulstextbox

            Dispatcher.Invoke(() =>
            {
                Puls_value_box.Text = text;
            }
                );
        }

        public void AddDisplayValues(BloodPressureData bp)
        {
            YValues.Add(Convert.ToInt16(bp.Værdi)); //SKAL add'e værdi!!!
            if (YValues.Count > 200)
            {
                YValues.RemoveAt(0);
            }
        }

        public void UpdateDiaSysTextbox(double sys, double dia)
        {
            //Fra stackoverflow - metoden opdaterer sysDia textbox
            //Dispatcher-metoden flytter kode fra baggrundstråden (tråd der kører udp-listener og udp-consumer) til foregrundstråden (GUI/Main-tråden). 
            //Når foregrundstråden har tid (Invoke), kører koden. Dispatcher gør, at GUI ikke crasher. 
            Dispatcher.Invoke(() =>
                {
                    BP_value_box.Text = Convert.ToString(Convert.ToInt16(sys)) + "/" + Convert.ToString(Convert.ToInt16(dia));
                }
            );
        }

        public void AlarmVisibility(List<double> sys, List<double> dia)
        {
            Dispatcher.Invoke(() =>
            {
                if (alarm.Visibility == Visibility.Hidden)
                {
                alarm1.StartAlarm(sys, dia);
                }

            }
           );
        }

        //Nedenstående kode får alarmen til at blinke
        //public void Alarmblink(int length, double repetition)
        //{
        //    DoubleAnimation opacityAlarm = new DoubleAnimation()
        //    {
        //        From = 0.0,
        //        To = 1.0,
        //        Duration = new Duration(TimeSpan.FromMilliseconds(length)),
        //        AutoReverse = true,
        //        RepeatBehavior = new RepeatBehavior(repetition)
        //    };
        //    Storyboard storyboard = new Storyboard();
        //    storyboard.Children.Add(opacityAlarm);
        //    Storyboard.SetTarget(opacityAlarm, alarm);
        //    Storyboard.SetTargetProperty(opacityAlarm, new PropertyPath("Opacity"));
        //    storyboard.Begin(alarm);
        //}

        // Ovenstående alarmmetode er sat ind i Alarm klassen i buisness laget ved at lave en constructor
        // i alarmklassen med en ellipse (WPF objecktet som bruges til alarmen) https://stackoverflow.com/questions/6114277/how-to-access-wpf-mainwindows-controls-from-another-class-in-the-same-namespace/11747955

        //public void AlarmSound()
        //{
        //    SoundPlayer alarm = new SoundPlayer("alarm1.wav");
        //    alarm.PlayLooping();

        //} Alarmsound er også flyttet i Alarmklassen


        /*
        public void Alarm()
        {
            BloodPressureData bloodPressureData = new BloodPressureData();
            Alarm a = new Alarm(alarm);
            ReadBloodPressureData bp = new ReadBloodPressureData();
            CalcBP cbp = new CalcBP();



            foreach (var item in cbp.GetSys())
            {
                SysList.Add(Convert.ToDouble(item));
            }

            DiaList = cbp.GetDia();
            SysList = cbp.GetSys();
            //foreach (var item in cbp.GetDia())
            //{
            //    DiaList.Add(Convert.ToDouble(item));
            //}

            Dispatcher.Invoke(() =>
                {
                    a.Alarmblink(SysList, DiaList, 250, 10);
                    //alarm.Visibility = Visibility.Visible;
                    //a.StartAlarm(SysList, DiaList);
                    //if (sys >= 10)
                    //{
                    //    alarm.Visibility = Visibility.Visible;
                    //    a.Alarmblink(100, 5);
                    //    a.AlarmSound();
                    //}
                }
            );
        }
        */

      

        private void GetData_button_Click(object sender, RoutedEventArgs e)
        {
            dataSaved_Box.Text = "A: " + A + " B: " + B;
        }
        
    }
}
