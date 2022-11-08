using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeData
{
    // Data
    private string name;
    private string author;
    private Dictionary<ESeason, bool> seasons;
    private ECourse course;
    private string recipeDetails;

    // Logic
    private bool inUse;

    public string Name { get => name; private set { } }
    public string Author { get => author; private set { } }
    public Dictionary<ESeason, bool> Seasons { get => seasons; private set { } }
    public ECourse Course { get => course; private set { } }
    public string RecipeDetails { get => recipeDetails; private set { } }
    public bool IsUsed { get => inUse; set => inUse = value; }

    public RecipeData(string name, string author, Dictionary<ESeason, bool> seasons = null, ECourse course = ECourse.Main, string recipeDetails = null)
    {
        this.name = name;
        this.author = author;
        this.seasons = seasons ?? this.seasons;
        this.course = course;
        this.recipeDetails = recipeDetails ?? this.recipeDetails;
    }

    public bool IsSameRecipe(string name, string author)
    {
        return this.name == name && this.author == author;
    }

    public void Modify(Dictionary<ESeason, bool> seasons = null, ECourse course = ECourse.Main, string recipeDetails = null)
    {
        this.seasons = seasons ?? this.seasons;
        this.course = course;
        this.recipeDetails = recipeDetails ?? this.recipeDetails;
    }
}
