using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    // Other objects
    public GrindingRenderer grindGame;
    public Canvas grindCanvas;
    public SteamingRenderer steamGame;
    public Canvas steamCanvas;
    public PouringRenderer pourGame;
    public Canvas pourCanvas;

    // Tracking coffee progress
    public CoffeeCup currentCup;
    private string currentStep;

    // Grinding game
    private char lastKeyPressed;

    // Steaming game
    private float steamBarPos;
    private float steamBarVelocity;

    // Pouring game
    private float pourVelocity = 40;
    private float coffeeRatio = 0;
    private float milkRatio = 0;
    private const float POURTARGET = 1f/3f;
    private const float THRESHOLD = 100;

    private DriverController dc;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = "none";
        lastKeyPressed = ' ';

        grindCanvas.enabled = false;
        steamCanvas.enabled = false;
        pourCanvas.enabled = false;

        dc = GetComponent<DriverController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStep)
        {
            case "grind":
                GrindCoffee();
            break;
            case "steam":
                SteamMilk();
            break;
            case "pour":
                PourCoffee();
            break;
            case "none":
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NextStep();
                }
            break;
        }
    }

    public void NextStep()
    {
        switch (currentStep)
        {
            case "grind":
                currentStep = "steam";
                grindCanvas.enabled = false;
                steamCanvas.enabled = true;

                Debug.Log("steaming");
                break;
            case "steam":
                currentStep = "pour";
                steamCanvas.enabled = false;
                pourCanvas.enabled = true;

                Debug.Log("pouring");
                break;
            case "pour":
                SendCup();
                currentStep = "none";
                pourCanvas.enabled = false;

                Debug.Log("new cup");
                break;
            case "none":
                NewCup();
                currentStep = "grind";
                grindCanvas.enabled = true;

                Debug.Log("grinding");
                break;
        }
    }

    public void NewCup()
    {
        currentCup = new CoffeeCup();
        currentCup.grindQuality = 0;
        currentCup.milkQuality = 0;
        currentCup.pourQuality = 0;

        steamBarPos = 0;
        steamBarVelocity = 200;

        coffeeRatio = 0;
        milkRatio = 0;
    }

    public void GrindCoffee()
    {
        char keyPressed = ' ';

        if (Input.GetKeyDown(KeyCode.A)) keyPressed = 'a';
        if (Input.GetKeyDown(KeyCode.D)) keyPressed = 'd';

        if (keyPressed != lastKeyPressed && keyPressed != ' ')
        {
            currentCup.grindQuality += 1;
            if (currentCup.grindQuality > 100) currentCup.grindQuality = 100;

            Debug.Log(currentCup.grindQuality);

            lastKeyPressed = keyPressed;
        }

        grindGame.UpdateBar(currentCup.grindQuality);

        if (Input.GetKeyDown(KeyCode.Space) && currentCup.grindQuality > 0)
        {
            NextStep();
        }
    }

    public void SteamMilk()
    {
        // TODO logic for milk steaming and interact with the SteamingRenderer
        steamBarPos += steamBarVelocity * Time.deltaTime;

        if (steamBarPos >= 100)
        {
            steamBarVelocity = -steamBarVelocity;
            steamBarPos = 100;
        }
        else if(steamBarPos <= 0)
        {
            steamBarVelocity = -steamBarVelocity;
            steamBarPos = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            steamBarVelocity = 0;

            float quality;
            if(steamBarPos < 50)
            {
                quality = steamBarPos * 2;
            }
            else
            {
                quality = -(steamBarPos - 100) * 2;
            }

            currentCup.milkQuality = quality;
        }

        if(steamBarVelocity == 0 && Input.GetKeyDown(KeyCode.R))
        {
            steamBarVelocity = 200;
            steamBarPos = 0;
        }

        steamGame.UpdateBar(steamBarPos);

        if (Input.GetKeyDown(KeyCode.Space) && steamBarVelocity == 0)
        {
            NextStep();
        }
    }

    public void PourCoffee()
    {
        // Inputs
        bool keyCoffee = Input.GetKey(KeyCode.A);
        bool keyMilk = Input.GetKey(KeyCode.D);

        if (coffeeRatio + milkRatio <= THRESHOLD * 2)
        {
            if (keyCoffee)
            {
                coffeeRatio += pourVelocity * Time.deltaTime;
                Debug.Log(coffeeRatio);
            }
            if (keyMilk)
            {
                milkRatio += pourVelocity * Time.deltaTime;
                Debug.Log(milkRatio);
            }
        }

        pourGame.UpdateBar(coffeeRatio, milkRatio, THRESHOLD);

        // Quality = pour ratio percentage distance from perfect pour ratio
        // Quality is in range 0 - 100
        currentCup.pourQuality = Math.Max(0, 100 * (1 - Math.Abs((POURTARGET - (coffeeRatio / (coffeeRatio + milkRatio))) / POURTARGET)));
        Debug.Log("QUA:" + currentCup.pourQuality);
        Debug.Log("VOL:" + (coffeeRatio + milkRatio));

        if (Input.GetKeyDown(KeyCode.Space) && (coffeeRatio + milkRatio) >= THRESHOLD)
        {
            NextStep();
        }
    }

    public void SendCup()
    {
        currentCup.totalQuality = (currentCup.grindQuality + currentCup.milkQuality + currentCup.pourQuality) / 3;
        Debug.Log("sending");

        dc.giveCoffee(currentCup);
    }
}
