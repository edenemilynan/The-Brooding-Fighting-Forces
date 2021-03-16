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
    public EntryControls entryControl;

    public Animator ramp;
    public Animator entryDoor;
    public Animator indicatorTrucking;

    public TaskManager taskManager;
    public NotificationManager notifManager;

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
    //private bool oldScan = false;
    public bool scannable = false;

    //Conditions to trigger dequeue in task manager
    public bool entryLeftOpen = false;
    public bool entryRightOpen = false;
    public bool truckingLeftOpen = false;
    public bool truckingRightOpen = false;

    //Conditions to trigger tasks here
    private bool scanned = false;
    private bool rampDown = false;

    public string activeScreen = "main";
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

        //Switching nofitication icon
        notifManager.DisplayNotif(taskManager.task, activeScreen);

        //The new, beautiful complications of only
        //dequeing a task if the relevant doors are closed
        if (taskWaiting == true && taskManager.tasks.Count != 0) 
        {
            if (taskManager.tasks.Peek() == TaskManager.Tasks.peopleAllow || taskManager.tasks.Peek() == TaskManager.Tasks.peopleDisallow)
            {
                if (entryLeftOpen == false && entryRightOpen == false)
                {
                    taskManager.GetTask();
                    //oldScan = false;
                    //entryDoor.ResetTrigger("scanner");
                }
            }

            else
            {
                if (truckingLeftOpen == false && truckingRightOpen == false)
                {
                    taskManager.GetTask();
                    //oldScan = false;
                }
            }
                
        }

        Debug.Log(taskManager.tasks.Count);
        Debug.Log(taskManager.task);

        if(taskManager.tasks.Count == 0 && taskManager.task != TaskManager.Tasks.none)
        {
            taskManager.GetTask();
        }

        if(taskManager.tasks.Count == 0 && taskManager.task == TaskManager.Tasks.none)
        {
            DialogueController.GetComponent<DialogueController>().readyForFourthConvo = true;
        }

        if (morseCommand != "")
        {
            if (morseCommand == "-") // Trucks
            {
                activeScreen = "truck";
                truckingScreen.SetActive(true);
                scanningScreen.SetActive(false);
                mainScreen.SetActive(true);
                trucksVisited = true;

                //Commented out for testing/narrative needs rework
                //DialogueController.GetComponent<DialogueController>().secondConversation = false;
            }
            if (morseCommand == ".") // Entry
            {
                activeScreen = "entry";
                if (scanningScreen.activeInHierarchy)
                {
                    whichEntryDoor = (whichEntryDoor * (-1));
                    entryControl.switchHighlight();
                }
                else
                {
                    truckingScreen.SetActive(false);
                    scanningScreen.SetActive(true);
                    entryVisited = true;
                }

            }
            if (morseCommand == "--") // Main
            {
                activeScreen = "main";
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
                    //If no one's waiting at the door, you can open it.
                    if (taskManager.task != TaskManager.Tasks.peopleAllow && taskManager.task != TaskManager.Tasks.peopleDisallow)
                    {
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
                    }
                   
                    //If people are waiting, they have to be scanned before they're let in.
                    else if (scanned == true)
                    {
                        if (whichEntryDoor == 1)
                        {
                            entryRightOpen = true;
                            entryControl.EntryRightOpen();

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
                            entryLeftOpen = true;
                            entryControl.EntryLeftOpen();

                            if (taskManager.task == TaskManager.Tasks.peopleDisallow)
                            {
                                //Increment right/wrong choice
                            }

                            else
                            {
                                //Increment right/wrong choice
                            }
                        }

                        //Set person on rest of path, let know task is waiting to deque.
                        PeopleController.GetComponent<TruckingController>().path += 1;
                        taskWaiting = true;
                        scanned = false;
                        scannable = false;
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
                    entryControl.scanOn();

                    if (taskManager.task == TaskManager.Tasks.peopleAllow && scannable == true) // && oldScan == false
                    {
                        scanned = true;
                        //oldScan = true;
                        entryControl.Allow();
                    }
                    else if (taskManager.task == TaskManager.Tasks.peopleDisallow && scannable == true)
                    {
                        scanned = true;
                        //oldScan = true;
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

        if (convo4activated && activeScreen == "main" && !convo5activated)
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
