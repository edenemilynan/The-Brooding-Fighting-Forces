using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    float timePassed;
    public SpriteRenderer NotWinking;
    public SpriteRenderer Winking;

    private SpriteRenderer spriteRend;

    public AudioSource ad;
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend = NotWinking;
        spriteRend.sortingOrder = 1;
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        //Debug.Log(timePassed);
        // Every few seconds, switch between images
        if(timePassed >= 15 && spriteRend.sortingOrder == 1)
        {
            timePassed = 0;
            spriteRend.sortingOrder = -1;
            ad.Play();

        }
        else if (timePassed >= 1 && spriteRend.sortingOrder == -1)
        {
             timePassed = 0;
             spriteRend.sortingOrder = 1;
        }

    }
}
