
using UnityEngine;

public static class Storage
{
    public static float BusHealth { get; set; } = 100;
    
    public enum GameState
    {
        Coffee,
        Bus
    }


    public static GameState CurrentGameState { get; set; } = GameState.Bus;
}
