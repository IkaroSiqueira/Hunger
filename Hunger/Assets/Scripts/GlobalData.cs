using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    static public string currentPlayerFood = "";
    static public float TimeLeft = 0f;
    static public float baseTimeReset = 24;
    static public float currentGameTimeReset = 24;
    static public float lethalCurrentTimeIncrease = 3;

    static public int mainMenuSceneNumber = 0;
    static public int levelSceneNumber = 1;
    static public int winSceneNumber = 3;
    static public int loseSceneNumber = 2;
}
