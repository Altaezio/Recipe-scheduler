using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySuggestion : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject suggestionPrefab;

    private void DisplaySuggestionList()
    {
        foreach (Transform child in content.transform) Destroy(child);
        /*foreach (RecipeData recipe in suggestions)
        {
            AddNewSuggestion(recipe);
        }*/ // Il faut faire le système de suggestion séparément de l'affichage
    }

    private void AddNewSuggestion(RecipeData recipe)
    {
        GameObject newRecipe = Instantiate(suggestionPrefab, content.transform);
        newRecipe.GetComponent<InitialiseSuggestion>().InitialiseData(recipe);
    }
}
