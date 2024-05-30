using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10028058_PROG6221_POE_Part2
{
    // Main class
    class Recipe
    {

        RecipeMethods methods = new RecipeMethods();

        // Main method 
        static void Main(string[] args)
        {
            // Create an instance of the Recipe class
            Recipe recipe = new Recipe();
            while (true)
            {
                Console.Clear(); // Clear the console
                Console.WriteLine("Welcome to Recipe App");
                Console.WriteLine("-------------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display Specific Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear Data");
                Console.WriteLine("7. Exit");

                // Variable to store user's menu choice
                int option;
                // Validate user input to ensure it's a number
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("\nInvalid input. Please enter a number.");
                    Console.ReadLine();
                    continue; // Restart the loop
                }

                // Switch case to handle menu options
                switch (option)
                {
                    case 1:
                        // Enter recipe details
                        recipe.methods.RecipeDetails();
                        Console.WriteLine("\nRecipe details entered successfully.");
                        Console.ReadLine(); // Pause for user to read message
                        break;
                    case 2:
                        // Display all recipes
                        recipe.methods.DisplayAllRecipes();
                        Console.ReadLine(); // Pause for user to read message
                        break;
                    case 3:
                        // Display a specific recipe
                        recipe.methods.DisplaySpecificRecipe();
                        Console.ReadLine(); // Pause for user to read message
                        break;
                    case 4:
                        // Scale recipe
                        double scale;
                        Console.Write("\nEnter scaling amount (0.5, 2, or 3): ");
                        // Validate user input to ensure it's a number
                        if (!double.TryParse(Console.ReadLine(), out scale))
                        {
                            Console.WriteLine("\nInvalid input. Please enter a number.");
                            Console.ReadLine();
                            continue; // Restart the loop
                        }
                        // Validate the scaling factor
                        if (scale != 0.5 && scale != 2 && scale != 3)
                        {
                            Console.WriteLine("\nInvalid scaling factor. Please enter 0.5, 2, or 3.");
                            Console.ReadLine();
                            continue; // Restart the loop
                        }
                        // Scale the ingredients
                        recipe.methods.ScaleIngredients(scale);
                        Console.WriteLine("\nRecipe scaled successfully.");
                        Console.ReadLine(); // Pause for user to read message
                        break;
                    case 5:
                        // Reset ingredient quantities to original values
                        recipe.methods.ResetQuantities();
                        Console.WriteLine("\nQuantities reset successfully.");
                        Console.ReadLine(); // Pause for user to read message
                        break;
                    case 6:
                        // Clear all recipe data
                        recipe.methods.ClearData();
                        Console.WriteLine("\nData cleared successfully.");
                        Console.ReadLine(); // Pause for user to read message
                        break;
                    case 7:
                        // Exit the application
                        Environment.Exit(0);
                        break;
                    default:
                        // Handle invalid menu options
                        Console.WriteLine("\nInvalid option.");
                        Console.ReadLine(); // Pause for user to read message
                        break;
                }
            }
        }
    }
}
