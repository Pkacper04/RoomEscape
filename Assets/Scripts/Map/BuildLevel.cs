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
    private Vector3 doorPosition;

    // Start is called before the first frame update
    void Awake()
    {
        minValue = center.x - length / 2 + boxOffset;
        maxValue = center.x + length / 2 - boxOffset;

        BuildChest();

        ChooseDoorPosition();

        WallCreator();

    }

    private void BuildChest()
    {
        float pos_x = Random.Range(minValue, maxValue);
        float pos_z = Random.Range(minValue, maxValue);

        Vector3 boxPos = new Vector3(pos_x, 0f, pos_z);

        if (Vector3.Distance(center, boxPos) < boxOffset)
            boxPos += new Vector3(boxOffset, 0, 0);

        Instantiate(boxPrefab, boxPos, Quaternion.identity);

    }

    private void ChooseDoorPosition()
    {
        wallNumber = Random.Range(0, 4);
        Debug.Log(wallNumber);

        float pos = Random.Range(minValue, maxValue - 2);


        switch (wallNumber)
        {
            case 0:
                doorRotation = new Vector3(0, 90, 0);
                doorPosition = new Vector3(pos, 0, maxValue + boxOffset);
                break;
            case 1:
                doorRotation = new Vector3(0, 180, 0);
                doorPosition = new Vector3(maxValue + boxOffset, 0, pos);
                break;
            case 2:
                doorRotation = new Vector3(0, 270, 0);
                doorPosition = new Vector3(pos, 0, minValue - boxOffset);
                break;
            case 3:
                doorRotation = new Vector3(0, 0, 0);
                doorPosition = new Vector3(minValue - boxOffset, 0, pos);
                break;
        }

        Instantiate(doorPrefab, doorPosition, Quaternion.Euler(doorRotation));

    }


    private void WallCreator()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 rotation = new Vector3(0, 0, 0);

        for (int i = 0; i < 4; i++)
        {

            switch (i)
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
                SetWallWithDoor(doorPosition, pos, rotation);
            }
            else
            {
                GameObject wall = Instantiate(wallPrefab, pos, Quaternion.Euler(rotation));
                wall.transform.localScale = new Vector3(length, 5, .15f);
            }

        }

    }


    private void SetWallWithDoor(Vector3 doorPosition, Vector3 pos, Vector3 rotation)
    {
        GameObject leftWall = null;
        GameObject middleWall = null;
        GameObject rightWall = null;
        float LeftWallLength = 0;
        float RightWallLength = 0;

        if (wallNumber % 2 == 0)
        {
            LeftWallLength = maxValue + boxOffset - doorPosition.x - 0.45f;
            RightWallLength = length - LeftWallLength - 0.45f;

            leftWall = Instantiate(wallPrefab, new Vector3(doorPosition.x + LeftWallLength / 2 + 0.45f, pos.y, pos.z), Quaternion.Euler(rotation));

            rightWall = Instantiate(wallPrefab, new Vector3(doorPosition.x - RightWallLength / 2 - 0.45f, pos.y, pos.z), Quaternion.Euler(rotation));

            middleWall = Instantiate(wallPrefab, new Vector3(doorPosition.x, 3.5f, pos.z), Quaternion.Euler(rotation));
        }
        else
        {
            LeftWallLength = maxValue + boxOffset - doorPosition.z - 0.45f;
            RightWallLength = length - LeftWallLength - 0.45f;

            leftWall = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, doorPosition.z + LeftWallLength / 2 + 0.45f), Quaternion.Euler(rotation));

            rightWall = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, doorPosition.z - RightWallLength / 2 - 0.45f), Quaternion.Euler(rotation));

            middleWall = Instantiate(wallPrefab, new Vector3(pos.x, 3.5f, doorPosition.z), Quaternion.Euler(rotation));
        }

        leftWall.transform.localScale = new Vector3(LeftWallLength, 5f, .15f);
        rightWall.transform.localScale = new Vector3(RightWallLength, 5f, .15f);
        middleWall.transform.localScale = new Vector3(1f, 3f, .15f);
    }

}
