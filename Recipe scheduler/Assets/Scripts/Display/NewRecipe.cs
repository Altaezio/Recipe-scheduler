using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewRecipe : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputName;
    [SerializeField]
    private TMP_InputField inputAuthor;
    [SerializeField]
    private GameObject popup, successCreatingRecipe, failCreatingRecipe;

    public string RecipeName { get; private set; }
    public string RecipeAuthor { get; private set; }
    public Dictionary<ESeason, bool> RecipeSeasons { get; private set; }
    public int RecipeCourse { get; private set; }
    public string RecipeDetails { get; private set; }

    private void OnEnable()
    {
        RecipeData currentRecipe = DisplayManager.Instance.currentRecipe;
        if (currentRecipe != null)
        {
            RecipeName = currentRecipe.Name;
            RecipeAuthor = currentRecipe.Author;
            inputName.interactable = false;
            inputAuthor.interactable = false;

            RecipeSeasons = currentRecipe.Seasons;
            RecipeCourse = (int)currentRecipe.Course;
            RecipeDetails = currentRecipe.RecipeDetails;
        }
        else
        {
            inputName.interactable = true;
            inputAuthor.interactable = true;
            RecipeSeasons = new Dictionary<ESeason, bool>
            {
                { ESeason.Winter, true },
                { ESeason.Spring, true },
                { ESeason.Summer, true },
                { ESeason.Autumn, true }
            };
        }
    }

    public void ModifyRecipe()
    {
        bool modificationResult = RecipesManager.Instance.ModifyRecipe(RecipeName, RecipeAuthor, RecipeSeasons, (ECourse)RecipeCourse, RecipeDetails);
        popup.SetActive(true);
        successCreatingRecipe.SetActive(modificationResult);
        failCreatingRecipe.SetActive(!modificationResult);
    }
    public void CheckWinter(bool value)
    {
        RecipeSeasons[ESeason.Winter] = value;
    }

    public void CheckSpring(bool value)
    {
        RecipeSeasons[ESeason.Spring] = value;
    }

    public void CheckSummer(bool value)
    {
        RecipeSeasons[ESeason.Summer] = value;
    }

    public void CheckAutumn(bool value)
    {
        RecipeSeasons[ESeason.Autumn] = value;
    }
}
