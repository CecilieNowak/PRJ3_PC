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
using LiveCharts.Configurations;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CalibrateWindow.xaml
    /// </summary>
    public partial class CalibrateWindow : Window
    {
        private readonly MainWindow _mainRef;                                                                                           //Reference til Main
        private GetADCvalues _getAdc;  //VED iKKE OM DEN SKAL BRUGES       *  //Til at få adc-værdi random                                                                                          //Attribut til at hente ADC value
                   
        private List<double> _pressureValuesList;                                                                                       //List til at gemme pressure values
        private List<int> pressureValue;                                                                                                //Liste med de trykværdier, trykkammeret skal indstilles til
        private List<double> _adcValuesList;                                                                                            //List til at gemme ADC values 
        private readonly ChartValues<Point> _values;
        private CalibrateObserver calibrateObserver;

       private BloodPressureSubject bpSubject;  //VED IKKE 

        public SeriesCollection Data { get; set; }                                                                                      //Pressure input and ADC value skal sættes i denne property
        public string PressureInput { get; set; }                                                                                       //Den indtastede trykværdi sættes i denne property

        public double ADCValue { get; set; } //VED IKKE //til at få adc-værdi fra observermønster (bpSubject)

        public CalibrateWindow(MainWindow mainRef, BloodPressureSubject bp) 
        {
            InitializeComponent();
            _mainRef = mainRef;
                                                                                                        //Reference til Main (bruges til log af)
            _pressureValuesList = new List<double>();                                                                                   //Nyt objekt oprettes 
            _adcValuesList = new List<double>();                                                                                        //Nyt objekt oprettes 
            _values = new ChartValues<Point>();
            pressureValue = new List<int>() {0, 25, 50, 125, 200, 250, 200, 125, 50, 25, 0};

            //bpSubject = new BloodPressureSubject(); //VED IKKE
            calibrateObserver = new CalibrateObserver(bp, this); //VED IKKE om der er skal være filter eller bpSubject //TODO uncomment

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Values_box.Focus();                                                                                                         //Kurser er i tekstboks, når vinduet åbner
            //_getAdc = new GetADCvalues(_mainRef._filter, _mainRef._subject); //UDKOMMENTERET - VED IKKE OM DEN SKAL BRUGES                                                                                            //Nyt objekt 
            _getAdc = new GetADCvalues(); //Til kalibreringstest med random værdier *
            insertValues_Box.Text = "Indstil tryk til 0 mmHg";                                                                          //Når vinduet åbner, udskrives denne streng
            Date_Box.Text = DateTime.Now.ToString("dd/MM/yyyy");
            calibrateButton.IsEnabled = true;

        }

        private void CalibrationGraph_Loaded(object sender, RoutedEventArgs e)
        {
            Data = new SeriesCollection                                                                                                 
            {
                new LineSeries
                {
                    Configuration = new CartesianMapper<Point>()
                        .X(point => point.X)
                        .Y(point => point.Y),
                    Title = "Kalibrering",
                    Values = _values,
                    Fill = Brushes.Transparent,

                }
            };
            DataContext = this;                                                                                                        //Punkterne vises på kalibreringsgrafen ved at vores livechart binder denne Data.                                                      

        }

        private String UpdatePressure(int idx)                                                                                        //Denne metode returnere den tekst, der skal udskrives i vinduet - ift. hvilket tryk der skal indstilles til 
        {
            return "Indstil tryk til " + pressureValue[idx] + " mmHg";
        }

        private void LinearRegression()
        {
            calibrateButton.IsEnabled = false;
            double[] adcValues = new double[11];                    //Array with x-values (adc [V])
            double[] pressureValues = new double[11];               //Array with y-values (pressure [mmHg]

            for (int i = 0; i < pressureValues.Length; i++)
            {
                pressureValues[i] = _pressureValuesList[i];
                adcValues[i] = _adcValuesList[i];
            }

            LinearRegression regression = new LinearRegression(adcValues, pressureValues);

            string a = Math.Round(regression.GetSlope(), 4).ToString();
            string b = Math.Round(regression.GetIntercept(), 4).ToString();
            string rSquared = Math.Round(regression.GetRSquared(), 4).ToString();

            if (regression.GetIntercept() < 0)
            {
                Regression_Box.Text = "y = " + a + "x" + b + "\n R^2 = " + rSquared;
            }
            else
            {
                Regression_Box.Text = "y = " + a + "x +  " + b + "\n R^2 = " + rSquared;
            }
            insertValues_Box.Text = "Kalibrering foretaget";

            _mainRef.A = Convert.ToDouble(a);       //Gemmer a i main
            _mainRef.B = Convert.ToDouble(b);       //Gemmer b i main
            
        }

        private void calibrateButton_Click(object sender, RoutedEventArgs e)
        {
            Fejlmeddelese_Box.Text = "";
            int num = -1;
            string input = Values_box.Text;

            if (input != "" && int.TryParse(input, out num) && (Convert.ToInt32(input) == pressureValue[_pressureValuesList.Count] || Convert.ToInt32(input) <= pressureValue[_pressureValuesList.Count] + 2 && Convert.ToInt32(input) >= pressureValue[_pressureValuesList.Count] - 2))              //Hvis userInput ikke er tom OG hvis userInput er en integer.
            {
                PressureInput = Values_box.Text;                                                                                    //Tryk input gemmes i en variabel
                double userInput = Convert.ToDouble(PressureInput);
                //double adcValue = Convert.ToDouble(_getAdc.getADCvaluesFromDataLayer()); //til at teste adc værdi random 
                //double adcValue = Convert.ToDouble(_getAdc.GetADCvaluesFromDataLayer()); //til at teste adc værdi fra rpi

                double adcValue = ADCValue; //VED IKKE *      //Til at teste adc værdi fra bpSubject (observermønster)

                var point = new Point() { X = adcValue, Y = userInput};                                                             //Der oprettes et nyt punkt. X = adc-værdi, Y = indtastet trykværdi
                _values.Add(point);                                                                                                 //Punktet tilføjes til grafen - altså plottes

                Values_box.Clear();
                Values_box.Focus();

                _pressureValuesList.Add(userInput);                                                                                 //Trykværdi gemmes i en liste, så den kan bruges til at lave regression 
                _adcValuesList.Add(adcValue);                                                                                       //ADC-værdi gemmes i en liste, så den kan bruges til at lave regression  

                if (_pressureValuesList.Count < 11)
                {
                    insertValues_Box.Text = UpdatePressure(_pressureValuesList.Count);
                }
                else if (_pressureValuesList.Count == 11)
                {
                    //calibrateButton.IsEnabled = false;
                    LinearRegression();
                }
            }
            else
            {
                Fejlmeddelese_Box.Text = "Indtast trykværdi";
                Values_box.Clear();
                Values_box.Focus();
            }

        }

        private void LogOffButton_Click(object sender, RoutedEventArgs e)
        {
            //Environment.Exit(0);
            this.Hide();                                                                                                           //Når der logges af, skjules kalibreringsvindue
           _mainRef.PrepMainWindow();
            //_mainRef.ShowDialog();     
            _mainRef.Show();
            
            //og hovedvindue åbner
        }
    }
}

/*
 CalibrateGraph_Loaded:
 Der oprettes en ny instans af Data. Der oprettes også en ny kurve (LineSeries),som tilføjes til Data. 
 I kalibreringskurven tilføjes der punkter (Point), som består af et X- og Y-koordinat.
 Kurven får titlen "Kalibrering". Når der laves et nyt punkt, sættes det i Values.
 Farve under graf fjernes.
 */
