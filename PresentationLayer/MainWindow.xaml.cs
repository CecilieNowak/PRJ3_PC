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


namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CheckLogin _logicobj;
        private LoginWindow _loginW;
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

            DisplayObserver observer = new DisplayObserver(subject, this);

            AlarmObserver aObserver = new AlarmObserver(subject, this);

            BlockingCollection <BloodPressureData> dataQueue= new BlockingCollection<BloodPressureData>();

            // Må ikke slettes!!


            
           //      Test med UDP-kommunikation
           Test_tråd_2 testTråd = new Test_tråd_2(dataQueue, subject);
           Thread t1 = new Thread(testTråd.updateChart);

           //      Test med randomme DTO'er i stedet for UDP-kommunikation
           //TEST_THREAD_LIVECHARTS threadTest = new TEST_THREAD_LIVECHARTS(this, subject);  //Test tråd oprettes
          //Thread t1 = new Thread(threadTest.updateChart);

          t1.Start();

          
        }



        private void BP_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Puls_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool checkCPR(string number)
        {
            int[] integer = new int[10];

            if (number.Length != 10)                                    // Hvis antal cifre er forkert returnes false
                return false;

            for (int index = 0; index < 10; index++)
            {
                if (number[index] < '0' || '9' < number[index])         // Hvis karakteren på plads index i den modtagne streng ikke er et tal returnes false
                    return false;

                integer[index] = Convert.ToInt16(number[index]) - 48;       // Karakteren på plads index konverteres til den tilhørende integer - eksempel '6' konverteres til 6
            }

            return true;
        }

        private void SaveData_button_Click(object sender, RoutedEventArgs e)
        {
            SendToDatabase send = new SendToDatabase();
            string socSecNb = CPR_txtbox.Text;


            if (checkCPR(socSecNb) == true) //Hvis det intastede CPR i tekstboksen er gyldig sker følgende:
            {
                send.SendData(socSecNb);
                dataSaved_Box.Text = "Data er sendt";
            }

            else
            {
                MessageBox.Show("Ugyldigt CPR"); //Hvis det intastede CPR i tekstboksen er ugyldig sker følgende:
            }
            
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

        public void updatePulseTextBox(string text)
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
            SoundPlayer s = new SoundPlayer("sonnette_reveil.wav");
            s.PlayLooping();
        }
    }
}
