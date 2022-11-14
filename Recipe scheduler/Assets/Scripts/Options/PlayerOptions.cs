using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerOption", menuName = "ScriptableObjects/PlayerOption")]
public class PlayerOptions : ScriptableObject
{
    public float soundVolume;

    public int nbAppetizer;
    public int nbMain;
    public int nbDessert;

    public Dictionary<ESeason, bool> Seasons;

    public string SaveDirectory;
}
