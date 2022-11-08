using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    public static RecipesManager Instance { get; private set; }

    public List<RecipeData> RecipeDatas { get; private set; }

    public event Action<RecipeData> OnAddRecipeData;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        RecipeDatas = InitialiseData();
    }

    /// <summary>
    /// Initialise data for the recipe list
    /// </summary>
    /// <returns>The list filled with recipes</returns>
    public List<RecipeData> InitialiseData()
    {
        return new List<RecipeData>();
    }

    /// <summary>
    /// Function to modify an existing recipe
    /// Or to create a new one if none of the same name exists
    /// </summary>
    /// <param name="name">The name of the recipe</param>
    /// <param name="author">The name of the author of this recipe</param>
    /// <param name="seasons">The seasons when you can cook this recipe</param>
    /// <param name="course">When to eat the recipe</param>
    /// <param name="recipeDetails">The details of the recipe</param>
    public void ModifyRecipe(string name, string author, Dictionary<ESeason, bool> seasons = null, ECourse course = ECourse.Main, string recipeDetails = null)
    {
        RecipeData recipeMatch = RecipeDatas.Find((data) => data.IsSameRecipe(name, author));
        if (recipeMatch is null)
        {
            RecipeData newRecipe = new RecipeData(name, author, seasons, course, recipeDetails);
            RecipeDatas.Add(newRecipe);
            OnAddRecipeData?.Invoke(newRecipe);
            return;
        }
        recipeMatch.Modify(seasons, course, recipeDetails);
    }
}
