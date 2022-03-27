using UnityEngine;

namespace RoomEscape.Player
{
    public class SaveSystem : MonoBehaviour
    {
        public static void SaveScore(double time)
        {
            string timeToText = time.ToString();
            PlayerPrefs.SetString("score", timeToText);
            PlayerPrefs.Save();
        }

        public static double LoadScore()
        {
            if (PlayerPrefs.GetString("score") == "")
                return -1;

            return double.Parse(PlayerPrefs.GetString("score"));
        }

        public static bool NewHightScore(double time)
        {
            if (LoadScore() == -1)
                return true;

            return time < LoadScore();
        }
    }
}
