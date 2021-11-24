using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using BusinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CalibrateWindow.xaml
    /// </summary>
    public partial class CalibrateWindow : Window
    {
        private readonly LineSeries _calibrateLine;
        private readonly MainWindow _mainRef;
        private getADCvalues _getAdc;

        public SeriesCollection Data { get; set; }
        public ChartValues<string> ADCValues { get; set; }

        public CalibrateWindow()
        {
            InitializeComponent();
            _calibrateLine = new LineSeries();
            Data = new SeriesCollection {_calibrateLine};        //Data = new SeriesCollection(); Data.Add(_calibrateLine);
            _mainRef = new MainWindow();
            ADCValues = new ChartValues<string>();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Values_box.Focus();
            _getAdc = new getADCvalues();
            insertValues_Box.Text = "Indstil tryk til 0 mmHg";
        }

        private void CalibrationGraph_Loaded(object sender, RoutedEventArgs e)
        {
            _calibrateLine.Title = "Kalibreringspunkter";
            _calibrateLine.Values = new ChartValues<double>();
            DataContext = this;
            _calibrateLine.Fill = Brushes.Transparent;                                                       //Fjern farve under graf

        }

        private void calibrateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Values_box.Text != "")
            {
                _calibrateLine.Values.Add(Convert.ToDouble(Values_box.Text));                                //Det indtastede tryk vises i grafen
                Values_box.Clear();                                                                          //Tekstboks nulstilles
                Values_box.Focus();                                                                          //Kurser er i tekstboksen
                ADCValues.Add(Convert.ToString(_getAdc.getADCvaluesFromDataLayer()));                   //ADC værdier læses fra datalaget, og gemmes i Chartvalueslisten, som er bundet til grafens x-akser;;
            }
            else
            {
                Fejlmeddelese_Box.Text = "Indtast trykværdi";                                                //Fejlmeddelese, hvis der ikke er indtastet en værdi       
            }
        }

        private void logOffButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();                                                                                     //Når der logges af, skjules kalibreringsvindue
            _mainRef.ShowDialog();                                                                           //og hovedvindue åbner

        }

        private void Values_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)                                                                          //Når trykværdi er indtastet, kan der trykeks "Kalibrer" ved at trykke Enter                                             
            {
                calibrateButton_Click(this, new RoutedEventArgs());
            }
        }

        private void CalibrateDone_Button_Click(object sender, RoutedEventArgs e)
        {
            double[] adcValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };                                          //Array with x-values (adc [V])
            double[] pressureValues = { 2, 3, 5, 6, 8, 9, 10, 12, 14, 15 };                                  //Array with y-values (pressure [mmHg]

            LinearRegression regression = new LinearRegression(adcValues, pressureValues);

            string a = Math.Round(regression.GetSlope(), 4).ToString();
            string b = Math.Round(regression.GetIntercept(), 4).ToString();
            string rSquared = Math.Round(regression.GetRSquared(), 4).ToString();

            Regression_Box.Text = "y = " + a + " + " + b + "x\n R^2 = " + rSquared;
        }
    }
}
