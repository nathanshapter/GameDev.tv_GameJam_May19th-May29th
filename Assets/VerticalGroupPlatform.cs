using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGroupPlatform : MonoBehaviour
{
    [Header("Straight Movement")]
    Vector2 startingPosition;
    [HideInInspector] public float movementSpeed = 5;
    Transform topYPosition, bottomYPosition;
    PlayerController player;
    bool playerTouchingPlatform = false;

    [SerializeField] bool isFlipped;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startingPosition = GetComponentInParent<VerticalPlatformManager>().transform.position;
        movementSpeed = GetComponentInParent<VerticalPlatformManager>().movementSpeed;
        topYPosition = GetComponentInParent<VerticalPlatformManager>().topYPosition;
        bottomYPosition = GetComponentInParent<VerticalPlatformManager>().bottomYPosition;
        isFlipped = GetComponentInParent<VerticalPlatformManager>().isFlipped;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerTouchingPlatform = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerTouchingPlatform = false;
    }
    private void Update()
    {

        transform.position += new Vector3(0, -movementSpeed, 0) * Time.deltaTime;


        if (transform.position.y < bottomYPosition.position.y && !isFlipped)
        {

            ResetPlayerParent(playerTouchingPlatform);


            transform.position = topYPosition.position;
        }

        if (transform.position.y > topYPosition.position.y && isFlipped)
        {
            ResetPlayerParent(playerTouchingPlatform);

            transform.position = bottomYPosition.position;
        }



    }
    private void ResetPlayerParent(bool isTouching)
    {
        if (isTouching)
        {
            player.transform.SetParent(null);
        }
    }

}
