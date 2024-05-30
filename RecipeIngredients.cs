using System;

namespace ST10028058_PROG6221_POE_Part2
{
    // Class to represent the ingredients used in a recipe
    public class RecipeIngredients
    {
        // Property to store the name of the ingredient
        public string? Name { get; set; }

        // Property to store the quantity of the ingredient
        public double Quantity { get; set; }

        // Property to store the original quantity of the ingredient
        public double OriginalQuantity { get; set; }

        // Property to store the unit of measurement for the ingredient (e.g., grams, cups, etc.)
        public string? Unit { get; set; }

        // Property to store the calories of the ingredient
        public double Calories { get; set; }

        // Property to store the food group of the ingredient (e.g., dairy, protein, etc.)
        public string? FoodGroup { get; set; }
    }
}
