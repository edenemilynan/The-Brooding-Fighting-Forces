﻿using System.Collections;
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
    public EntryControls entryControl;

    public Animator ramp;
    public Animator entryDoor;
    public Animator indicatorTrucking;

    public TaskManager taskManager;

    private bool convo2activated = false;
    private bool convo3activated = false;
    public bool convo4activated = false;
    public bool convo5activated = false;
    private bool trucksVisited   = false;
    private bool entryVisited   = false;

    //1 will be right door, -1 will be left
    public int whichEntryDoor = 1;
    //1 will be upper door, -1 will be lower door
    public int whichTruckingDoor = 1;

    //Tries to dequeue task when another task has been 
    //completed, but only succeeds if doors are closed
    public bool taskWaiting = false;

    //If an old task is sitting in task variable
    //because next is not ready to dequeue (doors open)
    //stops scan from being active/incrementing people paths
    private bool oldScan = false;

    //Conditions to trigger dequeue in task manager
    public bool entryLeftOpen = false;
    public bool entryRightOpen = false;
    public bool truckingLeftOpen = false;
    public bool truckingRightOpen = false;

    //Conditions to trigger tasks here
    private bool scanned = false;
    private bool rampDown = false;

    void Start()
    {
        truckingScreen.SetActive(false);
        scanningScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        morseCommand = "";
        SpaceBarInput mi = morseInput.GetComponent<SpaceBarInput>();
        morseCommand = mi.morseReturn;
        
        //The new, beautiful complications of only
        //dequeing a task if the relevant doors are closed
        if (taskWaiting == true) 
        {
            if (taskManager.tasks.Peek() == TaskManager.Tasks.peopleAllow || taskManager.tasks.Peek() == TaskManager.Tasks.peopleDisallow)
            {
                if (entryLeftOpen == false && entryRightOpen == false)
                {
                    taskManager.GetTask();
                    oldScan = false;
                    entryDoor.ResetTrigger("scanner");
                }
            }

            else
            {
                if (truckingLeftOpen == false && truckingRightOpen == false)
                {
                    taskManager.GetTask();
                    oldScan = false;
                }
            }
                
        }

        if (morseCommand != "")
        {
            if (morseCommand == "-") // Trucks
            {
                mainScreen.SetActive(false);
                truckingScreen.SetActive(true);
                scanningScreen.SetActive(false);
                trucksVisited = true;
                //Commented out for testing/narrative needs rework
                //DialogueController.GetComponent<DialogueController>().secondConversation = false;
            }
            if (morseCommand == ".") // Entry
            {
                if (scanningScreen.activeInHierarchy)
                {
                    whichEntryDoor = (whichEntryDoor * (-1));
                }
                else
                {
                    mainScreen.SetActive(false);
                    truckingScreen.SetActive(false);
                    scanningScreen.SetActive(true);
                    entryVisited = true;
                }
                
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
                    //Old entry
                    //entryDoor.SetBool("entryIsOpen", false);

                    if (whichEntryDoor == 1)
                    {
                        entryRightOpen = false;
                        entryControl.EntryRightClose();
                    }

                    else
                    {
                        entryLeftOpen = false;
                        entryControl.EntryLeftClose();
                    }
                }

                else if (truckingScreen.activeInHierarchy)
                {
                    truckingDoor.GetComponent<TruckDoor>().TruckDoorClose();
                    truckingRightOpen = false;

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
                    //Old entry
                    //entryDoor.SetBool("entryIsOpen", true);

                    if (whichEntryDoor == 1)
                    {
                        entryRightOpen = true;
                        entryControl.EntryRightOpen();
                    }

                    else
                    {
                        entryLeftOpen = true;
                        entryControl.EntryLeftOpen();
                    }

                    if (taskManager.task == TaskManager.Tasks.peopleAllow || taskManager.task == TaskManager.Tasks.peopleDisallow)
                    {
                        if (scanned == true)
                        {
                            if (whichEntryDoor == 1)
                            {
                                if (taskManager.task == TaskManager.Tasks.peopleAllow)
                                {
                                    //Increment right/wrong choice
                                }

                                else
                                {
                                    //Increment right/wrong choice
                                }

                            }

                            else
                            {
                                if (taskManager.task == TaskManager.Tasks.peopleDisallow)
                                {
                                    //Increment right/wrong choice
                                }

                                else
                                {
                                    //Increment right/wrong choice
                                }
                            }

                            PeopleController.GetComponent<TruckingController>().path += 1;
                            taskWaiting = true;
                            scanned = false;
                            //taskManager.GetTask();
                        }
                    }
                    
                }
                else if (truckingScreen.activeInHierarchy)
                {
                    truckingDoor.GetComponent<TruckDoor>().TruckDoorOpen();
                    truckingRightOpen = true;
                    //Normally check if car is here but cut for prototype

                    if (taskManager.task == TaskManager.Tasks.truck)
                    {
                        TruckingController.GetComponent<TruckingController>().path += 1;
                        indicatorTrucking.SetBool("IndicatorOn", false);
                        taskWaiting = true;
                        //taskManager.GetTask();
                    }
                        
                    if(!convo3activated)
                    {
                        convo3activated = true;
                        DialogueController.GetComponent<DialogueController>().thirdConversation = false;
                    }
                }
            }
            
            if (morseCommand == "..") // Interact
            {
                if (truckingScreen.activeInHierarchy)
                {
                    if (ramp.GetBool("isRampDown") == false)
                    {
                        ramp.SetBool("isRampDown", true);
                        rampDown = true;
                    }
                    else
                    {
                        ramp.SetBool("isRampDown", false);
                        rampDown = false;
                    }
                }

                if (scanningScreen.activeInHierarchy)
                {
                    entryControl.Scan();

                    if (taskManager.task == TaskManager.Tasks.peopleAllow && oldScan == false) 
                    {
                        scanned = true;
                        oldScan = true;
                        entryControl.Allow();
                    }
                    else if (taskManager.task == TaskManager.Tasks.peopleDisallow && oldScan == false)
                    {
                        scanned = true;
                        oldScan = true;
                        entryControl.Disallow();
                    }

                        
                        
                }
            }
            
            else 
            {
                // Invalid Input
                Debug.Log("Invalid Input");
            }




        }

        if (trucksVisited && entryVisited && !convo2activated)
        {
            DialogueController.GetComponent<DialogueController>().secondConversation = false;
            convo2activated = true;
        }

        if (convo4activated && mainScreen.activeInHierarchy && !convo5activated)
        {
            Debug.Log("You made it here, you saucy son of a bitch");
            DialogueController.GetComponent<DialogueController>().fifthConversation = false;
            convo5activated = true;
        }
    }

    public void setConvo4Activated(bool val)
    {
        convo4activated = val;
    }
}
