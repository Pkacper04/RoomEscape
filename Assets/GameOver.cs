using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private static List<Transform> childernsObjects;
    private static Image gameOverScreen;
    private static TMP_Text currentScore;

    private void Start()
    {
        gameOverScreen = GetComponent<Image>();

        childernsObjects = new List<Transform>();
        foreach (var obj in GetComponentsInChildren<Transform>())
        {
            if(obj.name == "CurrentScore")
                currentScore = obj.GetComponent<TMP_Text>();
            childernsObjects.Add(obj);
            obj.gameObject.SetActive(false);
        }

        gameOverScreen.enabled = false;
    }

    public static void GameOverScreen()
    {
        
        currentScore.text = "Current time: "+TimerController.GetTimer().ToString();
        gameOverScreen.enabled = true;
        foreach (var item in childernsObjects)
        {
            item.gameObject.SetActive(true);
        }

    }
    
}
