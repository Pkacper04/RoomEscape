using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBox : MonoBehaviour
{
    private static Animator animator;
    private static TMP_Text infoText; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        infoText = GetComponentInChildren<TMP_Text>();
    }

    public static void SetInfoBox(string title)
    {
        infoText.text = title;
    }

    public static void ShowInfoBox()
    {
        animator.SetBool("Show", true);
        QuestionPanelScript.panelActive = true;
    }

    public static void HideInfoBox()
    {
        animator.SetBool("Show", false);
    }

    public void WaitForAnimation()
    {
        QuestionPanelScript.panelActive = false;
    }
}
