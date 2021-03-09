using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Animator scanBeam;
    public Animator scanner;

    public void scanOff()
    {
        scanBeam.SetTrigger("default");
        scanner.SetBool("scan", false);
    }
}
