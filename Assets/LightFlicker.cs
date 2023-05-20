using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] Light2D redLight;
    [SerializeField] float period = 2f;
    [SerializeField] float addedIntensity;
    [SerializeField] bool turnOnProximity = true;
    PlayerController player;
    public float turnOnDistance = 5;
    [SerializeField] bool varyLights;
    public bool turnOffRandomly;
    [SerializeField] bool lightOn = true;
    [SerializeField][Range(0f, 100f)] float chanceToTurnOffPercentage;
    float periodIncrease;
    [SerializeField] float timeToStayOff = 5;
    [SerializeField] int timeBetweenTicks = 1;
    int timeBetweenTicksVariance = 0;
    bool isRunningCoroutine;
    float percentageToTurnOff;

    private void Start()
    {
        redLight= GetComponentInChildren<Light2D>();


        timeBetweenTicksVariance = Random.Range(-5, 5);
        player = FindObjectOfType<PlayerController>();
        if (varyLights)
        {
            periodIncrease = Random.Range(0, 5);
        }
        else { periodIncrease = 0; }
    }
    private void Update()
    {
        if (!lightOn) { return; }
        float numberVariance = Random.Range(0, 0.2f);



        if (turnOnProximity)
        {
            if (Vector2.Distance(player.transform.position, redLight.transform.position) < turnOnDistance)
            {
                turnOnProximity = false;
            }

            redLight.intensity = 0;
            return;
        }

        float cycles = Time.time / (period + periodIncrease);

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau + 1);

        redLight.intensity = (rawSinWave + 1) + addedIntensity * (numberVariance) + 1;


        if (turnOffRandomly && !isRunningCoroutine)
        {
            StartCoroutine(TurnOffChance());
        }

    }
    IEnumerator TurnOffChance()
    {
        percentageToTurnOff = Random.Range(0, 100);

        isRunningCoroutine = true;
        yield return new WaitForSeconds(timeBetweenTicks + timeBetweenTicksVariance);
        if (percentageToTurnOff > chanceToTurnOffPercentage)
        {
            lightOn = false;
            redLight.intensity = 0;
            yield return new WaitForSeconds(timeToStayOff);
            lightOn = true;
        }
        isRunningCoroutine = false;
    }
}
