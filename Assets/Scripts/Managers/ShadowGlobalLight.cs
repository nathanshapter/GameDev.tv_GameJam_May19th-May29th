using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowGlobalLight : MonoBehaviour
{
    [SerializeField] bool startOff;
    bool lightOn;
  public  Light2D globalLight;
    public LightSwitch[] switches;

   public  float onIntensity = 0.5f;
    [SerializeField] float lightIntensityFadeInx = 6;

    [SerializeField] GameObject coinsToCollect;
    [SerializeField] GameObject[] shadowWorld;
    [SerializeField] GameObject[] lightWorld;
    PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        switches = FindObjectsOfType<LightSwitch>();
        globalLight = GetComponent<Light2D>();

        if(startOff)
        {
            coinsToCollect.SetActive(false);
            globalLight.intensity = 0;

            FlickLight(false);
            FlickShadow(true);
        }
        else
        {
            globalLight.intensity = onIntensity;
            FlickLight(true);
            FlickShadow(false);

        }
    }

    public void CheckSwitches()
    {
        if(switches.Length == 0)
        {
            globalLight.intensity = onIntensity;
            coinsToCollect.SetActive(true);
            FlickLight(true);
            FlickShadow(false); 
        }
        else
        {
            print($"There are still{switches.Length} to destroy");
        }
    }

    void FlickShadow(bool v)
    {
        player.transform.SetParent(null);

        foreach (var item in shadowWorld)
        {
            item.SetActive(v);
        }
    }
    void FlickLight(bool v)
    {
        player.transform.SetParent(null);
        foreach (var item in lightWorld)
        {
            item.SetActive(v);
        }
    }
}
