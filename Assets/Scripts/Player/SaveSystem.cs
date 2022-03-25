using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveScore(double time)
    {
        if (LoadScore() != -1 && time > LoadScore())
            return;

        string timeToText = time.ToString();
        PlayerPrefs.SetString("score",timeToText);
        PlayerPrefs.Save();
    }


    public static double LoadScore()
    {
        if (PlayerPrefs.GetString("score") == "")
            return -1;

        return double.Parse(PlayerPrefs.GetString("score"));
    }
}
