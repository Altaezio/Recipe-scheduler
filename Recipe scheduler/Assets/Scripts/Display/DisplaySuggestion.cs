using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySuggestion : MonoBehaviour
{
    [SerializeField]
    private SuggestionsManager suggestionsManager;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMP_InputField nbMeal;
    [SerializeField]
    private GameObject suggestionPrefab;

    private void Start()
    {
        suggestionsManager.ClearSuggestions += ClearSuggestionList;
        suggestionsManager.NewSuggestion += AddNewSuggestion;
        nbMeal.text = suggestionsManager.GetCourseNumber().ToString();
    }

    private void ClearSuggestionList()
    {
        foreach (Transform child in content.transform) Destroy(child);
    }

    private void AddNewSuggestion(RecipeData recipe)
    {
        GameObject newRecipe = Instantiate(suggestionPrefab, content.transform);
        newRecipe.GetComponent<InitialiseSuggestion>().InitialiseData(recipe, suggestionsManager);
    }
}
