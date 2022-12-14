using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public static PlayerOptions playerOptions;

    [SerializeField]
    private PlayerOptions options;

    private void Awake()
    {
        playerOptions = options;
        playerOptions.Seasons = new Dictionary<ESeason, bool>();
        if (playerOptions.SaveDirectory.Length == 0)
            playerOptions.SaveDirectory = Application.persistentDataPath;
    }

    public void CheckWinter(bool value)
    {
        playerOptions.Seasons[ESeason.Winter] = value;
    }

    public void CheckSpring(bool value)
    {
        playerOptions.Seasons[ESeason.Spring] = value;
    }

    public void CheckSummer(bool value)
    {
        playerOptions.Seasons[ESeason.Summer] = value;
    }

    public void CheckAutumn(bool value)
    {
        playerOptions.Seasons[ESeason.Autumn] = value;
    }


    public void DefaultAppetizerValue(string value)
    {
        playerOptions.nbAppetizer = int.Parse(value);
    }

    public void DefaultMainValue(string value)
    {
        playerOptions.nbMain = int.Parse(value);
    }

    public void DefaultDessertValue(string value)
    {
        playerOptions.nbDessert = int.Parse(value);
    }

    public void ChangeDirectory(string path)
    {
        if (Directory.Exists(path))
            playerOptions.SaveDirectory = path;
    }

    public void ResetDirectory()
    {
        ChangeDirectory(Application.persistentDataPath);
    }
}
