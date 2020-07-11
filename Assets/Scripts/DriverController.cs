using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    // Once value reaches zero driver falls asleep
    [Serializable]
    private float awakeLevel = 100f;
    [Serializable]
    private float decayRate = 0.1f;
    [Serializable]
    private const float COFFEEVALUE = 33f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (awakeLevel > 0)
        {
            decay();
        }
        else
        {
            // TODO: cause damage to bus
            // take a major value off the static bus health field
        }
    }

    // Increase the awake value based on constant coffeeValue * incoming quality (as a percentage)
    public void giveCoffee(CoffeeCup cup)
    {
        awakeLevel += (cup.totalQuality / 100) * COFFEEVALUE;
    }

    private void decay()
    {
        if(awakeLevel - decayRate > 0)
        {
            awakeLevel -= decayRate;
        } else
        {
            awakeLevel = 0f;
        }
    }
}
