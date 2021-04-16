using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopControls : MonoBehaviour
{

    public Animator callFromBexos;

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

}
