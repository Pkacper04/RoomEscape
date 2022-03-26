using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    static private bool key;


    private void Awake()
    {
        key = false;
    }

    public static void SetKey()
    {
        key = !key;
    }

    public static bool GetKey()
    {
        return key;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
