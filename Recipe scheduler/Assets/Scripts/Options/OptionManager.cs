using System;
using System.Collections;
using System.Collections.Generic;
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
        playerOptions.nbAppetizer = Int32.Parse(value);
    }

    public void DefaultMainValue(string value)
    {
        playerOptions.nbMain = Int32.Parse(value);
    }

    public void DefaultDessertValue(string value)
    {
        playerOptions.nbDessert = Int32.Parse(value);
    }
}
