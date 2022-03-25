using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionPanelScript : MonoBehaviour
{
    private Animator animator;

    public static bool panelActive;

    [SerializeField] TMP_Text question; 
    [SerializeField] Button buttonYes;
    private ChestScript chest;

    private void Awake()
    {
        panelActive = false;
    }
    void Start()
    {
        chest = GameObject.FindWithTag("Chest").GetComponent<ChestScript>();
        animator = GetComponent<Animator>();
    }

    public void SetQuestionPanel(string title,string buttonConfig)
    {
        question.text = title;
        buttonYes.onClick.RemoveAllListeners();
        switch (buttonConfig)
        {
            case "CHEST":
                buttonYes.onClick.AddListener(OpenChest);
                break;
            case "KEY":
                buttonYes.onClick.AddListener(TakeKey);
                break;
            case "DOOR":
                buttonYes.onClick.AddListener(OpenDoor);
                break;
        }

        animator.SetBool("Show",true);
        panelActive = true;
    }


    public void No()
    {
        animator.SetBool("Show", false);
    }

    public void OpenChest()
    {
        animator.SetBool("Show", false);
        chest.Open();
    }

    public void TakeKey()
    {
        chest.TakeKey();
        animator.SetBool("Show", false);
    }

    public void OpenDoor()
    {
        animator.SetBool("Show", false);
        panelActive = false;
        TimerController.StopTimer();
        GameOver.GameOverScreen();
    }

    public void WaitForAnimation()
    {
        panelActive = false;
    }


}
