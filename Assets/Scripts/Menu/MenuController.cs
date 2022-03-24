using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartGame()
    {
        animator.SetBool("GameStarted", true);
    }

    public void AnimationEnd()
    {
        TimerController.StopTimer();
        TimerController.StartTimer();
    }
}
