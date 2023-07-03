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
    /// Interaction logic for IngredientDetailsWindow.xaml
    /// </summary>
    public partial class IngredientDetailsWindow : Window
    {
        public IngredientDetailsWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text))
            {
                MessageBox.Show("Please enter an ingredient name.");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public Ingredient GetIngredient()
        {
            if (!int.TryParse(txtCalories.Text, out int calories))
            {
                MessageBox.Show("Please enter a valid calorie value.");
                return null;
            }

            return new Ingredient(txtIngredientName.Text, double.Parse(txtQuantity.Text), txtUnit.Text, calories, txtFoodGroup.Text);
        }

    }
}