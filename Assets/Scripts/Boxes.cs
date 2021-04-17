using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{

    public Animator boxes;
    public Animator openBoxes;
    public Animator belt;
    public AudioClip burrr;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBoxes()
    {
        boxes.SetBool("ready", false);
    }

    public void newBoxes()
    {
        openBoxes.SetBool("visible", true);
    }

    public void hideOpenBoxes()
    {
        openBoxes.SetBool("visible", false);
    }

    public void roll()
    {
        belt.SetBool("rolling", true);
        audioSource.PlayOneShot(burrr, 0.7F);
    }

    public void stopRoll()
    {
        belt.SetBool("rolling", false);
    }
}
