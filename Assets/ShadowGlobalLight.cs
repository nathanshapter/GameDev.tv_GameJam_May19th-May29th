using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowGlobalLight : MonoBehaviour
{
    [SerializeField] bool startOff;
    bool lightOn;
    Light2D globalLight;
    public LightSwitch[] switches;

    [SerializeField] float onIntensity = 0.5f;
    [SerializeField] float lightIntensityFadeInx = 6;

    private void Start()
    {
        switches = FindObjectsOfType<LightSwitch>();
        globalLight = GetComponent<Light2D>();

        if(startOff)
        {
            globalLight.intensity = 0;

            if(switches.Length == 0)
            {
                globalLight.intensity = onIntensity;
            }
        }
        else
        {
            globalLight.intensity = onIntensity;
        }
    }

    public void CheckSwitches()
    {
        if(switches.Length == 0)
        {
            globalLight.intensity = onIntensity;
        }
        else
        {
            print($"There are still{switches.Length} to destroy");
        }
    }
}
