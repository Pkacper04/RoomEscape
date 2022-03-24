using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    private static List<Transform> childernsObjects;
    private static Image gameOverScreen;
    private static TMP_Text currentScore;
    private static TMP_Text bestScore;

    private void Start()
    {
        gameOverScreen = GetComponent<Image>();

        childernsObjects = new List<Transform>();
        foreach (var obj in GetComponentsInChildren<Transform>())
        {
            if(obj.name == "CurrentScore")
                currentScore = obj.GetComponent<TMP_Text>();
            else if(obj.name == "BestScore")
                bestScore = obj.GetComponent<TMP_Text>();
            childernsObjects.Add(obj);
            obj.gameObject.SetActive(false);
        }

        gameOverScreen.enabled = false;
    }

    public static void GameOverScreen()
    {
        SaveSystem.SaveScore(Math.Round(TimerController.GetTimer(), 2));
        currentScore.text = "Current time: "+ Math.Round(TimerController.GetTimer(),2) + "s";
        if(SaveSystem.LoadScore() == -1)
            bestScore.text = "Best time: " + Math.Round(TimerController.GetTimer(), 2) + "s";
        else
            bestScore.text = "Best time: " + SaveSystem.LoadScore() + "s";

        

        gameOverScreen.enabled = true;
        foreach (var item in childernsObjects)
        {
            item.gameObject.SetActive(true);
        }

    }
    
    public void TryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}