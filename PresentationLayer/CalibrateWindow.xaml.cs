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
        private LineSeries calibrateLine;
        private MainWindow mainRef;

        public SeriesCollection Data { get; set; }

        public CalibrateWindow()
        {
            InitializeComponent();
            calibrateLine = new LineSeries();

            Data = new SeriesCollection();

            Data.Add(calibrateLine);

            mainRef = new MainWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Values_box.Focus();                                                                             //Cursor er i tekstboks, når vindue åbner
        }

        private void CalibrationGraph_Loaded(object sender, RoutedEventArgs e)
        {
            calibrateLine.Title = "Kalibreringspunkter";                                                    //Kurve-titel
            calibrateLine.Values = new ChartValues<double>();                                               //Kalibreringsværdier er at typen double
            DataContext = this;                                                                             
            calibrateLine.Fill = Brushes.Transparent;                                                       //Fjerner farve over kurven
        }

        private void calibrateButton_Click(object sender, RoutedEventArgs e)                                 
        {
            if (Values_box.Text != "")                                                                                     
            {
                calibrateLine.Values.Add(Convert.ToDouble(Values_box.Text));                                //Det indtastede tryk vises i grafen
                Values_box.Clear();                                                                         //Tekstboks nulstilles
                Values_box.Focus();                                                                         //Kurser er i tekstboksen
            }   
            else
            {
                Fejlmeddelese_Box.Text = "Indtast trykværdi";                                               //Fejlmeddelese, hvis der ikke er indtastet en værdi       
            }
        }

        private void logOffButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();                                                                                    //Når der logges af, skjules kalibreringsvindue
            mainRef.ShowDialog();                                                                           //og hovedvindue åbner

        }

        private void Values_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)                                                                         //Når trykværdi er indtastet, kan der trykeks "Kalibrer" ved at trykke Enter                                             
            {
                calibrateButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
