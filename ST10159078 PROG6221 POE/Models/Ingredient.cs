using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10159078_PROG6221_POE.Models
{
    public class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; private set; }
        public string Unit { get; }
        public int Calories { get; }
        public string FoodGroup { get; }

        private double originalQuantity;

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            originalQuantity = quantity;
        }

        public void ScaleQuantity(double factor)
        {
            Quantity = originalQuantity * factor;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }
    }
}