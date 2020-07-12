using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public GameObject busObject;
    public Sprite busOne;
    public Sprite busTwo;

    public GameObject backgroundObject;
    public Sprite background1;
    public Sprite background2;
    public Sprite background3;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateBus());
        StartCoroutine(AnimateBackground());
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private IEnumerator AnimateBus()
    {
        while (true)
        {
            var currentSprite = busObject.GetComponent<SpriteRenderer>().sprite;
            if (currentSprite == busOne)
            {
                busObject.GetComponent<SpriteRenderer>().sprite = busTwo;
            } else if (currentSprite == busTwo)
            {
                busObject.GetComponent<SpriteRenderer>().sprite = busOne;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator AnimateBackground()
    {
        while (true)
        {
            var currentSpriteRenderer = backgroundObject.GetComponent<SpriteRenderer>();
            if (currentSpriteRenderer.sprite == background1)
            {
                currentSpriteRenderer.sprite = background2;
            }
            else if (currentSpriteRenderer.sprite == background2)
            {
                currentSpriteRenderer.sprite = background3;
            }
            else if (currentSpriteRenderer.sprite == background3)
            {
                currentSpriteRenderer.sprite = background1;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
