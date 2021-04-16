using System.Collections;
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
        Debug.Log("TK Add the call for showing the virus");
    }

    public void hideVirusOnScreen()
    {
        // if(!xxx.GetBool("visible")) { return; }
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
}
