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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ST10159078_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe selectedRecipe;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void EnterRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow();
            recipeDetailsWindow.ShowDialog();

            if (recipeDetailsWindow.DialogResult == true)
            {
                Recipe recipe = recipeDetailsWindow.GetRecipe();
                recipes.Add(recipe);
                MessageBox.Show("Recipe details entered successfully!");
            }
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                string recipeList = string.Join("\n", recipes.OrderBy(r => r.Name).Select(r => r.Name));
                MessageBox.Show($"All Recipes:\n-------------\n{recipeList}");
            }
            else
            {
                MessageBox.Show("No recipes found. Please enter recipe details first.");
            }
        }

        private void DisplayRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                RecipeSelectionWindow recipeSelectionWindow = new RecipeSelectionWindow(recipes);
                bool? result = recipeSelectionWindow.ShowDialog();

                if (result == true)
                {
                    Recipe selectedRecipe = recipeSelectionWindow.GetSelectedRecipe();

                    if (selectedRecipe != null)
                    {
                        MessageBox.Show(selectedRecipe.Display(), "Recipe Details");
                    }
                }
            }
            else
            {
                MessageBox.Show("No recipes found. Please enter recipe details first.");
            }
        }



        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                RecipeSelectionWindow recipeSelectionWindow = new RecipeSelectionWindow(recipes);
                recipeSelectionWindow.ShowDialog();

                if (recipeSelectionWindow.DialogResult == true)
                {
                    Recipe selectedRecipe = recipeSelectionWindow.GetSelectedRecipe();

                    ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow(selectedRecipe);
                    double scalingFactor = scaleRecipeWindow.GetScalingFactor();

                    if (scalingFactor != 0.0)
                    {
                        selectedRecipe.Scale(scalingFactor);
                        MessageBox.Show("Recipe scaled successfully!");
                    }
                }
            }
            else
            {
                MessageBox.Show("No recipes found. Please enter recipe details first.");
            }
        }


        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                RecipeSelectionWindow recipeSelectionWindow = new RecipeSelectionWindow(recipes);
                recipeSelectionWindow.ShowDialog();

                if (recipeSelectionWindow.DialogResult == true)
                {
                    selectedRecipe = recipeSelectionWindow.GetSelectedRecipe();
                    selectedRecipe.ResetQuantities();
                    MessageBox.Show("Quantities reset successfully!");
                }
            }
            else
            {
                MessageBox.Show("No recipes found. Please enter recipe details first.");
            }
        }

        private void ClearAllData_Click(object sender, RoutedEventArgs e)
        {
            recipes.Clear();
            MessageBox.Show("All data cleared successfully!");
        }
    }
}
