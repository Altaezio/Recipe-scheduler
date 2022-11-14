using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeData
{
    public string Name;
    public string Author;
    public Dictionary<ESeason, bool> Seasons;
    public List<ESeason> choosenSeasons;
    public ECourse Course;
    public string RecipeDetails;
    public bool IsUsed;

    public RecipeData(string name, string author, Dictionary<ESeason, bool> seasons = null, ECourse course = ECourse.Main, string recipeDetails = null)
    {
        Name = name;
        Author = author;
        Seasons = seasons ?? new Dictionary<ESeason, bool>();
        choosenSeasons=new List<ESeason>();
        foreach (KeyValuePair<ESeason, bool> kvp in Seasons) if (kvp.Value) choosenSeasons.Add(kvp.Key);
        Course = course;
        RecipeDetails = recipeDetails;
        IsUsed = true;
    }

    public bool IsSameRecipe(string name, string author)
    {
        return Name == name && Author == author;
    }

    public bool IsSameRecipe(RecipeData recipe)
    {
        return IsSameRecipe(recipe.Name, recipe.Author);
    }

    public bool MatchRequirement(Dictionary<ESeason, bool> seasons)
    {
        foreach (KeyValuePair<ESeason, bool> season in seasons)
        {
            if (season.Value && !Seasons[season.Key]) return false;
        }
        return true;
    }

    public bool MatchRequirement(ECourse course)
    {
        return course == Course;
    }

    public bool MatchRequirement(Dictionary<ESeason, bool> seasons, ECourse course)
    {
        return MatchRequirement(seasons) && MatchRequirement(course);
    }

    public void Modify(Dictionary<ESeason, bool> seasons = null, ECourse course = ECourse.Main, string recipeDetails = null)
    {
        Seasons = seasons ?? Seasons;
        foreach (KeyValuePair<ESeason, bool> kvp in Seasons)
        {
            if (kvp.Value)
                choosenSeasons.Add(kvp.Key);
            else
                choosenSeasons.Remove(kvp.Key);
        }

        Course = course;
        RecipeDetails = recipeDetails ?? RecipeDetails;
    }
}
