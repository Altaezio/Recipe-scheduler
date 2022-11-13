using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SuggestionsManager : MonoBehaviour
{
    public event Action ClearSuggestions;
    public event Action<RecipeData> NewSuggestion;

    public List<RecipeData> Suggestions;

    [SerializeField]
    private ECourse course;

    private List<RecipeData> matchingRecipes;

    private void Start()
    {
        Suggestions = new List<RecipeData>();
        matchingRecipes = new List<RecipeData>();
        LoadMatchingRecipes();
    }

    public void LoadMatchingRecipes()
    {
        matchingRecipes = RecipesManager.Instance.RecipeDatas.FindAll((recipe) => recipe.MatchRequirement(OptionManager.playerOptions.Seasons, course));

    }

    public void SuggestRecipes()
    {
        Suggestions.Clear();
        ClearSuggestions?.Invoke();
        for (int i = 0; i < GetCourseNumber(); i++)
        {
            AddOneSuggestion();
        }
    }

    private void AddOneSuggestion()
    {
        RecipeData _newRecipe;
        _newRecipe = matchingRecipes[Random.Range(0, matchingRecipes.Count - 1)];
        Suggestions.Add(_newRecipe);
        NewSuggestion?.Invoke(_newRecipe);
    }

    private RecipeData RerollSuggestion()
    {
        if (matchingRecipes.Count > Suggestions.Count)
            return matchingRecipes.Find((recipe) => recipe.MatchRequirement(OptionManager.playerOptions.Seasons, course) && !Suggestions.Contains(recipe));
        else
            return matchingRecipes.Find((recipe) => recipe.MatchRequirement(OptionManager.playerOptions.Seasons, course));
    }

    private RecipeData ReplaceSuggestion(RecipeData toReplace, RecipeData replaceWith)
    {
        int index = Suggestions.FindIndex((_recipe) => _recipe.IsSameRecipe(toReplace));
        Suggestions[index] = replaceWith;
        return replaceWith;
    }

    public RecipeData Reroll(RecipeData recipeToReroll)
    {
        return ReplaceSuggestion(recipeToReroll, RerollSuggestion());
    }

    public int GetCourseNumber()
    {
        switch (course)
        {
            case ECourse.Appetizer:
                return OptionManager.playerOptions.nbAppetizer;
            case ECourse.Dessert:
                return OptionManager.playerOptions.nbDessert;
            case ECourse.Main:
            default:
                return OptionManager.playerOptions.nbMain;
        }
    }
}
