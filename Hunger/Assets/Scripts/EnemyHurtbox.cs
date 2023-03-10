using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHurtbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //kill player
            SceneManager.LoadScene(GlobalData.loseSceneNumber);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
