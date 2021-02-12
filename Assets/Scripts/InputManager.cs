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
    public Animator entryDoor;
    public Animator truckingDoor;
    public Animator ramp;
    public GameObject DialogueController;

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
                DialogueController.GetComponent<DialogueController>().secondConversation = false;
            }
            /*if (morseCommand == ".") // Entry
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
            }*/
            if (morseCommand == "-.") // Negative
            {
                if (scanningScreen.activeInHierarchy)
                {
                    entryDoor.SetBool("entryIsOpen", false);
                }

                else if (truckingScreen.activeInHierarchy)
                {
                    truckingDoor.SetBool("isTruckingOpen", false);
                }
            }
            if (morseCommand == ".-") // Affirm
            {
                if (scanningScreen.activeInHierarchy)
                {
                    entryDoor.SetBool("entryIsOpen", true);
                }
                else if (truckingScreen.activeInHierarchy)
                {
                    truckingDoor.SetBool("isTruckingOpen", true);
                }
            }
            /*
            if (morseCommand == "..") // Interact
            {
                if (truckingScreen.activeInHierarchy)
                {
                    if (ramp.GetBool("isRampDown") == false)
                    {
                        ramp.SetBool("isRampDown", true);
                    }
                    else ramp.SetBool("isRampDown", false);
                }
            }
            */
            else 
            {
                // Invalid Input
                Debug.Log("Invalid Input");
            }




        }
    }
}
