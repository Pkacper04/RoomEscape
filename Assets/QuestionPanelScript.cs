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
    [SerializeField] GameObject key;

    private void Awake()
    {
        panelActive = false;
    }
    void Start()
    {
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
        panelActive = false;
    }

    public void OpenChest()
    {
        MouseControler.chestOpened = true;
        animator.SetBool("Show", false);
        panelActive=false;
        key.SetActive(true);
    }

    public void TakeKey()
    {
        animator.SetBool("Show", false);
        PlayerData.SetKey();
        panelActive = false;
        key.SetActive(false);
    }

    public void OpenDoor()
    {
        animator.SetBool("Show", false);
        panelActive = false;
        TimerController.StopTimer();
        GameOver.GameOverScreen();
    }


}