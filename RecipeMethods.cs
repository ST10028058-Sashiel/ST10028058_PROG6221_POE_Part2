using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10028058_PROG6221_POE_Part2
{
    public class RecipeMethods
    {
        // List to store all recipes
        private List<RecipeData> recipes = new List<RecipeData>();

        // Delegate for calorie notification
        public delegate void CalorieNotification(string message);

        // Event for calorie notification
        public event CalorieNotification Notify;

        // Constructor to subscribe the notification method to the Notify event
        public RecipeMethods()
        {
            Notify += Notification;
        }

        // Method to enter details of a new recipe
        public void RecipeDetails()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Recipe Details");
            Console.WriteLine("---------------------\n");
            Console.ResetColor();
            Console.WriteLine("Please Enter Recipe Name");
            string recipeName = Console.ReadLine();

            List<RecipeIngredients> ingredients = new List<RecipeIngredients>();
            List<RecipeDescription> steps = new List<RecipeDescription>();

            int ingredientCount;
            // Loop to ensure valid input for ingredient count
            while (true)
            {
                Console.Write("\nEnter the number of ingredients: ");
                if (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount < 1)
                {
                    Console.WriteLine("Error: Invalid input format or value. Please enter a valid positive integer for ingredient count.");
                }
                else
                {
                    break;
                }
            }

            // Loop to enter details for each ingredient
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"\nPlease enter details for the ingredient {i + 1}:");
                Console.Write("Name of Ingredient: ");
                string name = Console.ReadLine();
                double quantity;

                // Loop to ensure valid input for ingredient quantity
                while (true)
                {
                    Console.Write("Quantity of Ingredient: ");
                    if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Error: Invalid input format or value. Please enter a valid positive number for quantity.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Unit of Measure (e.g., cups, spoons, grams): ");
                string unit = Console.ReadLine();

                double calories;
                // Loop to ensure valid input for ingredient calories
                while (true)
                {
                    Console.Write("Calories: ");
                    if (!double.TryParse(Console.ReadLine(), out calories) || calories < 0)
                    {
                        Console.WriteLine("Error: Invalid input format or value. Please enter a valid non-negative number for calories.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                // Add the ingredient to the list
                ingredients.Add(new RecipeIngredients { Name = name, Quantity = quantity, OriginalQuantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            }

            int stepCount;
            // Loop to ensure valid input for step count
            while (true)
            {
                Console.Write("\nPlease enter the number of steps: ");
                if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount < 1)
                {
                    Console.WriteLine("Error: Invalid input format or value. Please enter a valid positive integer for step count.");
                }
                else
                {
                    break;
                }
            }

            // Loop to enter details for each step
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"\nPlease enter step {i + 1}: ");
                string description = Console.ReadLine();
                steps.Add(new RecipeDescription { recipeDescription = description });
            }

            // Add the new recipe to the list of recipes
            recipes.Add(new RecipeData { Name = recipeName, Ingredients = ingredients, Steps = steps });

            // Check for calorie notification
            double totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                Notify?.Invoke($"The recipe '{recipeName}' exceeds 300 calories with a total of {totalCalories} calories.");
            }
        }

        // Method to display all recipes
        public void DisplayAllRecipes()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("All Recipes");
            Console.WriteLine("===========\n");
            Console.ResetColor();

            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            // Display recipes sorted by name
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to display a specific recipe
        public void DisplaySpecificRecipe()
        {
            DisplayAllRecipes();

            if (recipes.Count == 0)
            {
                return;
            }

            Console.Write("\nEnter the name of the recipe you want to display: ");
            string recipeName = Console.ReadLine();

            // Find the recipe by name
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            // Display the recipe details
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Recipe Details");
            Console.WriteLine("==============\n");
            Console.ResetColor();

            Console.WriteLine("Recipe Name: " + recipe.Name);
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i].recipeDescription}");
            }

            double totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            Console.WriteLine($"\nTotal Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");
                Console.ResetColor();
            }
        }

        // Method to scale ingredients of a specific recipe
        public void ScaleIngredients(double factor)
        {
            Console.Write("Enter the name of the recipe to scale: ");
            string recipeName = Console.ReadLine();

            // Find the recipe by name
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("\nRecipe not found.");
                return;
            }

            // Scale each ingredient quantity by the specified factor
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= factor;
            }

            // Display the scaled recipe details
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Scaled Recipe");
            Console.WriteLine("=============\n");
            Console.ResetColor();

            Console.WriteLine("Recipe Name: " + recipe.Name);
            Console.WriteLine("\nScaled Recipe Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
        }

        // Method to reset ingredient quantities to their original values
        public void ResetQuantities()
        {
            Console.Write("Enter the name of the recipe to reset: ");
            string recipeName = Console.ReadLine();

            // Find the recipe by name
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("\nRecipe not found.");
                return;
            }

            // Reset each ingredient quantity to its original value
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        // Method to clear all recipe data
        public void ClearData()
        {
            recipes.Clear();
        }

        // Method to handle calorie notification
        private void Notification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
