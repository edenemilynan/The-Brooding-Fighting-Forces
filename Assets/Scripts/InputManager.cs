using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string morseCommand;
    public string lastMorseCommand;
    public GameObject mainScreen;
    public GameObject truckingScreen;
    public GameObject scanningScreen;
    public GameObject sortingScreen;
    public GameObject morseInput;
    public GameObject DialogueController;
    public GameObject TruckingController;
    public GameObject PeopleController;
    public EntryControls entryControl;
    public TruckingControls truckingControl;

    public Animator entryDoor;

    public TaskManager taskManager;
    public NotificationManager notifManager;
    public SortingManager sortManager;

    private bool convo2activated = false;
    private bool convo3activated = false;
    public bool convo4activated = false;
    public bool convo5activated = false;
    private bool trucksVisited = false;
    private bool entryVisited = false;
    private bool truckingCompletionConversationActivated = false;
    private bool entryIntroConversationStarted = false;
    private bool entryErrorConversationActivated = false;
    private bool entryCompletionConversationActivated = false;

    //1 will be right door, -1 will be left
    public int whichEntryDoor = 1;
    //1 will be right door, -1 will be left door
    public int whichTruckingDoor = 1;
    //ramp up is -1, ramp down is 1
    public int rampDown = -1;

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

    //For notifications to keep track of what screen we are on
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
                    if (taskManager.tasks.Peek() == taskManager.Tasks.truckLeft) {
                        if (rampDown == -1)
                    {
                        taskManager.GetTask();
                        //oldScan = false;
                    }
                }
                    else
                    {
                        taskManager.GetTask();
                    }
            }
                
        }

        // Debug.Log(taskManager.tasks.Count);
        // Debug.Log(taskManager.task);

        // if(taskManager.tasks.Count == 0 && taskManager.task != TaskManager.Tasks.none)
        // {
        //     taskManager.GetTask();
        // }

        if(taskManager.tasks.Count == 0 && taskManager.task == TaskManager.Tasks.none && !convo4activated)
        {
            DialogueController.GetComponent<DialogueController>().readyForFourthConvo = true;
        }

        //Command Inputs
        if (morseCommand != "")
        {   
            lastMorseCommand = morseCommand;

            //Trucks
            if (morseCommand == "-")
            {
                activeScreen = "truck";
                
                if (truckingScreen.activeInHierarchy)
                {
                    whichTruckingDoor = (whichTruckingDoor * (-1));
                    truckingControl.switchHighlight();
                }

                truckingScreen.SetActive(true);
                scanningScreen.SetActive(false);
                sortingScreen.SetActive(false);
                mainScreen.SetActive(true);
                trucksVisited = true;

                //Commented out for testing/narrative needs rework
                //DialogueController.GetComponent<DialogueController>().secondConversation = false;
            }

            //Entry
            if (morseCommand == ".")
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
                    sortingScreen.SetActive(false);
                    entryVisited = true;
                }

            }

            //Sorting
            if (morseCommand == "...")
            {
                activeScreen = "sorting";

                if (sortingScreen.activeInHierarchy)
                {
                    
                }
                else
                {
                    truckingScreen.SetActive(false);
                    scanningScreen.SetActive(false);
                    sortingScreen.SetActive(true);
                }

            }

            //Main
            if (morseCommand == "--")
            {
                activeScreen = "main";
                truckingScreen.SetActive(false);
                scanningScreen.SetActive(false);
                sortingScreen.SetActive(false);

            }

            //Negative
            if (morseCommand == "-.")
            {
                //Entry Command
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

                //Trucking Command
                else if (truckingScreen.activeInHierarchy)
                {
                    if (whichTruckingDoor == 1)
                    {
                        truckingRightOpen = false;
                        truckingControl.truckRightClose();
                    }

                    else
                    {
                        if (rampDown == 1)
                        {
                            truckingLeftOpen = false;
                            truckingControl.truckLeftClose();
                        }   
                    }

                    //Comment out for testing though ultimately this will need to change
                    /*if(!convo4activated && convo3activated)
                    {   
                        convo4activated = true;
                        DialogueController.GetComponent<DialogueController>().fourthConversation = false;
                    }*/
                }

                //Sorting Command
                else if (sortingScreen.activeInHierarchy)
                {
                    sortManager.validate("negative");

                }
            }

            //Affirm
            if (morseCommand == ".-")
            {
                //Entry Command
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

                //Trucking Command
                else if (truckingScreen.activeInHierarchy)
                {

                    if (whichTruckingDoor == 1)
                    {
                        truckingRightOpen = true;
                        truckingControl.truckRightOpen();

                        if (taskManager.task == TaskManager.Tasks.truckRight)
                        {
                            TruckingController.GetComponent<TruckingController>().path += 1;
                            truckingControl.rightIndicatorOff();
                            //Change trucking indicator
                            taskWaiting = true;
                            //taskManager.GetTask();
                        }
                    }

                    else
                    {
                        //If we randomize the order of the tasks, we'll need to make seperate controllers for 
                        //left and right trucks
                        if (rampDown == 1)
                        {
                            truckingLeftOpen = true;
                            truckingControl.truckLeftOpen();
                            if (taskManager.task == TaskManager.Tasks.truckLeft)
                            {
                                TruckingController.GetComponent<TruckingController>().path += 1;
                                truckingControl.leftIndicatorOff();
                                //Change trucking indicator
                                taskWaiting = true;
                                //taskManager.GetTask();
                            }
                        }
                    }
                    //Normally check if car is here but cut for prototype

                    
                        
                    if(!convo3activated)
                    {
                        convo3activated = true;
                        DialogueController.GetComponent<DialogueController>().thirdConversation = false;
                    }
                }

                //Sorting Command
                else if(sortingScreen.activeInHierarchy)
                {
                    sortManager.validate("affirm");

                }
            }

            //Interact
            if (morseCommand == "..")
            {
                //Trucking Command
                if (truckingScreen.activeInHierarchy)
                {
                    if (truckingLeftOpen == false)
                    {
                        truckingControl.rampActivate();
                        rampDown = (rampDown * (-1));
                    }
                }

                //Entry Command
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

                //Sorting Command
                else if (sortingScreen.activeInHierarchy)
                {
                    sortManager.validate("interact");

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

        if (convo3activated  && !truckingCompletionConversationActivated && activeScreen == "truck" && lastMorseCommand == "-.")
        {
            Debug.Log("Made it into TruckingCompletionConversation");
            DialogueController.GetComponent<DialogueController>().startTruckingCompletionConversation = true;
            truckingCompletionConversationActivated = true;
        }

        if(truckingCompletionConversationActivated && !entryIntroConversationStarted && activeScreen == "entry")
        {
            DialogueController.GetComponent<DialogueController>().startEntryIntroConversation = true;
            entryIntroConversationStarted = true;
        }

        if(entryIntroConversationStarted && !entryErrorConversationActivated && activeScreen == "entry" && lastMorseCommand == "..")
        {
            DialogueController.GetComponent<DialogueController>().startEntryErrorConversation = true;
            entryErrorConversationActivated = true;
        }

        if(entryErrorConversationActivated && !entryCompletionConversationActivated && activeScreen == "entry" && lastMorseCommand == ".-")
        {
            Debug.Log("Entering the area that starts the Entry Completion Conversation");
            DialogueController.GetComponent<DialogueController>().startEntryCompletionConversation = true;
            entryCompletionConversationActivated = true;
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
