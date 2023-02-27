using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static public void GameWon()
    {
        SceneManager.LoadScene(GlobalData.winSceneNumber);
    }
    public void GameLoss()
    {
        SceneManager.LoadScene(GlobalData.loseSceneNumber);
    }
    public void Menu()
    {
        SceneManager.LoadScene(GlobalData.mainMenuSceneNumber);
    }
    public void MainGameScene()
    {
        GlobalData.TimeLeft = GlobalData.baseTimeReset;
        GlobalData.currentGameTimeReset = GlobalData.baseTimeReset;
        SceneManager.LoadScene(GlobalData.levelSceneNumber);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
