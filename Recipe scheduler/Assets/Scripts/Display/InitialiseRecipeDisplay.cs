using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitialiseRecipeDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI recipeName;
    [SerializeField]
    private Toggle toggle;

    private RecipeData recipeData;

    public void InitialiseData(RecipeData recipeData)
    {
        this.recipeData = recipeData;
        recipeName.text = recipeData.Name;
        toggle.isOn = recipeData.IsUsed;
    }

    public void ShowRecipeInfo()
    {
        DisplayManager.Instance.GoToViewRecipe(recipeData);
    }

    public void SetUsed(bool isUsed)
    {
        recipeData.IsUsed = isUsed;
    }

    public void GoModifyRecipe()
    {
        DisplayManager.Instance.GoToModifyRecipe(recipeData);
    }
}
