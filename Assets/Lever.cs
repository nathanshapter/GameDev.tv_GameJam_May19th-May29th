using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    PlayerController player;
    public bool leverPressed = false;
    [SerializeField] GameObject door, topYPosition;
    Vector3 startPosition;


    [SerializeField] float movementSpeed = 5;

  

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        topYPosition.GetComponent<Renderer>().enabled = false;
        startPosition = door.transform.position;
    }

    private void Update()
    {
        if (leverPressed == true)
        {
            if (door.transform.position.y >= topYPosition.transform.position.y) { return; }
            door.transform.position += new Vector3(0, movementSpeed, 0) * Time.deltaTime;
        }
        else
        {

            if (door.transform.position.y <= startPosition.y) { return; }
            door.transform.position -= new Vector3(0, movementSpeed, 0) * Time.deltaTime;
        }
    }




}
