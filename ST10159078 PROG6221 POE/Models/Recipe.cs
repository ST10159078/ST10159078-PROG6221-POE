using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10159078_PROG6221_POE.Models
{
    public class Recipe
    {
        public string Name { get; }
        private List<Ingredient> ingredients;
        private List<string> steps;

        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            this.ingredients = ingredients;
            this.steps = steps;
        }
        public bool ContainsIngredient(string ingredientName)
        {
            return ingredients.Any(ingredient => ingredient.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));
        }


        public string FoodGroup { get; set; }
        public int Calories { get; set; }

        public string Display()
        {
            string displayText = $"Recipe: {Name}\n\nIngredients:\n";
            foreach (Ingredient ingredient in ingredients)
            {
                displayText += $"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}\n";
            }

            displayText += "\nSteps:\n";
            for (int i = 0; i < steps.Count; i++)
            {
                displayText += $"Step #{i + 1}: {steps[i]}\n";
            }

            displayText += $"\nTotal Calories: {TotalCalories()}";

            if (TotalCalories() > 300)
            {
                displayText += "\nWarning: This recipe exceeds 300 calories!";
            }

            return displayText;
        }

        public void Scale(double factor)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ScaleQuantity(factor);
            }
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public int TotalCalories()
        {
            return ingredients.Sum(i => i.Calories);
        }
    }
}