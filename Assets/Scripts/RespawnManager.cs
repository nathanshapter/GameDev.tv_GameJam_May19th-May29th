using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform shadowRespawnPosition, lightRespawnPosition;
    [SerializeField] float waitBeforeRespawn =3;
     Animator animator;
    BoxCollider2D boxCollider;
    bool deathInProgress;
    ShadowGlobalLight sgl;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        sgl = FindObjectOfType<ShadowGlobalLight>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
           
                ProcessDeath();
            
          
          
        }
    }

    private IEnumerator ReturnPlayerToStart()
    {
    
        yield return new WaitForSeconds(waitBeforeRespawn);
        animator.SetTrigger("Alive");
        if(sgl.globalLight.intensity == sgl.onIntensity)
        {
            transform.position = lightRespawnPosition.transform.position;
        }
        else
        {
            transform.position = shadowRespawnPosition.transform.position;
        }
        
        deathInProgress = false;
        
    }
   public void ProcessDeath()
    {
        transform.SetParent(null);
        if(deathInProgress)
        {
            return;
        }
        deathInProgress = true;
        DeathCounter.instance.amountOfDeaths++;
        Debug.Log(DeathCounter.instance.amountOfDeaths);
        animator.SetTrigger("Death");
        StartCoroutine(ReturnPlayerToStart());
    }
    private void Update()
    {
        if(transform.position.y < -100)
        {
            ProcessDeath();
        }
    }
}
