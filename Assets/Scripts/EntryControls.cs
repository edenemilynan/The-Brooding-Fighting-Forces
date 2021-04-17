using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryControls : MonoBehaviour
{
    public Animator leftDoor;
    public Animator rightDoor;
    public Animator scanner;
    public Animator scanBeam;
    public Animator redLight;
    public Animator greenLight;

    public AudioClip doorSound;
    public AudioClip scannerSound;
    public AudioSource audioSource;

    public void Start()
    {
        rightDoor.SetBool("isHighlighted", true);
    }

    public void EntryRightOpen()
    {
        if (rightDoor.GetBool("entryOpen") != true)
        {
            rightDoor.SetBool("entryOpen", true);
            greenLight.SetBool("allow", false);
            redLight.SetBool("disallow", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void EntryRightClose()
    {
        if (rightDoor.GetBool("entryOpen") != false)
        {
            rightDoor.SetBool("entryOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void EntryLeftOpen()
    {
        if (leftDoor.GetBool("entryOpen") != true)
        {
            leftDoor.SetBool("entryOpen", true);
            redLight.SetBool("disallow", false);
            greenLight.SetBool("allow", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }


    }

    public void EntryLeftClose()
    {
        if (leftDoor.GetBool("entryOpen") != false)
        {
            leftDoor.SetBool("entryOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void scanOn()
    {
        scanner.SetBool("scan", true);
        scanBeam.SetTrigger("scan");
        audioSource.PlayOneShot(scannerSound, 0.7f);
    }

    public void Allow()
    {
        greenLight.SetBool("allow", true);
        //entry.ResetTrigger("allow");
    }

    public void Disallow()
    {
        redLight.SetBool("disallow", true);
        //entry.ResetTrigger("disallow");
    }

    public void switchHighlight()
    {
        if (leftDoor.GetBool("isHighlighted") == true)
        {
            leftDoor.SetBool("isHighlighted", false);
            rightDoor.SetBool("isHighlighted", true);
        }

        else
        {
            leftDoor.SetBool("isHighlighted", true);
            rightDoor.SetBool("isHighlighted", false);
        }
    }
}
