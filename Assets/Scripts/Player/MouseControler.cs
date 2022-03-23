using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControler : MonoBehaviour
{
    private Color SavedColor;
    private bool onTarget = false;
    MeshRenderer targetMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        bool hitted = Physics.Raycast(ray, out hit);

        /*if (hitted)
        {
            if (hit.transform.tag == "Chest")
            {
                onTarget = true;
                targetMesh = hit.transform.GetComponent<MeshRenderer>();
                if (SavedColor != targetMesh.material.color)
                {
                    Debug.Log("1");
                    SavedColor = targetMesh.material.color;

                    targetMesh.material.color += new Color(60, 0, 0);
                }
            }
            else if(onTarget)
            {
                Debug.Log("dziala");
                onTarget = false;
                targetMesh.material.color = SavedColor;
                SavedColor = new Color(-1, -1, -1);
            }
        }*/
    }
}
