using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using RoomEscape.Player;
using RoomEscape.Core;

namespace RoomEscape.UI
{
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
                if (obj.name == "CurrentScore")
                    currentScore = obj.GetComponent<TMP_Text>();
                else if (obj.name == "BestScore")
                    bestScore = obj.GetComponent<TMP_Text>();
                childernsObjects.Add(obj);
                obj.gameObject.SetActive(false);
            }

            gameOverScreen.enabled = false;
        }

        public static void GameOverScreen()
        {
            MenuController.EndGame();

            double time = Math.Round(TimerController.GetTimer(), 2);
            bool hightScore = SaveSystem.NewHightScore(time);


            currentScore.text = "Current score: " + time + "s";

            if (hightScore)
            {
                SaveSystem.SaveScore(time);
                bestScore.text = "New Best score: " + SaveSystem.LoadScore() + "s";
            }
            else
                bestScore.text = "Best score: " + SaveSystem.LoadScore() + "s";


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
}
