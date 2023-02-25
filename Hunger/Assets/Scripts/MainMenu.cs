using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameWon()
    {
        SceneManager.LoadScene(0);
    }
    public void GameLoss()
    {
        SceneManager.LoadScene(0);
    }
    public void TestButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
