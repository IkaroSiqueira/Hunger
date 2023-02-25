using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GlobalData.currentPlayerFood != "")
            {
                if (GlobalData.currentPlayerFood == "food")
                {
                    //takes some poison damage
                }
                else if (GlobalData.currentPlayerFood == "lethal")
                {
                    //takes a lot of poison damage
                }
            }
        }
    }
}
