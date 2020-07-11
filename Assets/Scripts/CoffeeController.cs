using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    public GrindingRenderer grindGame;
    public Canvas grindCanvas;
    public Canvas steamCanvas;
    public Canvas pourCanvas;

    public CoffeeCup currentCup;
    private string currentStep;
    private char lastKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = "none";
        lastKeyPressed = ' ';
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
            break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextStep();
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
    }

    public void SteamMilk()
    {
        // TODO logic for milk steaming and interact with the SteamingRenderer
    }

    public void PourCoffee()
    {
        float quality = 0;

        currentCup.pourQuality = quality;
    }

    public void SendCup()
    {
        currentCup.totalQuality = (currentCup.grindQuality + currentCup.milkQuality + currentCup.pourQuality) / 3;
        Debug.Log("sending");
        // send cup to driver/game controller idk
    }
}
