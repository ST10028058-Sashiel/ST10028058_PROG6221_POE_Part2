using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10028058_PROG6221_POE_Part2;
using System.Collections.Generic;

namespace ST10028058_PROG6221_POE_Part2.Tests
{
    [TestClass()]
    public class RecipeMethodsTests
    {
        [TestMethod]
        public void calcTotalCalories_AssertTrue()
        {
            // Arrange: Create a list of recipe ingredients with total calories exceeding 300
            var recipeIngredients = new List<RecipeIngredients>
          {
              new RecipeIngredients { Name = "Beans", Calories = 200 },
              new RecipeIngredients { Name = "Toast", Calories = 150 }
           };
            // Create a recipe with the prepared ingredients
            var recipe = new RecipeData { Ingredients = recipeIngredients };

            // Act: Call the method to calculate total calories
            double totalCalories = recipe.calcTotalCalories();

            // Assert: Verify that the total calories exceed 300
            Assert.IsTrue(totalCalories > 300);
        }

        [TestMethod]
        public void calcTotalCalories_AssertFalse()
        {
            // Arrange: Create a list of recipe ingredients with total calories not exceeding 300
            var recipeIngredients = new List<RecipeIngredients>
           {
             new RecipeIngredients { Name = "Beans", Calories = 150 },
             new RecipeIngredients { Name = "Toast", Calories = 100 }
           };
            // Create a recipe with the prepared ingredients
            var recipe = new RecipeData { Ingredients = recipeIngredients };

            // Act: Call the method to calculate total calories
            double totalCalories = recipe.calcTotalCalories();

            // Assert: Verify that the total calories do not exceed 300
            Assert.IsFalse(totalCalories > 300);
        }

    }
}
