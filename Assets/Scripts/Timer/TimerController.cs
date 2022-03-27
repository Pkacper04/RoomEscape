using System.Diagnostics;
using UnityEngine;
using TMPro;

namespace RoomEscape.Core
{
    public class TimerController : MonoBehaviour
    {
        private static Stopwatch watch;
        public static bool StartTime;

        [SerializeField] private TMP_Text timerText;

        private void Awake()
        {
            StartTime = false;
            watch = new Stopwatch();
        }

        void Update()
        {
            if (StartTime)
                timerText.text = (watch.Elapsed.Seconds + watch.Elapsed.Minutes * 60) + ":" + watch.Elapsed.Milliseconds / 10 + "s";
        }

        public static void StartTimer()
        {
            watch.Restart();
            watch.Start();
            StartTime = true;
        }

        public static void StopTimer()
        {
            watch.Stop();
            StartTime = false;
        }

        public static double GetTimer()
        {
            return watch.Elapsed.TotalSeconds;
        }


    }
}

