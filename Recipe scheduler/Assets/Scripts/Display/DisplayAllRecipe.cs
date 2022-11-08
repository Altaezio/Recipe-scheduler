using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAllRecipe : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject recipePrefab;

    private void Start()
    {
        SetRecipeList();
        RecipesManager.Instance.OnAddRecipeData += AddNewRecipe;
    }

    private void SetRecipeList()
    {
        foreach (Transform child in content.transform) Destroy(child);
        foreach (RecipeData recipe in RecipesManager.Instance.RecipeDatas)
        {
            AddNewRecipe(recipe);
        }
    }

    private void AddNewRecipe(RecipeData recipe)
    {
        GameObject newRecipe = Instantiate(recipePrefab, content.transform);
        newRecipe.GetComponent<InitialiseRecipeDisplay>().InitialiseData(recipe);
    }
}
