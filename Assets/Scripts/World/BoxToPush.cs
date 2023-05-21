using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxToPush : MonoBehaviour
{

   [SerializeField] Vector2 spawnPosition;

    PlayerController player;
    [SerializeField] float bottomRespawnPosition = -100;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if(transform.position.y < bottomRespawnPosition)
        {
            if (player.GetComponentInParent<BoxToPush>())
            {
                player.transform.SetParent(null);
            }

           
            this.transform.position = spawnPosition;
        }
    }
}
