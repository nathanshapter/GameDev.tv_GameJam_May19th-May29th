using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownLightMovement : MonoBehaviour
{
    [SerializeField] float thrownLightSpeed =5;
    [SerializeField] float selfDestuctTimer = 10;
    PlayerController player;
    Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        GetDirection();
        StartCoroutine(DestroyLight());
    }

    void GetDirection()
    {
        if (player.isFacingRight)
        {
            rb.velocity = new Vector2(-thrownLightSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(thrownLightSpeed, rb.velocity.y);
        }
    }

   
    private IEnumerator DestroyLight()
    {
        yield return new WaitForSeconds(selfDestuctTimer);
        Destroy(this.gameObject);
    }
}
