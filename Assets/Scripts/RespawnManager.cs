using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform respawnPosition;
    [SerializeField] float waitBeforeRespawn =3;
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            
            DeathCounter.instance.amountOfDeaths++;
            Debug.Log(DeathCounter.instance.amountOfDeaths);
            StartCoroutine(ReturnPlayerToStart());
        }
    }

    private IEnumerator ReturnPlayerToStart()
    {
        yield return new WaitForSeconds(waitBeforeRespawn);
        transform.position = respawnPosition.transform.position;
    }
}
