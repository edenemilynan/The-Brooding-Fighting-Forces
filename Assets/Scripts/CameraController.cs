using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //public GameObject mainScreen;
    public GameObject truckingScreen;
    public GameObject scanningScreen;
    public GameObject sortingScreen;

    void Start()
    {
        truckingScreen.SetActive(false);
        scanningScreen.SetActive(false);
        sortingScreen.SetActive(false);
    }

    public void truckingCamera()
    {
        truckingScreen.SetActive(true);
        scanningScreen.SetActive(false);
        sortingScreen.SetActive(false);
    }

    public void entryCamera()
    {
        scanningScreen.SetActive(true);
        truckingScreen.SetActive(false);
        sortingScreen.SetActive(false);
    }

    public void sortingCamera()
    {
        sortingScreen.SetActive(true);
        truckingScreen.SetActive(false);
        scanningScreen.SetActive(false);
    }

    public void mainCamera()
    {
        truckingScreen.SetActive(false);
        scanningScreen.SetActive(false);
        sortingScreen.SetActive(false);
    }
}
