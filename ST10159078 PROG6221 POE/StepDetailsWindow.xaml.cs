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

namespace ST10159078_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for StepDetailsWindow.xaml
    /// </summary>
    public partial class StepDetailsWindow : Window
    {
        public StepDetailsWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStepDescription.Text))
            {
                MessageBox.Show("Please enter a step description.");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string GetStep()
        {
            return txtStepDescription.Text;
        }
    }
}