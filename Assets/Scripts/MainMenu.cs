using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    float timePassed;
    public SpriteRenderer NotWinking;
    public SpriteRenderer Winking;

    private SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend = NotWinking;
        spriteRend.sortingOrder = 1;

    }
    void Update()
    {
        timePassed += Time.deltaTime;
        Debug.Log(timePassed);
        // Every few seconds, switch between images
        if(timePassed >= 2)
        {
            timePassed = 0;
            if(spriteRend.sortingOrder == 1)
            {
                spriteRend.sortingOrder = -1;
            }
            else
            {
                spriteRend.sortingOrder = 1;
            }

        }

    }
}
