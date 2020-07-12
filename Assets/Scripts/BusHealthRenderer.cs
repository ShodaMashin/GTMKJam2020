using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusHealthRenderer : MonoBehaviour
{
    public RectTransform healthBar;

    private float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = healthBar.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        float currentHeight = (Storage.BusHealth / 100) * maxHeight;

        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, currentHeight - maxHeight - 4);
    }
}
