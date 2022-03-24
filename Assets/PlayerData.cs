using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    static private bool key = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
