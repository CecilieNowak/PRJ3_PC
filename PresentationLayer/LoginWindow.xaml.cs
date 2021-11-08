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
using BusinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow _mainWRef;
        private CheckLogin _logicRef;

        public LoginWindow(MainWindow mainW, CheckLogin logicRef)
        {
            InitializeComponent();
            _mainWRef = mainW;
            _logicRef = logicRef;
        }

        private void LogIn_button_Click(object sender, RoutedEventArgs e)
        {
            if (_logicRef.LoginCheck(Username_txtbox.Text, Password_txtbox.Text) == true)
            {
                _mainWRef.LoginOk = true;
                _mainWRef.Username = Username_txtbox.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Fejl i brugernavn eller adgangskode");
                Username_txtbox.Text = ""; 
                Username_txtbox.Text = "";
                Username_txtbox.Focus();
            }
        }
    }
}
