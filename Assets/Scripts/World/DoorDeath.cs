using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            FindObjectOfType<RespawnManager>().ProcessDeath();
        }
    }
}
