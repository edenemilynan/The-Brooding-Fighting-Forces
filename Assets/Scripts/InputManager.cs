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
    public GameObject truckingDoor;
    public Animator ramp;
    public GameObject DialogueController;
    public GameObject TruckingController;

    private bool convo3activated = false;
    private bool convo4activated = false;


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
                    truckingDoor.GetComponent<TruckDoor>().TruckDoorClose();
                    Debug.Log("Got right here, convo4activate == " + convo4activated);
                    if(!convo4activated && convo3activated)
                    {   
                        convo4activated = true;
                        DialogueController.GetComponent<DialogueController>().fourthConversation = false;
                    }
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
                    truckingDoor.GetComponent<TruckDoor>().TruckDoorOpen();
                    //Normally check if car is here but cut for prototype
                    TruckingController.GetComponent<TruckingController>().path = 0;
                    if(!convo3activated)
                    {
                        convo3activated = true;
                        DialogueController.GetComponent<DialogueController>().thirdConversation = false;
                    }
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
