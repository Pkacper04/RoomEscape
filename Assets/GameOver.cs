using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private static GameObject gameOverScreen;
    private static TMP_Text currentScore;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public static void GameOverScreen()
    {
        currentScore.text = "Current time: "+TimerController.GetTimer().ToString();
        gameOverScreen.SetActive(true);

    }
    
}
