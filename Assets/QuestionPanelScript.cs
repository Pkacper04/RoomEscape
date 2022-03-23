using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionPanelScript : MonoBehaviour
{
    private Animator animator;

    [SerializeField] TMP_Text question; 
    [SerializeField] Button buttonYes; 

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
    }


    public void No()
    {
        animator.SetBool("Show", false);
    }

    public void OpenChest()
    {
        Debug.Log("Otworzyles skrzynie");
        animator.SetBool("Show", false);
        SetQuestionPanel("Take?", "KEY");
    }

    public void TakeKey()
    {
        Debug.Log("Wziales klucz");
        animator.SetBool("Show", false);
    }

    public void OpenDoor()
    {
        Debug.Log("Game Over");
        animator.SetBool("Show", false);
    }
}
