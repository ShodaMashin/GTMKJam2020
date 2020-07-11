using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingRenderer : MonoBehaviour
{
    public RectTransform progressBar;
    private float maxWidth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = progressBar.rect.width;

        progressBar.offsetMax = new Vector2(0, 0);
    }

    public void UpdateBar(float percentage)
    {
        float currentWidth = (percentage / 100) * maxWidth;

        if(currentWidth > maxWidth)
        {
            currentWidth = maxWidth;
        }

        progressBar.offsetMax = new Vector2(currentWidth, 16 / 2);
    }
}
