using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControler : MonoBehaviour
{
    [SerializeField] QuestionPanelScript questionPanel;

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
                    questionPanel.SetQuestionPanel("Open?", "CHEST");
                    break;
                case "Door":
                    questionPanel.SetQuestionPanel("Open?", "DOOR");
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
