using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitialiseSuggestion : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI recipeName;

    private RecipeData recipeData;

    public void InitialiseData(RecipeData recipeData)
    {
        this.recipeData = recipeData;
        recipeName.text = recipeData.Name;
    }

    public void ShowRecipeInfo()
    {
        DisplayManager.Instance.GoToViewRecipe(recipeData);
    }
}
