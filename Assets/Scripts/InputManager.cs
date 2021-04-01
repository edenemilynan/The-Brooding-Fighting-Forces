using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string morseCommand;
    public string lastMorseCommand;

    public TransitionController transitionController;
    public CameraController cameraController;

    public GameObject morseInput;

    public GameObject DialogueController;

    //Accesses values that are incremented when a truck/person is 
    //ready to move
    public GameObject TruckingController;
    public GameObject PeopleController;

    //To control entry/trucking area animations
    public EntryControls entryControl;
    public TruckingControls truckingControl;

    //Accessses task queues to control game flow
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
    public bool taskWaitingTrucking = false;
    public bool taskWaitingEntry = false;
    public bool taskWaitingSorting = false;

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

    //Variables to control wait time before dequeuing new task 
    private int timerEntry = 0;
    private int timerTrucking = 0;
    private int timerSorting = 0;
    private int waitTime = 3000;
    private bool truckReset = false;
    private bool entryReset = false;

    //For notifications to keep track of what screen we are on
    public string activeScreen = "main";

    // Update is called once per frame
    void Update()
    {
        morseCommand = "";
        SpaceBarInput mi = morseInput.GetComponent<SpaceBarInput>();
        morseCommand = mi.morseReturn;

        //Switching nofitication icon
        notifManager.DisplayNotif(activeScreen);

        //The newer, beautifuler complications of managing
        //dequeing tasks from two different queues based on a time reset
        if (timerEntry > 0)
        {
            timerEntry -= 1;
        }

        if (timerTrucking > 0)
        {
            timerTrucking -= 1;
        }

        if (timerSorting > 0)
        {
            timerSorting -= 1;
        }

        if (taskWaitingEntry == true && taskManager.tasksEntry.Count != 0)
        {

            if (entryLeftOpen == false && entryRightOpen == false)
            {
                if (timerEntry == 0 || taskManager.tasksEntry.Peek() == TaskManager.Tasks.none || (taskManager.taskTrucking == TaskManager.Tasks.none && taskManager.taskSorting == TaskManager.Tasks.none))
                {
                    taskManager.getTaskEntry();
                    entryReset = false;
                }
                //oldScan = false;
                //entryDoor.ResetTrigger("scanner");
            }

        }

        if (taskWaitingTrucking == true && taskManager.tasksTrucking.Count != 0) 
        {
            if (timerTrucking == 0 || taskManager.tasksTrucking.Peek() == TaskManager.Tasks.none || (taskManager.taskEntry == TaskManager.Tasks.none && taskManager.taskSorting == TaskManager.Tasks.none))
            {
                if (truckingLeftOpen == false && truckingRightOpen == false)
                {
                    if (taskManager.tasksTrucking.Peek() == TaskManager.Tasks.truckLeft)
                    {

                        if (rampDown == -1)
                        {
                            taskManager.getTaskTrucking();
                            truckReset = false;
                            //oldScan = false;
                        }
                    }
                    else
                    {
                        taskManager.getTaskTrucking();
                        truckReset = false;
                    }
                }
            }
        }

        if (taskWaitingSorting == true && taskManager.tasksSorting.Count != 0)
        {
            if (timerSorting == 0 || taskManager.tasksSorting.Peek() == TaskManager.Tasks.none || (taskManager.taskTrucking == TaskManager.Tasks.none && taskManager.taskEntry == TaskManager.Tasks.none))
            {
                taskManager.getTaskSorting();
                Debug.Log("Input sorting task");
            }
        }


        // Debug.Log(taskManager.tasks.Count);
        // Debug.Log(taskManager.task);

        // if(taskManager.tasks.Count == 0 && taskManager.task != TaskManager.Tasks.none)
        // {
        //     taskManager.GetTask();
        // }

        if (taskManager.taskTrucking == TaskManager.Tasks.none && taskManager.taskEntry == TaskManager.Tasks.none && taskManager.taskSorting == TaskManager.Tasks.none && !convo4activated)
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
                
                
                if (activeScreen == "truck")
                {
                    whichTruckingDoor = (whichTruckingDoor * (-1));
                    truckingControl.switchHighlight();
                }

                else
                {
                    transitionController.staticTrucking();
                    activeScreen = "truck";
                    cameraController.truckingCamera();
                    trucksVisited = true;
                }

                

                //Commented out for testing/narrative needs rework
                //DialogueController.GetComponent<DialogueController>().secondConversation = false;
            }

            //Entry
            if (morseCommand == ".")
            {

                if (activeScreen == "entry")
                {
                    whichEntryDoor = (whichEntryDoor * (-1));
                    entryControl.switchHighlight();
                }
                else
                {
                    transitionController.staticEntry();
                    activeScreen = "entry";
                    cameraController.entryCamera();
                    entryVisited = true;
                }

            }

            //Sorting
            if (morseCommand == "...")
            {

                if (activeScreen == "sorting")
                {

                }
                else
                {
                    transitionController.staticSorting();
                    activeScreen = "sorting";
                    cameraController.sortingCamera();
                }
                sortManager.checkIfComplete();

            }

            //Main
            if (morseCommand == "--")
            {
                //Need an if statement so it doesn't play again when on screen
                if (activeScreen != "main")
                {
                    transitionController.staticMain();
                    activeScreen = "main";
                    cameraController.mainCamera();
                }
                else
                {

                }

            }

            //Negative
            if (morseCommand == "-.")
            {
                //Entry Command
                if (activeScreen == "entry")
                {
                    //Old entry
                    //entryDoor.SetBool("entryIsOpen", false);

                    if (whichEntryDoor == 1)
                    {
                        entryRightOpen = false;
                        entryControl.EntryRightClose();
                        if (taskWaitingEntry == true && entryReset == false && entryLeftOpen == false)
                        {
                            timerEntry = waitTime;
                            entryReset = true;
                        }
                    }

                    else
                    {
                        entryLeftOpen = false;
                        entryControl.EntryLeftClose();
                        if (taskWaitingEntry == true && entryReset == false && entryRightOpen == false)
                        {
                            timerEntry = waitTime;
                            entryReset = true;
                        }
                    }
                }

                //Trucking Command
                else if (activeScreen == "truck")
                {
                    if (whichTruckingDoor == 1)
                    {
                        truckingRightOpen = false;
                        truckingControl.truckRightClose();
                        if (taskWaitingTrucking == true && truckReset == false && truckingLeftOpen == false)
                        {
                            timerTrucking = waitTime;
                            truckReset = true;
                        }
                    }

                    else
                    {
                        if (rampDown == 1)
                        {
                            truckingLeftOpen = false;
                            truckingControl.truckLeftClose();
                            if (taskWaitingTrucking == true && truckReset == false && truckingRightOpen == false)
                            {
                                timerTrucking = waitTime;
                                truckReset = true;
                            }
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
                else if (activeScreen == "sorting" && taskManager.taskSorting != TaskManager.Tasks.none && taskWaitingSorting == false)
                {
                    sortManager.validate("negative");
                    bool complete = sortManager.checkIfComplete();
                    if (complete)
                    {
                        taskWaitingSorting = true;
                        timerSorting = waitTime;
                    }
                }
            }

            //Affirm
            if (morseCommand == ".-")
            {
                //Entry Command
                if (activeScreen == "entry")
                {
                    //If no one's waiting at the door, you can open it.
                    if (taskManager.taskEntry != TaskManager.Tasks.peopleAllow && taskManager.taskEntry != TaskManager.Tasks.peopleDisallow)
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

                            if (taskManager.taskEntry == TaskManager.Tasks.peopleAllow)
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

                            if (taskManager.taskEntry == TaskManager.Tasks.peopleDisallow)
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
                        taskWaitingEntry = true;
                        timerEntry = waitTime;
                        scanned = false;
                        scannable = false;
                    } 
                }

                //Trucking Command
                else if (activeScreen == "truck")
                {

                    if (whichTruckingDoor == 1)
                    {
                        truckingRightOpen = true;
                        truckingControl.truckRightOpen();

                        if (taskManager.taskTrucking == TaskManager.Tasks.truckRight && taskWaitingTrucking != true)
                        {
                            //Set the truck moving
                            TruckingController.GetComponent<TruckingController>().path += 1;
                            truckingControl.rightIndicatorOff();
                            taskWaitingTrucking = true;
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
                            if (taskManager.taskTrucking == TaskManager.Tasks.truckLeft && taskWaitingTrucking != true)
                            {
                                //Start the truck moving
                                TruckingController.GetComponent<TruckingController>().path += 1;
                                truckingControl.leftIndicatorOff();
                                taskWaitingTrucking = true;
                            }
                        }
                    }
                        
                    if(!convo3activated)
                    {
                        convo3activated = true;
                        DialogueController.GetComponent<DialogueController>().thirdConversation = false;
                    }
                }

                //Sorting Command
                else if (activeScreen == "sorting" && taskManager.taskSorting != TaskManager.Tasks.none && taskWaitingSorting == false)
                {
                    sortManager.validate("affirm");
                    bool complete = sortManager.checkIfComplete();
                    if (complete)
                    {
                        taskWaitingSorting = true;
                        timerSorting = waitTime;
                    }
                }
            }

            //Interact
            if (morseCommand == "..")
            {
                //Trucking Command
                if (activeScreen == "truck")
                {
                    if (truckingLeftOpen == false)
                    {
                        truckingControl.rampActivate();
                        rampDown = (rampDown * (-1));
                    }
                }

                //Entry Command
                if (activeScreen == "entry")
                {
                    entryControl.scanOn();

                    if (taskManager.taskEntry == TaskManager.Tasks.peopleAllow && scannable == true) // && oldScan == false
                    {
                        scanned = true;
                        //oldScan = true;
                        entryControl.Allow();
                    }
                    else if (taskManager.taskEntry == TaskManager.Tasks.peopleDisallow && scannable == true)
                    {
                        scanned = true;
                        //oldScan = true;
                        entryControl.Disallow();
                    }
                }

                //Sorting Command
                else if (activeScreen == "sorting")
                {
                    if(taskWaitingSorting == false && taskManager.taskSorting == TaskManager.Tasks.sort)
                    {
                        sortManager.validate("interact");
                        //sortManager.checkIfComplete()

                    }
                  
                }
            }
            
            else 
            {
                // Invalid Input
                Debug.Log("Invalid Input");
            }
            
            //After completing the sorting task, leaving the screen resets it for the next sorting task
            if(activeScreen != "sorting" && sortManager.checkIfComplete() == true)
            {
                sortManager.hardReset();
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
            taskManager.getTaskEntry();
            taskManager.getTaskSorting();
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
