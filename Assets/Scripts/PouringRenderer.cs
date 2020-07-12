using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringRenderer : MonoBehaviour
{
    public RectTransform coffeeBar;
    public RectTransform milkBar;
    private float maxWidth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = coffeeBar.rect.width;
    }

    public void UpdateBar(float coffee, float milk, float THRESHOLD)
    {
        float coffeeWidth = (coffee / (THRESHOLD * 2)) * maxWidth;
        float milkWidth = (milk / (THRESHOLD * 2)) * maxWidth;
        float totalWidth = coffeeWidth + milkWidth;

        coffeeBar.sizeDelta = new Vector2(coffeeWidth - maxWidth - 6, coffeeBar.sizeDelta.y);
        milkBar.sizeDelta = new Vector2(coffeeWidth + milkWidth - maxWidth - 6, milkBar.sizeDelta.y);
    }
}
