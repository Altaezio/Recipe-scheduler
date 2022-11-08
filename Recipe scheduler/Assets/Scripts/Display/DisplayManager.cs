using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public static DisplayManager Instance { get; private set; }

    [SerializeField]
    private GameObject main;
    [SerializeField]
    private GameObject recipesList;
    [SerializeField]
    private GameObject recipeModifier;
    [SerializeField]
    private GameObject recipeViewer;

    private Stack<GameObject> stackView;

    public RecipeData currentRecipe { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        stackView = new Stack<GameObject>();
        SetActiveFalseViews();
        NewView(main);
    }

    private void SetActiveFalseViews()
    {
        main.SetActive(false);
        recipesList.SetActive(false);
        recipeModifier.SetActive(false);
        recipeViewer.SetActive(false);
    }

    public void NewView(GameObject newView)
    {
        if (stackView.Count > 0) stackView.Peek().SetActive(false);
        newView.SetActive(true);
        stackView.Push(newView);
    }

    public void PreviousView()
    {
        stackView.Pop().SetActive(false);
        stackView.Peek().SetActive(true);
    }

    public void GoToViewRecipe(RecipeData data)
    {
        NewView(recipeViewer);
        currentRecipe = data;
    }

    public void GoToModifyRecipe(RecipeData data)
    {
        NewView(recipeModifier);
        currentRecipe = data;
    }

    public void GoAddRecipe()
    {
        currentRecipe = null;
        NewView(recipeModifier);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
