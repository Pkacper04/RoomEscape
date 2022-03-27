using UnityEngine;

namespace RoomEscape.Core
{
    public class BuildLevel : MonoBehaviour
    {
        [SerializeField] private GameObject boxPrefab;
        [SerializeField] private GameObject doorPrefab;
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject floorPrefab;
        [SerializeField] private GameObject roofPrefab;
        [SerializeField] private Vector3 center = new Vector3(50, 0, 50);
        [SerializeField] private float length = 20;
        [SerializeField] private float offset = 2;


        private float minValue;
        private float maxValue;
        private int wallNumber;

        private Vector3 doorRotation;
        private Vector3 doorPosition;

        void Awake()
        {
            minValue = center.x - length / 2 + offset;
            maxValue = center.x + length / 2 - offset;

            BuildChest();

            ChooseDoorPosition();

            FloorAndRoofCreator();

            WallCreator();


        }

        private void FloorAndRoofCreator()
        {
            GameObject obj = Instantiate(floorPrefab, center + new Vector3(0f, 0.05f, 0f), Quaternion.identity);
            obj.transform.localScale = new Vector3(length, 0.1f, length);
            obj = Instantiate(roofPrefab, center + new Vector3(0f, 5f, 0f), Quaternion.identity);
            obj.transform.localScale = new Vector3(length, 0.1f, length);
        }

        private void BuildChest()
        {
            float pos_x = Random.Range(minValue, maxValue);
            float pos_z = Random.Range(minValue, maxValue);

            Vector3 boxPos = new Vector3(pos_x, 0f, pos_z);

            if (Vector3.Distance(center, boxPos) < offset)
                boxPos += new Vector3(offset, 0, 0);

            Instantiate(boxPrefab, boxPos, Quaternion.identity);

        }

        private void ChooseDoorPosition()
        {
            wallNumber = Random.Range(0, 4);

            float pos = Random.Range(minValue, maxValue - 2);


            switch (wallNumber)
            {
                case 0:
                    doorRotation = new Vector3(0, 90, 0);
                    doorPosition = new Vector3(pos, 0, maxValue + offset);
                    break;
                case 1:
                    doorRotation = new Vector3(0, 180, 0);
                    doorPosition = new Vector3(maxValue + offset, 0, pos);
                    break;
                case 2:
                    doorRotation = new Vector3(0, 270, 0);
                    doorPosition = new Vector3(pos, 0, minValue - offset);
                    break;
                case 3:
                    doorRotation = new Vector3(0, 0, 0);
                    doorPosition = new Vector3(minValue - offset, 0, pos);
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
                        pos = new Vector3(center.x, 2.5f, maxValue + offset);
                        rotation = new Vector3(0, 0, 0);
                        break;
                    case 1:
                        pos = new Vector3(maxValue + offset, 2.5f, center.z);
                        rotation = new Vector3(0, 90, 0);
                        break;
                    case 2:
                        pos = new Vector3(center.x, 2.5f, minValue - offset);
                        rotation = new Vector3(0, 180, 0);
                        break;
                    case 3:
                        pos = new Vector3(minValue - offset, 2.5f, center.z);
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
                LeftWallLength = maxValue + offset - doorPosition.x - 0.45f;
                RightWallLength = length - LeftWallLength - 0.45f;

                leftWall = Instantiate(wallPrefab, new Vector3(doorPosition.x + LeftWallLength / 2 + 0.45f, pos.y, pos.z), Quaternion.Euler(rotation));

                rightWall = Instantiate(wallPrefab, new Vector3(doorPosition.x - RightWallLength / 2 - 0.45f, pos.y, pos.z), Quaternion.Euler(rotation));

                middleWall = Instantiate(wallPrefab, new Vector3(doorPosition.x, 3.5f, pos.z), Quaternion.Euler(rotation));
            }
            else
            {
                LeftWallLength = maxValue + offset - doorPosition.z - 0.45f;
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
}
