using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRecipeViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nom, author, course, recipe;
    [SerializeField]
    private Toggle winter, spring, summer, autumn;

    private void OnEnable()
    {
        RecipeData currentRecipe = DisplayManager.Instance.currentRecipe;
        if (currentRecipe != null)
        {
            nom.text = currentRecipe.Name;
            author.text = currentRecipe.Author;
            course.text = currentRecipe.Course.ToString();
            recipe.text = currentRecipe.RecipeDetails;

            winter.isOn = currentRecipe.Seasons[ESeason.Winter];
            spring.isOn = currentRecipe.Seasons[ESeason.Spring];
            summer.isOn = currentRecipe.Seasons[ESeason.Summer];
            autumn.isOn = currentRecipe.Seasons[ESeason.Autumn];

            string json = JsonUtility.ToJson(currentRecipe);
            Debug.Log(json);
        }
    }
}
