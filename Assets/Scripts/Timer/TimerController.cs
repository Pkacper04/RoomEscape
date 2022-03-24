using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    static Stopwatch watch = new Stopwatch();
    private static bool StartTime = false;

    [SerializeField] private TMP_Text timerText;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(StartTime)
            timerText.text = (watch.Elapsed.Seconds + watch.Elapsed.Minutes*60) + ":" + watch.Elapsed.Milliseconds/10 + "s";
    }

    public static void StartTimer()
    {
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
