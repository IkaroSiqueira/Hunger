using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLeftUpdater : MonoBehaviour
{
    void Update()
    {
      GlobalData.TimeLeft -= Time.deltaTime;
    }
}