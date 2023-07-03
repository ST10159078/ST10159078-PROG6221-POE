# ST10159078 PROG6221 POE

# Recipe Manager Application

This application allows you to manage recipes and scale them based on user input.

## Instructions

### Prerequisites
- .NET Framework 4.7 or later

### Compilation
1. Open the solution file `RecipeManager.sln` in Visual Studio.
2. Build the solution to compile the project.

### Running the Application
1. Locate the compiled executable file (e.g., `RecipeManager.exe`).
2. Double-click the executable to launch the application.

### Usage
1. Enter recipe details by clicking the "Add Recipe" button in the main window.
2. To scale a recipe, click the "Scale Recipe" button and select a recipe from the list.
3. Enter the scaling factor and click "OK" to scale the recipe.
4. View the scaled recipe details by clicking the "Display Recipe Details" button.

## Changes Made

In this update, the following changes have been made to the application:

1. Fixed an issue in the `DisplayRecipeDetails_Click` method where the selected recipe was not properly retrieved from the `RecipeSelectionWindow`.
2. Updated the `RecipeSelectionWindow` class to correctly set the `SelectedRecipe` property when a recipe is selected.
3. Added validation to ensure that an ingredient name is provided in the `OK_Click` method of `IngredientDetailsWindow`.
4. Updated the `Ingredient` class constructor in the `Ingredient.cs` file to include the required `foodGroup` parameter.


