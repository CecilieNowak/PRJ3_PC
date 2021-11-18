using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO_BloodPressureData;
using LiveCharts;
using LiveCharts.Wpf;
using BusinessLogicLayer;
using System.Threading;

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

            DisplayObserver observer = new DisplayObserver(subject,this);

            TEST_THREAD_LIVECHARTS threadTest = new TEST_THREAD_LIVECHARTS(this, subject);  //Test tråd oprettes
            Thread t1 = new Thread(threadTest.updateChart);
            t1.Start();
        }

       

        private void BP_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Puls_value_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveData_button_Click(object sender, RoutedEventArgs e)
        {
            
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
        }
    }
}
