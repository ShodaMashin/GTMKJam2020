using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
    private static float busHealth = 100;

    public static float BusHealth {
        get {
            return busHealth;
        }
        set {
            busHealth = value;
        }
    }
}
