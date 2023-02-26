using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    void Update()
    {
        _score.text = System.Math.Round(GlobalData.TimeLeft, 2).ToString();
    }
}
