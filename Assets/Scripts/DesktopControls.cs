﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControls : MonoBehaviour
{

    public Animator callFromBexos;
    public Animator onThePhone;
    public Animator explosion;
    public Animator staticScreen;
    public Animator virusDeath;
    public Animator virusAnimation;
    public Animator personFalling;
    public Animator confirmationScreen;
    public Animator memo;
    public Animator alert;
    public Animator terminateQuestion;
    public Animator ending1;
    public Animator ending2;
    public Animator ending3;
    public Animator ending4;
    public Animator ending5;

    public AudioClip ringSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bexosCalling()
    {
        if(callFromBexos.GetBool("visible")) { return; }
        callFromBexos.SetBool("visible", true);
        audioSource.PlayOneShot(ringSound, 0.7f);
    }

    public void hideBexosCall()
    {
        if( !callFromBexos.GetBool("visible")) { return; }
        callFromBexos.SetBool("visible", false);
    }

    public void areOnThePhone()
    {
        if(onThePhone.GetBool("visible")) { return; }
        onThePhone.SetBool("visible", true);
        audioSource.Stop();
    }

    public void hideOnThePhone()
    {
        if( !onThePhone.GetBool("visible")) { return; }
        onThePhone.SetBool("visible", false);
    }

    public void triggerExplosion()
    {
        if(explosion.GetBool("visible")) { return; }
        explosion.SetBool("visible", true);
    }

    public void hideExplosion()
    {
        if( !explosion.GetBool("visible")) { return; }
        explosion.SetBool("visible", false);
    }

    public void triggerStatic()
    {
        if(staticScreen.GetBool("visible")) { return; }
        Debug.Log("Showing static");

        staticScreen.SetBool("visible", true);
    }

    public void hideStatic()
    {
        // Debug.Log(staticScreen.GetBool("visible"));
        // if(staticScreen.GetBool("visible")) { return; }
        // Debug.Log("Hiding static");
        staticScreen.SetBool("visible", false);
        // Debug.Log(staticScreen.GetBool("visible"));

    }

    public void showVirusOnScreen()
    {
        //if( xxx.GetBool("visible")) { return; }
        virusAnimation.SetBool("visible", true);
        Debug.Log("TK Add the call for showing the virus");
    }

    public void hideVirusOnScreen()
    {
        // if(!xxx.GetBool("visible")) { return; }
        virusAnimation.SetBool("visible", false);
        Debug.Log("TK Add the call for hiding the virus");
    }

    public void triggerVirusDeath()
    {
        if(virusDeath.GetBool("visible")) { return; }
        virusDeath.SetBool("visible", true);
    }

    public void hideVirusDeath()
    {
        if(!virusDeath.GetBool("visible")) { return; }
        virusDeath.SetBool("visible", false);
    }

    public void personFalls()
    {
        if (!personFalling.GetBool("visible"))
        {
            personFalling.SetBool("visible", true);
        }
    }

    public void showConfirm()
    {
        confirmationScreen.SetBool("visible", true);
    }

    public void hideConfirm()
    {
        confirmationScreen.SetBool("visible", false);
    }

    public void hideMemo()
    {
        memo.SetBool("visible", false);
    }

    public void showMemo()
    {
        memo.SetBool("visible", true);
    }

    public void hideAlert()
    {
        memo.SetBool("visible", false);
    }

    public void showAlert()
    {
        memo.SetBool("visible", true);
    }

    public void showTerminate()
    {
        terminateQuestion.SetBool("visible", true);
    }

    public void hideTerminate()
    {
        terminateQuestion.SetBool("visible", false);
    }

    public void firstEnding()
    {
        ending1.SetBool("visible", true);
    }

    public void secondEnding()
    {
        ending2.SetBool("visible", true);
    }

    public void thirdEnding()
    {
        ending3.SetBool("visible", true);
    }

    public void fourthEnding()
    {
        ending4.SetBool("visible", true);
    }

    public void fifthEnding()
    {
        ending5.SetBool("visible", true);
    }
}
