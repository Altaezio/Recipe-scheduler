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
    }

    private void Start()
    {
        RecipeDatas = InitialiseData();
    }

    /// <summary>
    /// Initialise data for the recipe list
    /// </summary>
    /// <returns>The list filled with recipes</returns>
    public List<RecipeData> InitialiseData()
    {
        return SaveSystem.LoadData();
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
    /// <returns>True if everything went well</returns>
    public bool ModifyRecipe(string name, string author, Dictionary<ESeason, bool> seasons = null, ECourse course = ECourse.Main, string recipeDetails = null)
    {
        if (name.Length == 0 || author.Length == 0) return false;

        RecipeData recipeMatch = RecipeDatas.Find((data) => data.IsSameRecipe(name, author));
        if (recipeMatch is null)
        {
            RecipeData newRecipe = new(name, author, seasons, course, recipeDetails);
            RecipeDatas.Add(newRecipe);
            OnAddRecipeData?.Invoke(newRecipe);
            return true;
        }
        recipeMatch.Modify(seasons, course, recipeDetails);
        return true;
    }
}
