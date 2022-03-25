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

        float pos = Random.Range(minValue, maxValue - 2);


        switch (wallNumber)
        {
            case 0:
                doorRotation = new Vector3(0, 0, 0);
                doorPosition = new Vector3(pos, 1.8f, maxValue + boxOffset - 1);
                break;
            case 1:
                doorRotation = new Vector3(0, 90, 0);
                doorPosition = new Vector3(maxValue + boxOffset - 1, 1.8f, pos);
                break;
            case 2:
                doorRotation = new Vector3(0, 180, 0);
                doorPosition = new Vector3(pos, 1.8f, minValue - boxOffset + 1);
                break;
            case 3:
                doorRotation = new Vector3(0, 270, 0);
                doorPosition = new Vector3(minValue - boxOffset + 1, 1.8f, pos);
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
                wall.transform.localScale = new Vector3(length, 5, 1);
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
            LeftWallLength = maxValue + boxOffset - doorPosition.x - 1;
            RightWallLength = length - LeftWallLength - 2;

            leftWall = Instantiate(wallPrefab, new Vector3(doorPosition.x + LeftWallLength / 2 + 1, pos.y, pos.z), Quaternion.Euler(rotation));

            rightWall = Instantiate(wallPrefab, new Vector3(doorPosition.x - RightWallLength / 2 - 1, pos.y, pos.z), Quaternion.Euler(rotation));

            middleWall = Instantiate(wallPrefab, new Vector3(doorPosition.x, 4.3f, pos.z), Quaternion.Euler(rotation));
        }
        else
        {
            LeftWallLength = maxValue + boxOffset - doorPosition.z - 1;
            RightWallLength = length - LeftWallLength - 2;

            leftWall = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, doorPosition.z + LeftWallLength / 2 + 1), Quaternion.Euler(rotation));

            rightWall = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, doorPosition.z - RightWallLength / 2 - 1), Quaternion.Euler(rotation));

            middleWall = Instantiate(wallPrefab, new Vector3(pos.x, 4.3f, doorPosition.z), Quaternion.Euler(rotation));
        }

        leftWall.transform.localScale = new Vector3(LeftWallLength, 5f, 1f);
        rightWall.transform.localScale = new Vector3(RightWallLength, 5f, 1f);
        middleWall.transform.localScale = new Vector3(2f, 1.4f, 1f);
    }

}
