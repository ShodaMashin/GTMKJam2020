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
    }

    public void UpdateBar(float percentage)
    {
        float currentWidth = (percentage / 100) * maxWidth;

        if(currentWidth > maxWidth)
        {
            currentWidth = maxWidth;
        }

        progressBar.sizeDelta = new Vector2(currentWidth - maxWidth - 6, progressBar.sizeDelta.y);
    }
}
