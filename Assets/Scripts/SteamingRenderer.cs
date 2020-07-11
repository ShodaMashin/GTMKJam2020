using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamingRenderer : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform slider;
    private float maxWidth, minWidth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = bar.rect.width;
        minWidth = -(bar.rect.width / 2);
    }

    public void UpdateBar(float percentage)
    {
        float currentWidth = (percentage / 100) * maxWidth;

        if (currentWidth > maxWidth)
        {
            currentWidth = maxWidth;
        }

        slider.position = new Vector3(minWidth + currentWidth, slider.position.y, slider.position.z);
    }
}
