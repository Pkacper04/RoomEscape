using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevel : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private Vector3 center = new Vector3(50,0,50);
    [SerializeField] private float length = 20;
    [SerializeField] private float boxOffset = 2;

    
    // Start is called before the first frame update
    void Awake()
    {
        BuildChest();   
    }

    private void BuildChest()
    {
        float minValue = center.x - length / 2 + boxOffset;

        float maxValue = center.x + length / 2 - boxOffset;

        float pos_x = Random.Range(minValue, maxValue+1);
        float pos_z = Random.Range(minValue,maxValue+1);

        Vector3 boxPos = new Vector3(pos_x, 0.5f, pos_z);
        
        if (Vector3.Distance(center, boxPos) < boxOffset)
            boxPos += new Vector3(2, 0, 0);



        Instantiate(boxPrefab, boxPos,Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
