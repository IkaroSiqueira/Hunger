using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAndTime : MonoBehaviour
{
    public TMP_Text time;

    void Update()
    {
        time.text = "Time: " + System.Math.Round(GlobalData.TimeLeft, 2);
    }
}