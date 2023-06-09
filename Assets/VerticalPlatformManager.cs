using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class VerticalPlatformManager : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] List<GameObject> verticalPlatform;
    [SerializeField] int amountOfPlatformsToSpawn; // this needs to be the same for all of them in the scene or does not work correctly
    public Transform topYPosition, bottomYPosition;
    float yDistanceBetweenTopBottom;

    public float movementSpeed;

    public bool isFlipped;


    private void Start()
    {
        if (isFlipped) { movementSpeed = -movementSpeed; }
        yDistanceBetweenTopBottom = topYPosition.transform.position.y - bottomYPosition.transform.position.y;

        float platformSpawnGap = yDistanceBetweenTopBottom / amountOfPlatformsToSpawn;

        if (!isFlipped)
        {
            for (int i = 0; i < amountOfPlatformsToSpawn; i++)
            {
                Instantiate(platform, ReturnSpawnPosition(), false);

                verticalPlatform.Add(platform);


                platform.transform.position = new Vector2(0, platformSpawnGap * i);

            }
        }
        if (isFlipped)
        {
            for (int i = 0; i < amountOfPlatformsToSpawn; i++)
            {
                Instantiate(platform, bottomYPosition, false);

                verticalPlatform.Add(platform);


                platform.transform.position = new Vector2(0, platformSpawnGap * i);

            }
        }






    }
    private Transform ReturnSpawnPosition()
    {
        if (isFlipped)
        {
            return topYPosition;
        }
        else
        {
            return bottomYPosition;
        }
    }
    private void OnDrawGizmos()
    {
        if (isFlipped)
        {
            Gizmos.color = Color.blue;
        }
        else { Gizmos.color = Color.red; }

        Gizmos.DrawLine(bottomYPosition.transform.position, topYPosition.transform.position);





    }

}
