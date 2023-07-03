using ST10159078_PROG6221_POE.Models;
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
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        private Recipe selectedRecipe;

        public ScaleRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            selectedRecipe = recipe;
        }

        public double GetScalingFactor()
        {
            double scalingFactor = 0.0;

            if (ShowDialog() == true)
            {
                if (double.TryParse(txtScalingFactor.Text, out scalingFactor))
                {
                    if (scalingFactor == 0.5 || scalingFactor == 2 || scalingFactor == 3)
                    {
                        return scalingFactor;
                    }
                    else
                    {
                        MessageBox.Show("Invalid scaling factor. Please enter 0.5, 2, or 3.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid scaling factor. Please enter a numeric value.", "Error");
                }
            }

            return 0.0;
        }

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
