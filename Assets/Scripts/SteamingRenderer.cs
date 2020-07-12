using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamingRenderer : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform slider;
    private float maxWidth, minWidth, center;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = bar.rect.width;
        minWidth = -(bar.rect.width / 2);
        center = slider.position.x;
    }

    public void UpdateBar(float percentage)
    {
        float currentWidth = (percentage / 100) * maxWidth;

        if (currentWidth > maxWidth)
        {
            currentWidth = maxWidth;
        }

        slider.position = new Vector3(center + minWidth + currentWidth, slider.position.y, slider.position.z);
    }
}
