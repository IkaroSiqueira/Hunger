using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private int _health = 50;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "food" || collision.gameObject.tag == "lethalFood")
        {
            if (GlobalData.currentPlayerFood == "food")
            {
                GlobalData.TimeLeft = GlobalData.currentGameTimeReset;
                _health -= 5;
                Destroy(collision.gameObject);
            }
            else if (GlobalData.currentPlayerFood == "lethalFood")
            {
                GlobalData.currentGameTimeReset += GlobalData.lethalCurrentTimeIncrease;
                GlobalData.TimeLeft = GlobalData.currentGameTimeReset;
                _health -= 10;
                Destroy(collision.gameObject);
            }

            if(_health <= 0)
            {
                //Player wins
                MainMenu.GameWon();
                Cursor.lockState = CursorLockMode.None;
            }

            Debug.Log(GlobalData.currentPlayerFood);
            Debug.Log(_health);
        }
    }
}
