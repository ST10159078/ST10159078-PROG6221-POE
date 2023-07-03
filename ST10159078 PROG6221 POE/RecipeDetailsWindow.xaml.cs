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
    /// Interaction logic for RecipeDetailsWindow.xaml
    /// </summary>
    public partial class RecipeDetailsWindow : Window
    {
        private List<Ingredient> ingredients;
        private List<string> steps;

        public RecipeDetailsWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            IngredientDetailsWindow ingredientDetailsWindow = new IngredientDetailsWindow();
            ingredientDetailsWindow.ShowDialog();

            if (ingredientDetailsWindow.DialogResult == true)
            {
                Ingredient ingredient = ingredientDetailsWindow.GetIngredient();
                ingredients.Add(ingredient);
                lstIngredients.ItemsSource = ingredients;
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            StepDetailsWindow stepDetailsWindow = new StepDetailsWindow();
            stepDetailsWindow.ShowDialog();

            if (stepDetailsWindow.DialogResult == true)
            {
                string step = stepDetailsWindow.GetStep();
                steps.Add(step);
                lstSteps.ItemsSource = steps;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            if (ingredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.");
                return;
            }

            if (steps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public Recipe GetRecipe()
        {
            return new Recipe(txtRecipeName.Text, ingredients, steps);
        }
    }
}
