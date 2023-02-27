using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private float _health = 50;
    private float _maxHealth = 50;

    [SerializeField] private AudioSource _eat = null;
    [SerializeField] private AudioSource _eatPoison = null;
    [SerializeField] private AudioSource _hungry = null;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "food" || collision.gameObject.tag == "lethalFood")
        {
            if (GlobalData.currentPlayerFood == "food")
            {
                _eat.Play(0);
                GlobalData.TimeLeft = GlobalData.currentGameTimeReset;
                _health -= 5;

                float newScale = 0.1f;
                this.transform.localScale += new Vector3(newScale, newScale, newScale);

                float newYpos = 0.105f;
                this.transform.position += new Vector3(0, newYpos, 0);

                Destroy(collision.gameObject);
            }
            else if (GlobalData.currentPlayerFood == "lethalFood")
            {
                _eatPoison.Play(0);
                GlobalData.currentGameTimeReset += GlobalData.lethalCurrentTimeIncrease;
                GlobalData.TimeLeft = GlobalData.currentGameTimeReset;
                _health -= 10;

                float newScale = 0.2f;
                this.transform.localScale += new Vector3(newScale, newScale, newScale);

                float newYpos = 0.21f;
                this.transform.position += new Vector3(0, newYpos, 0);

                Destroy(collision.gameObject);
            }

            if(_health <= 0)
            {
                //Player wins
                MainMenu.GameWon();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
