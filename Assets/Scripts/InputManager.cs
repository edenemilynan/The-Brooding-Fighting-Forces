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
    public GameObject truckingDoor;
    public GameObject DialogueController;
    public GameObject TruckingController;
    public GameObject PeopleController;

    public Animator ramp;
    public Animator entryDoor;

    public TaskManager taskManager;

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
                if (scanningScreen.activeInHierarchy)
                {
                    entryDoor.SetBool("entryIsOpen", false);
                }

                else if (truckingScreen.activeInHierarchy)
                {
                    truckingDoor.GetComponent<TruckDoor>().TruckDoorClose();

                    //Comment out for testing though ultimately this will need to change
                    /*if(!convo4activated && convo3activated)
                    {   
                        convo4activated = true;
                        DialogueController.GetComponent<DialogueController>().fourthConversation = false;
                    }*/
                }
            }
            if (morseCommand == ".-") // Affirm
            {
                if (scanningScreen.activeInHierarchy)
                {
                    entryDoor.SetBool("entryIsOpen", true);

                    if (taskManager.task == "people")
                    {
                        PeopleController.GetComponent<TruckingController>().path += 1;
                        taskManager.GetTask();
                    }
                }
                else if (truckingScreen.activeInHierarchy)
                {
                    truckingDoor.GetComponent<TruckDoor>().TruckDoorOpen();
                    //Normally check if car is here but cut for prototype

                    if (taskManager.task == "truck")
                    {
                        TruckingController.GetComponent<TruckingController>().path += 1;
                        taskManager.GetTask();
                    }
                        
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
