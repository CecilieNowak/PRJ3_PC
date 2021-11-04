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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginWindow loginW;



        public MainWindow()
        {
            InitializeComponent();
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
            //Her skal der skrives noget kode, så når man klikker på kalibrer knappen, åbnes login vinduet. 
        }

        private void CPR_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
