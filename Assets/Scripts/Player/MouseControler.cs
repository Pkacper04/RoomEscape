using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControler : MonoBehaviour
{
    [SerializeField] QuestionPanelScript questionPanel;

    public static bool chestOpened = false;

    private ChangeColor objectScript;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (QuestionPanelScript.panelActive)
            return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        bool hitted = Physics.Raycast(ray, out hit);

        MouseHover(hitted,hit);
        if(Input.GetMouseButtonDown(0))
            MouseClick(hitted, hit);
    }

    private void MouseClick(bool hitted, RaycastHit hit)
    {
        if(hitted)
        {
            switch(hit.transform.tag)
            {
                case "Chest":
                    if (!chestOpened)
                        questionPanel.SetQuestionPanel("Open?", "CHEST");
                    else
                    {
                        InfoBox.SetInfoBox("Chest is empty!");
                        InfoBox.ShowInfoBox();
                    }
                    break;
                case "Key":
                    questionPanel.SetQuestionPanel("Take?", "KEY");
                    break;
                case "Door":
                    if (PlayerData.GetKey())
                        questionPanel.SetQuestionPanel("Open?", "DOOR");
                    else
                    {
                        InfoBox.SetInfoBox("You need a key!");
                        InfoBox.ShowInfoBox();
                    }
                    break;
            }
        }
    }

    private void MouseHover(bool hitted,RaycastHit hit)
    {
        if (hitted)
        {
            switch(hit.transform.tag)
            {
                case "Chest":
                    ChangeObjColor(hit);
                    break;
                case "Door":
                    ChangeObjColor(hit);
                    break;
                case "Key":
                    ChangeObjColor(hit);
                    break;
                default:
                    if (objectScript == null)
                        return;
                    objectScript.OutHover();
                    objectScript = null;
                    break;
            }
            
        }
    }


    private void ChangeObjColor(RaycastHit hit)
    {
        if (objectScript != null && objectScript.transform == hit.transform)
            return;

        if (objectScript != null)
            objectScript.OutHover();

        objectScript = hit.transform.GetComponent<ChangeColor>();
        objectScript.OnHover();
    }


}
