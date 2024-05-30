using System;
using System.Collections.Generic;

namespace ST10028058_PROG6221_POE_Part2
{
    // Class to represent the data for a recipe
    public class RecipeData
    {
        // Property to store the name of the recipe
        public string Name { get; set; }

        // Property to store the list of ingredients for the recipe
        public List<RecipeIngredients> Ingredients { get; set; } = new List<RecipeIngredients>();

        // Property to store the list of steps for the recipe
        public List<RecipeDescription> Steps { get; set; } = new List<RecipeDescription>();

        // Delegate for the event triggered when total calories exceed a threshold
        public delegate void CaloriesExceededEventHandler(object sender, EventArgs e);

        // Event triggered when total calories exceed 300
        public static event CaloriesExceededEventHandler CaloriesExceeded;

        // Method to calculate the total calories of the recipe
        public double calcTotalCalories()
        {
            double totalCalories = 0;
            // Calculate the sum of calories from all ingredients
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Trigger the event if total calories exceed 300
            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(this, EventArgs.Empty);
            }

            return totalCalories; // Return the total calorie count
        }
    }
}
