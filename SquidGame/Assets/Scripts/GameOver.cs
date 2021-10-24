using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   
    public GameObject gameOverScreen;
   
    private void OnEnable()
    {
        Player.GameOverEven += Player_GameOverEven;
    }

    private void Player_GameOverEven()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void OnDisable()
    {
        Player.GameOverEven -= Player_GameOverEven;
    }
    public void RestartGame()
    {
        int sceneIndex = 0;
        SceneManager.LoadScene(sceneIndex);
    }
}

