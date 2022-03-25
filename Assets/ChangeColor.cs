using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color startColor;
    private MeshRenderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<MeshRenderer>();
        startColor = objectRenderer.material.color;
    }

    public void OnHover()
    {
        objectRenderer.material.color += new Color(0.3f, 0, 0);
    }


    public void OutHover()
    {
        objectRenderer.material.color = startColor;
    }

}
