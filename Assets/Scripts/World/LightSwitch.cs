using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class LightSwitch : MonoBehaviour
{
    ShadowGlobalLight sgl;

    private void Start()
    {
        sgl = GetComponentInParent<ShadowGlobalLight>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Array.Resize(ref sgl.switches, sgl.switches.Length - 1);
            sgl.CheckSwitches();
            gameObject.SetActive(false);

        }
    }
}
