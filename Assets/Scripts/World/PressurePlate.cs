using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Lever lever;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.transform.CompareTag("Box"))
        {
            lever.leverPressed= true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Box"))
        {
            lever.leverPressed= false;
        }
      
    }


  
}
