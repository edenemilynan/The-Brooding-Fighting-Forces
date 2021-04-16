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
        callFromBexos.SetBool("visible", true);
    }

    public void hideBexosCall()
    {
        callFromBexos.SetBool("visible", false);
    }

    public void areOnThePhone()
    {
        onThePhone.SetBool("visible", true);
    }

    public void hideOnThePhone()
    {
        onThePhone.SetBool("visible", true);
    }

    public void triggerExplosion()
    {
        explosion.SetBool("visible", true);
    }

    public void hideExplosion()
    {
        explosion.SetBool("visible", false);
    }

    public void triggerStatic()
    {
        staticScreen.SetBool("visible", true);
    }

    public void hideStatic()
    {
        staticScreen.SetBool("visible", true);
    }

    public void triggerVirusDeath()
    {
        virusDeath.SetBool("visible", true);
    }

    public void hideVirusDeath()
    {
        virusDeath.SetBool("visible", true);
    }
}
