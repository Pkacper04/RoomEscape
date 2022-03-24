using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevel : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Vector3 center = new Vector3(50,0,50);
    [SerializeField] private float length = 20;
    [SerializeField] private float boxOffset = 2;


    private float minValue;
    private float maxValue;
    private int wallNumber;

    private Vector3 doorRotation;

    // Start is called before the first frame update
    void Awake()
    {
        minValue = center.x - length / 2 + boxOffset;
        maxValue = center.x + length / 2 - boxOffset;

        BuildChest();
        Vector3 doorPosition = ChooseDoorPosition();

        Instantiate(doorPrefab, doorPosition, Quaternion.Euler(doorRotation));

        WallCreator(doorPosition);

    }

    private void WallCreator(Vector3 doorPosition)
    {
        Vector3 pos = new Vector3(0,0,0);
        Vector3 rotation = new Vector3(0,0,0);

        for(int i=0;i<4;i++)
        {

                switch(i)
                {
                    case 0:
                        pos = new Vector3(center.x, 2.5f, maxValue + boxOffset);
                        rotation = new Vector3(0, 0, 0);
                        break;
                    case 1:
                        pos = new Vector3(maxValue + boxOffset, 2.5f, center.z);
                        rotation = new Vector3(0, 90, 0);
                        break;
                    case 2:
                        pos = new Vector3(center.x, 2.5f, minValue - boxOffset);
                        rotation = new Vector3(0, 180, 0);
                        break;
                    case 3:
                        pos = new Vector3(minValue - boxOffset, 2.5f, center.z);
                        rotation = new Vector3(0, 270, 0);
                        break;
                }

                if (wallNumber == i)
                {
                      Debug.Log(wallNumber);
                      if (i % 2 == 1)
                            {
                                float LeftWallLength = maxValue + boxOffset - doorPosition.z - 1;
                                float RightWallLength = length - LeftWallLength - 2;
                                GameObject wall = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, doorPosition.z + LeftWallLength / 2 + 1), Quaternion.Euler(rotation));
                                wall.transform.localScale = new Vector3(LeftWallLength, 5, 1);
                                wall = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, doorPosition.z - RightWallLength / 2 - 1), Quaternion.Euler(rotation));
                                wall.transform.localScale = new Vector3(RightWallLength, 5, 1);

                            }
                            else
                            {
                                float LeftWallLength = maxValue + boxOffset - doorPosition.x - 1;
                                float RightWallLength = length - LeftWallLength - 2;
                                GameObject wall = Instantiate(wallPrefab, new Vector3(doorPosition.x + LeftWallLength / 2 + 1, pos.y, pos.z), Quaternion.Euler(rotation));
                                wall.transform.localScale = new Vector3(LeftWallLength, 5, 1);
                                wall = Instantiate(wallPrefab, new Vector3(doorPosition.x - RightWallLength / 2 - 1, pos.y, pos.z), Quaternion.Euler(rotation));
                                wall.transform.localScale = new Vector3(RightWallLength, 5, 1);
                            }
                        }
                else
                        {
            Debug.Log(wallNumber);
            GameObject wall = Instantiate(wallPrefab, pos, Quaternion.Euler(rotation));
                wall.transform.localScale = new Vector3(length, 5, 1);
            }

        }
        
    }

    private Vector3 ChooseDoorPosition()
    {
        wallNumber = Random.Range(0, 4);

        float pos = Random.Range(minValue, maxValue - 2); 


        switch(wallNumber)
        {
            case 0:
                doorRotation = new Vector3(0, 0, 0);
                return new Vector3(pos, 1.8f, maxValue + boxOffset - 1);
            case 1:
                doorRotation = new Vector3(0, 90, 0);
                return new Vector3(maxValue + boxOffset - 1, 1.8f, pos);
            case 2:
                doorRotation = new Vector3(0, 180, 0);
                return new Vector3(pos, 1.8f, minValue - boxOffset + 1);
            case 3:
                doorRotation = new Vector3(0, 270, 0);
                return new Vector3(minValue - boxOffset + 1, 1.8f, pos);
        }

        return Vector3.zero;
    }

    private void BuildChest()
    {
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
