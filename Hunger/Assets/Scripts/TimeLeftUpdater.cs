using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLeftUpdater : MonoBehaviour
{
    void Update()
    {
        if (GlobalData.TimeLeft <= 0)
        {
            //kill player
            SceneManager.LoadScene(GlobalData.loseSceneNumber);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GlobalData.TimeLeft = 0;
        }
        else
        {
            GlobalData.TimeLeft -= Time.deltaTime;
        }
    }
}