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
    /// Interaction logic for RecipeSelectionWindow.xaml
    /// </summary>
    public partial class RecipeSelectionWindow : Window
    {
        private List<Recipe> recipes;

        public Recipe SelectedRecipe { get; private set; }

        public RecipeSelectionWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            PopulateRecipeList();
        }

        private void PopulateRecipeList()
        {
            lstRecipes.ItemsSource = recipes;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedItem != null)
            {
                SelectedRecipe = lstRecipes.SelectedItem as Recipe;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error");
            }
        }

        public Recipe GetSelectedRecipe()
        {
            return SelectedRecipe;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}