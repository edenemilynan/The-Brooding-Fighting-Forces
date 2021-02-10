using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{

    public GameObject mainScreen;
    public GameObject truckingScreen;
    public GameObject scanningScreen;

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            mainScreen.SetActive(true);
            truckingScreen.SetActive(false);
            scanningScreen.SetActive(false);
        }

        if (Input.GetKeyDown("t"))
        {
            mainScreen.SetActive(false);
            truckingScreen.SetActive(true);
            scanningScreen.SetActive(false);
        }

        if (Input.GetKeyDown("s"))
        {
            mainScreen.SetActive(false);
            truckingScreen.SetActive(false);
            scanningScreen.SetActive(true);
        }

    }
}
