using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverRenderer : MonoBehaviour
{
    public RectTransform driverBar;

    private DriverController dc;
    private float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        dc = FindObjectOfType<DriverController>();
        maxHeight = driverBar.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        float currentHeight = (dc.awakeLevel / 100) * maxHeight;

        driverBar.sizeDelta = new Vector2(driverBar.sizeDelta.x, currentHeight - maxHeight - 4);
    }
}
