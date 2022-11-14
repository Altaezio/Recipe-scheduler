using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveData()
    {
        string path = OptionManager.playerOptions.SaveDirectory;
        List<RecipeData> recipes = RecipesManager.Instance.RecipeDatas;
        foreach(RecipeData recipe in recipes)
        {
            string recipeJSON = JsonUtility.ToJson(recipe, true);
            Debug.Log(recipeJSON);
            File.WriteAllText(path + "/" + recipe.Name + " - " + recipe.Author + ".json", recipeJSON);
        }
    }

    public static List<RecipeData> LoadData()
    {
        string path = OptionManager.playerOptions.SaveDirectory;
        List<RecipeData> returnList = new();
        foreach(string file in Directory.GetFiles(path))
        {
            string recipeJSON = File.ReadAllText(file);
            returnList.Add(JsonUtility.FromJson<RecipeData>(recipeJSON));
        }
        return returnList;
    }
}
