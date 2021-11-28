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
using DataAccessLayer;
using DTO_BloodPressureData;


namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CheckLogin _logicobj;
        private readonly LoginWindow _loginW;
        private CalibrateWindow _calibrateW;

        public bool LoginOk { get; set; }
        public String Username { get; set; }

        public ChartValues<int> YValues { get; set; }   //YValues til puls graf
        public ChartValues<int> XValues { get; set; }   //XValues til puls graf
        public MainWindow()
        {
            InitializeComponent();
            _logicobj = new CheckLogin();
            _loginW = new LoginWindow(this, _logicobj);


            YValues = new ChartValues<int>();   
            XValues = new ChartValues<int>();
            DataContext = this;

            BloodPressureSubject subject = new BloodPressureSubject();

            //Gammel DisplayObserver - Må ikke slettes!

            //DisplayObserver observer = new DisplayObserver(subject, this);

            Filter filter = new Filter(subject);
            DisplayObserver display = new DisplayObserver(filter, this);

            AlarmObserver aObserver = new AlarmObserver(subject, this);


            BlockingCollection <BloodPressureData> dataQueue= new BlockingCollection<BloodPressureData>();




            // Må ikke slettes!!


            // Test med UDP-kommunikation
            //UDPListener udpListener = new UDPListener(dataQueue);
            //UDP_Consumer udpConsumer = new UDP_Consumer(dataQueue, subject);
            // Thread t2 = new Thread(udpListener.StartListener);
            //Thread t1 = new Thread(udpConsumer.UpdateChart);


            //Test med simulator
            UDPListener_Simulator listenerSimulator = new UDPListener_Simulator(dataQueue);
            UDP_Consumer udpConsumer = new UDP_Consumer(dataQueue, subject);
            Thread t2 = new Thread(listenerSimulator.StartListener);
            Thread t1 = new Thread(udpConsumer.UpdateChart);
            t1.Start();
            t2.Start();

        }



        private void BP_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Puls_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveData_button_Click(object sender, RoutedEventArgs e)
        {
            SendToDatabase send = new SendToDatabase();
            string socSecNb = CPR_txtbox.Text;
            send.SendData(socSecNb);
            MessageBox.Show("Data er sendt");
        }

        private void Calibrate_button_Click(object sender, RoutedEventArgs e)
        {
            _calibrateW = new CalibrateWindow();

            this.Hide();                                                                        //Når der klikkes på Kalibrer-knappen, lukker hovedvindue
            _loginW.ShowDialog();                                                               //og Loginvindue vises

            if (LoginOk == true)
            {
                _calibrateW.ShowDialog(); //Hvis Login er ok, fuldføres login, og vi til kalibreringsvindue
            }
            else
            {
                this.Close();
            }
        }

        private void CPR_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Close_button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);                                                                //Program lukker, når der trkkes på Luk-knappen
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Date_box.Text = DateTime.Now.ToString("dd/MM/yyyy");                        //Dato vises på UI
                                                                                        //Der skal måske også være kode til at vise tid her
            //SoundPlayer s = new SoundPlayer("sonnette_reveil.wav");
            //s.PlayLooping();
        }
    }
}
