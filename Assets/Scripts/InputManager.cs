using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string morseCommand;
    public GameObject mainScreen;
    public GameObject truckingScreen;
    public GameObject scanningScreen;
    public GameObject morseInput;

    // Update is called once per frame
    void Update()
    {
        morseCommand = "";
        SpaceBarInput mi = morseInput.GetComponent<SpaceBarInput>();
        morseCommand = mi.morseReturn;

        if (morseCommand != "")
        {
            if (morseCommand == "-") // Trucks
            {
                mainScreen.SetActive(false);
                truckingScreen.SetActive(true);
                scanningScreen.SetActive(false);
            }
            if (morseCommand == ".") // Entry
            {
                mainScreen.SetActive(false);
                truckingScreen.SetActive(false);
                scanningScreen.SetActive(true);
            }
            if (morseCommand == "--") // Main
            {
                mainScreen.SetActive(true);
                truckingScreen.SetActive(false);
                scanningScreen.SetActive(false);
            }
            if (morseCommand == "-.") // Negative
            {
            }
            if (morseCommand == ".-") // Affirm
            {
            }
            if (morseCommand == "..") // Interact
            {
            }
            else 
            {
                // Invalid Input
                Debug.Log("Invalid Input");
            }




        }
    }
}
