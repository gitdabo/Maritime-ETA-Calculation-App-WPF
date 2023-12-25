using MaritimeAppLibrary;
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
using System.Windows.Shapes;

namespace MOCAppWPF
{
    /// <summary>
    /// Interaction logic for ETAWindow.xaml
    /// </summary>
    public partial class ETAWindow : Window
    {
        public ETAWindow()
        {
            InitializeComponent();
        }
         
        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void calculateETAButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDistanceValid;
            bool isSpeedValid;

            isDistanceValid = double.TryParse(distanceTextBox.Text, out double distance);
            isSpeedValid = double.TryParse(speedTextBox.Text, out double speed);

            if(!isDistanceValid == true || !isSpeedValid == true)
            {
                ErrorMessageHandling();
            }

            else if (distance <= 0 || speed <= 0 )
            {
                ZeroErrorMessageHandling();
            }

            else
            {
                ComputeParameters parameters = new ComputeParameters();
                DisplayMessages display = new DisplayMessages();

                double eTA = parameters.GetETA(distance, speed);

                eTAResultLabel.Text = display.DisplayResult(eTA);

                durationResultLabel.Text = $"Duration is {eTA:N1} hrs or {eTA*60:N0} mins.";
            }

        }

        public void ZeroErrorMessageHandling()
        {
            MessageBox.Show("Parameter is out of range (must be > 0)", "Invalid Value", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ErrorMessageHandling()
        {
            MessageBox.Show("Please enter a value in the empty field or a Valid " +
                "value in each field", "Invalid Field",
                   MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
