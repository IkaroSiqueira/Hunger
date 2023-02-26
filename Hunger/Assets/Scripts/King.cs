using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "food" || collision.gameObject.tag == "lethalFood")
        {
            if (GlobalData.currentPlayerFood == "food")
            {
                _health -= 5;
                Destroy(collision.gameObject);
            }
            else if (GlobalData.currentPlayerFood == "lethalFood")
            {
                _health -= 10;
                Destroy(collision.gameObject);
            }

            if(_health <= 0)
            {
                //Player wins
            }

            Debug.Log(GlobalData.currentPlayerFood);
            Debug.Log(_health);
        }
    }
}
