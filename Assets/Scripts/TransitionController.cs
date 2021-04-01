using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    //MAYBE I'LL CLEAN THIS LATER
    public Animator staticAnimTrucking;
    public Animator staticAnimEntry;
    public Animator staticAnimMain;
    public Animator staticAnimSorting;

    public AudioSource staticAudioSource;
    public AudioClip staticSound;

    public void staticMain()
    {
        staticAnimMain.SetTrigger("transition");
        staticAnimEntry.SetTrigger("default");
        staticAnimSorting.SetTrigger("default");
        staticAnimTrucking.SetTrigger("default");

        staticAudioSource.PlayOneShot(staticSound, 0.05F);
    }
    public void staticTrucking()
    {
        staticAnimTrucking.SetTrigger("transition");
        staticAnimEntry.SetTrigger("default");
        staticAnimMain.SetTrigger("default");
        staticAnimSorting.SetTrigger("default");

        staticAudioSource.PlayOneShot(staticSound, 0.05F);
    }
    public void staticEntry()
    {
        staticAnimEntry.SetTrigger("transition");
        staticAnimTrucking.SetTrigger("default");
        staticAnimMain.SetTrigger("default");
        staticAnimSorting.SetTrigger("default");

        staticAudioSource.PlayOneShot(staticSound, 0.05F);
    }
    public void staticSorting()
    {
        staticAnimSorting.SetTrigger("transition");
        staticAnimEntry.SetTrigger("default");
        staticAnimMain.SetTrigger("default");
        staticAnimTrucking.SetTrigger("default");

        staticAudioSource.PlayOneShot(staticSound, 0.05F);
    }

}
