using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    // Once value reaches zero driver falls asleep
    [SerializeField]
    public float awakeLevel = 100f;
    [SerializeField]
    private float decayRate = 1f;
    [SerializeField]
    private float busDamageRate = 5f;

    private const float COFFEEVALUE = 50f;

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
            if (Storage.BusHealth - busDamageRate > 0)
            {
                Storage.BusHealth -= busDamageRate * Time.deltaTime;
            }
            else
            {
                Storage.BusHealth = 0f;
            }
        }
    }

    // Increase the awake value based on constant coffeeValue * incoming quality (as a percentage)
    public void giveCoffee(CoffeeCup cup)
    {
        awakeLevel += (cup.totalQuality / 100) * COFFEEVALUE;
        if (awakeLevel > 100)
        {
            awakeLevel = 100f;
        }
    }

    private void decay()
    {
        if(awakeLevel - decayRate > 0)
        {
            awakeLevel -= decayRate * Time.deltaTime;
        } 
        else
        {
            awakeLevel = 0f;
        }
    }
}
