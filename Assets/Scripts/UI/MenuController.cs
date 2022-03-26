using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    private static Animator animator;
    [SerializeField] private TMP_Text bestScore;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (SaveSystem.LoadScore() != -1)
            bestScore.text = "Best score: " + SaveSystem.LoadScore() + "s";
        else
            bestScore.text = "Best score: ";
    }

    public void StartGame()
    {
        animator.SetBool("GameStarted", true);
    }

    public void AnimationEnd()
    {
        TimerController.StartTimer();
    }

    public static void EndGame()
    {
        animator.SetBool("GameStarted", false);
    }
}
