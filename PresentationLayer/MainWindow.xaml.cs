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
        private BloodPressureSubject _subject;
        private CalibrateWindow _calibrateW;
        private Filter _filter; 
        private SendToDatabase send;
        private SaveDataToTxtfile saveData;
        private CheckCPR _checkCPR;
        private LogFileObserver logFile;
        private Storyboard _st;
        private Alarm alarm1;
        private CalibrateValuesFile calibrateValues;
        

        public bool LoginOk { get; set; }
        public ChartValues<double> YValues { get; set; }   //YValues til puls graf //Jeg har ændret fra int til double
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
            
            YValues = new ChartValues<double>(); 
            XValues = new ChartValues<string>();
            DataContext = this;

            send = new SendToDatabase();
            calibrateValues = new CalibrateValuesFile();
            saveData = new SaveDataToTxtfile();
            
            //Observers
            DisplayObserver display = new DisplayObserver(_filter, this);
            AlarmObserver aObserver = new AlarmObserver(_filter, this, alarm);
            logFile = new LogFileObserver(_filter, saveData);
            _filter = new Filter(_subject);
            
            //Alarm
            alarm1 = new Alarm(alarm, AlarmLabel, _st, Dispatcher);
            Storyboard st = new Storyboard();

            //Tråd UDP - kommunikation
            BlockingCollection<BloodPressureData> dataQueue = new BlockingCollection<BloodPressureData>();
            UDP_Listener_BLL udpListener = new UDP_Listener_BLL(dataQueue);
            UDP_Consumer udpConsumer = new UDP_Consumer(dataQueue, _subject);
            Thread t2 = new Thread(udpListener.startUDPListener);
            Thread t3 = new Thread(udpConsumer.UpdateChart);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Date_box.Text = DateTime.Now.ToString("dd/MM/yyyy");                        //Dato vises på UI                                                                   //Der skal måske også være kode til at vise tid her
            alarm.Visibility = Visibility.Hidden;
            AlarmLabel.Visibility = Visibility.Hidden;
            A = calibrateValues.ReadFromFile().A;
            B = calibrateValues.ReadFromFile().B;
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
            _calibrateW = new CalibrateWindow(this, _subject);
            PrepCalibrateWindow();
            this.Hide();
            _loginW.ShowDialog(); 

            if (LoginOk)
            {
                _calibrateW.ShowDialog(); 
              
            }
        }

        private void Close_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); 
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
            double value = Convert.ToDouble(bp.Værdi);
            double calValue = (A * value) + B; 

            YValues.Add(calValue); //SKAL add'e værdi!!!
            if (YValues.Count > 100)
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
                    double sysCalibrate = (A * sys) + B;  //Omregner ADC værdi(Diastolisk) til mmHg
                    double diaCalibrate = (A * dia) + B;  //Omregner ADC værdi (Systolisk) til mmHg

                    BP_value_box.Text = Convert.ToString(Convert.ToInt16(sysCalibrate)) + "/" + Convert.ToString(Convert.ToInt16(diaCalibrate));
                }
            );
        }

        public void AlarmVisibility(List<double> sys)
        {

            Dispatcher.Invoke(() =>
            {
                if (alarm.Visibility == Visibility.Hidden)
                {
                    alarm1.StartAlarm(sys);
                }
            }
            );
        }

        // alarmmetode er sat ind i Alarm klassen i buisness laget ved at lave en constructor
        // i alarmklassen med en ellipse (WPF objecktet som bruges til alarmen) https://stackoverflow.com/questions/6114277/how-to-access-wpf-mainwindows-controls-from-another-class-in-the-same-namespace/11747955

    }
}
