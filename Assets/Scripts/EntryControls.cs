using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryControls : MonoBehaviour
{
    public Animator entry;
    public AudioClip doorSound;
    public AudioSource audioSource;

    public void EntryRightOpen()
    {
        if (entry.GetBool("rightEntryIsOpen") != true)
        {
            entry.SetBool("rightEntryIsOpen", true);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
        

    }

    public void EntryRightClose()
    {
        if (entry.GetBool("rightEntryIsOpen") != false)
        {
            entry.SetBool("rightEntryIsOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void EntryLeftOpen()
    {
        if (entry.GetBool("leftEntryIsOpen") != true)
        {
            entry.SetBool("leftEntryIsOpen", true);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }


    }

    public void EntryLeftClose()
    {
        if (entry.GetBool("leftEntryIsOpen") != false)
        {
            entry.SetBool("leftEntryIsOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void Scan()
    {
        entry.SetTrigger("scanner");
        entry.SetTrigger("default");
    }

    public void Allow()
    {
        entry.SetTrigger("allow");
        //entry.ResetTrigger("allow");
    }

    public void Disallow()
    {
        entry.SetTrigger("disallow");
        //entry.ResetTrigger("disallow");
    }
}
