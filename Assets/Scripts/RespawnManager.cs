using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform respawnPosition;
    [SerializeField] float waitBeforeRespawn =3;
     Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            
            DeathCounter.instance.amountOfDeaths++;
            Debug.Log(DeathCounter.instance.amountOfDeaths);
            animator.SetTrigger("Death");
            StartCoroutine(ReturnPlayerToStart());
        }
    }

    private IEnumerator ReturnPlayerToStart()
    {
       
        yield return new WaitForSeconds(waitBeforeRespawn);
        animator.SetTrigger("Alive");
        transform.position = respawnPosition.transform.position;
        
    }
}
