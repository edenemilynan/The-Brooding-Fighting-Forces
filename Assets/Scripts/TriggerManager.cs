using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerManager : MonoBehaviour
{

	public enum convoStatus {NotReady, Ready, Complete};
    public bool dialogueActive = false;

	//Chapter 1 Triggers
	public convoStatus Ch1IntroConversation;
	public convoStatus Ch1SecondConversation;
	public convoStatus Ch1TruckingCompletionConversation;
	public convoStatus Ch1ThirdConversation;
	public convoStatus Ch1EntryIntroConversation;
	public convoStatus Ch1EntryErrorConversation;
	public convoStatus Ch1EntryCompletionConversation;
	public convoStatus Ch1FourthConversation;
	public convoStatus Ch1FifthConversation;
	
	// Chapter 2 Triggers
	public convoStatus Ch2IntroConversation = convoStatus.NotReady;          //CH2 C1
	public convoStatus Ch2TruckSecurityConversation = convoStatus.NotReady;  //CH2 C2
    public convoStatus Ch2TruckAlarmDecisionConversation = convoStatus.NotReady; //CH2 C3 - Negative/Affirmative
    public bool        Ch2TruckAlarmDecision; //Whether the player selected affirmative/negative
    public convoStatus Ch2EntryPeskyScannerConversation = convoStatus.NotReady; //CH2 C4
    public convoStatus Ch2EntryAlarmDecisionConversation = convoStatus.NotReady; //CH2 C5 - Negative/Affirmative
    public bool        Ch2EntryAlarmDecision; // Affirmative/negative for CH2 C5 choice
    public convoStatus Ch2InjuryReportConversation = convoStatus.NotReady; //CH2 C6
    public int         Ch2NotCountingStartNumber;
    public convoStatus Ch2NotCountingConversation1 = convoStatus.NotReady; //CH2 C7
    public convoStatus Ch2NotCountingConversation2 = convoStatus.NotReady; //CH2 C8
    public convoStatus Ch2NotCountingConversation3 = convoStatus.NotReady; //CH2 C9
    public convoStatus Ch2MediocreEvaluationConversation = convoStatus.NotReady; //CH2 C10
    public convoStatus Ch2PackagedFunFactConversation = convoStatus.NotReady; //CH2 C11
    public convoStatus Ch2AllowPackagesDecisionConversation = convoStatus.NotReady; //CH2 C12
    public bool        Ch2WaitingForAllowPackagesDecision;
    public bool        Ch2AllowPackagesDecision; // Affirmative/negative for CH2 C12 Choice
    public convoStatus Ch2HeadOfficeMemoConversation = convoStatus.NotReady; //CH2 C13
    public bool        Ch2DisplayErrorMessageScreen = false;
    public convoStatus Ch2ConfirmCleanSystemConversation = convoStatus.NotReady; //CH2 C14
    public bool        Ch2ConfirmCleanSystem; // Affirmative/Negative for CH2 C14


	// Chapter 3 Triggers
    public convoStatus D1IVAALConversation  = convoStatus.NotReady;
    public convoStatus D2VirusConversation  = convoStatus.NotReady;
    public convoStatus D3IVAALConversation  = convoStatus.NotReady;
    public convoStatus D4IVAALConversation  = convoStatus.NotReady;
    public convoStatus D5IVAALConversation  = convoStatus.NotReady;
    public convoStatus D6VirusConversation  = convoStatus.NotReady;
    public convoStatus D7IVAALConversation  = convoStatus.NotReady;
    public convoStatus D8IVAALConversation  = convoStatus.NotReady;
    public convoStatus D9VirusConversation  = convoStatus.NotReady;
    public convoStatus D10IVAALConversation = convoStatus.NotReady;
    public convoStatus D11VirusConversation = convoStatus.NotReady;
    public convoStatus D12IVAALConversation = convoStatus.NotReady;
    public convoStatus D13IVAALConversation = convoStatus.NotReady;
    public convoStatus D14IVAALConversation = convoStatus.NotReady;
    public convoStatus D15VirusConversation = convoStatus.NotReady;
    public convoStatus D16IVAALConversation = convoStatus.NotReady;
    public convoStatus D17VirusConversation = convoStatus.NotReady;
    public convoStatus D18IVAALConversation = convoStatus.NotReady;
    public convoStatus D19IVAALConversation = convoStatus.NotReady;
    public convoStatus D20IVAALConversation = convoStatus.NotReady;
    public convoStatus D21VirusConversation = convoStatus.NotReady;
    public convoStatus D22IVAALConversation = convoStatus.NotReady;
    public convoStatus D23VirusConversation = convoStatus.NotReady;
    public convoStatus D24IVAALConversation = convoStatus.NotReady;
    public convoStatus D25VirusConversation = convoStatus.NotReady;
    public convoStatus D26IVAALConversation = convoStatus.NotReady;
    public convoStatus D27BexosConversation = convoStatus.NotReady;
    public bool        exposeIVAAL = false;
    public convoStatus D28BexosConversation = convoStatus.NotReady;
    public convoStatus D29BexosConversation = convoStatus.NotReady;
    public convoStatus D30VirusConversation = convoStatus.NotReady;
    public convoStatus D31IVAALConversation = convoStatus.NotReady;
    public convoStatus D32VirusConversation = convoStatus.NotReady;
    public convoStatus D33IVAALConversation = convoStatus.NotReady;
    public convoStatus D34VirusConversation = convoStatus.NotReady;
    public convoStatus D35IVAALConversation = convoStatus.NotReady;
    public convoStatus D36IVAALConversation = convoStatus.NotReady;
    public convoStatus D37IVAALConversation = convoStatus.NotReady;
    public convoStatus D38IVAALConversation = convoStatus.NotReady;
    public convoStatus D39IVAALConversation = convoStatus.NotReady;
    public convoStatus D40IVAALConversation = convoStatus.NotReady;
    public convoStatus D41IVAALConversation = convoStatus.NotReady;
    public convoStatus D42IVAALConversation = convoStatus.NotReady;
    public convoStatus D43VirusConversation = convoStatus.NotReady;
    public convoStatus D44IVAALConversation = convoStatus.NotReady;
    public convoStatus D45IVAALConversation = convoStatus.NotReady;
    public convoStatus D46VirusConversation = convoStatus.NotReady;
    public convoStatus D47IVAALConversation = convoStatus.NotReady;
    public convoStatus D48IVAALConversation = convoStatus.NotReady;
    public convoStatus D49VirusConversation = convoStatus.NotReady;
    public convoStatus D50IVAALConversation = convoStatus.NotReady;
    public convoStatus D51IVAALConversation = convoStatus.NotReady;
    public convoStatus D52BexosConversation = convoStatus.NotReady;
    public convoStatus D53VirusConversation = convoStatus.NotReady;
    public convoStatus D54BexosConversation = convoStatus.NotReady;
    public convoStatus D55VirusConversation = convoStatus.NotReady;
    public convoStatus D56IVAALConversation = convoStatus.NotReady;
    public convoStatus D57BexosConversation = convoStatus.NotReady;
    public convoStatus D58UnknownConversation = convoStatus.NotReady;

    public float decisionTimer = 0;


    // Animation Triggers
    public bool phoneRinging;
    public bool onPhone;
    public bool fallenAnimationActive;
    public bool virusOnScreen;
    public bool terminatedAnimationActive;
    public bool camerasFritzing;
    public bool explosion;
    public bool virusDeath;
    public DesktopControls desktopControls;


	// General Triggers
	public int convosHad = 0;
	public int tasksCompleted = 0;
	public int truckTasksCompleted = 0;
	public int scannerTasksCompleted = 0;
	public int sortingTasksCompleted = 0;

	public bool trucksVisited; //This is successfully changed through InputManager now
	public bool entryVisited; //This is successfully changed through InputManager now
	public bool sortingVisited; //This is successfully changed through InputManager now

	public string activeScreen; //This is successfully changed through InputManager now
	public string sceneName;    //This will be successfully changed on each startup

    public int    obeyedIVAALCount; //How many times the player sided with IVAALS suggestion
    public int    ignoredIVAALCount;//How many times the player ignored IVAAL's suggestion

    //Variables used for within the TriggerManager to determine certain things
    public int entryTaskTimer = 0;
    private int entryTaskTimerValue = 120;

    // Variable used to determine what happens in the conversations where a decision must be made
    public string lastMorseCommand;
    public bool   waitingOnInput;
    public bool   endScene;
    public int    endingCode = 0;
    public int    performedFinalScanResultingTaskCount;

    public TaskManager taskManager;
    public InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        Ch1IntroConversation = convoStatus.Ready;
        Ch2IntroConversation = convoStatus.Ready;
        D1IVAALConversation = convoStatus.Ready;

		// Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();
 
		// Retrieve the name of this scene.
		sceneName = currentScene.name;

        entryTaskTimer = 120;



    }

    // Update is called once per frame
    void Update()
    {


        if (sceneName == "Chapter 1")
		{
			ChapterOneTriggerController();
		}
		else if (sceneName == "Chapter 2")
		{
			ChapterTwoTriggerController();
		}
		else if (sceneName == "Chapter 3")
		{
			ChapterThreeTriggerController();
		}

        if(entryTaskTimer > 0) {entryTaskTimer--;} //Decrementing the timer.
        if(decisionTimer != 0) 
        {
            decisionTimer = Mathf.Max(0, decisionTimer - Time.deltaTime);
        }


    }

	void ChapterOneTriggerController()
	{

	}

	void ChapterTwoTriggerController()
	{
		if(Ch2IntroConversation == convoStatus.Complete &&
		   Ch2TruckSecurityConversation != convoStatus.Complete &&
		   activeScreen == "truck")
		{
			Ch2TruckSecurityConversation = convoStatus.Ready;
            waitingOnInput = true;
		}

        if(Ch2TruckSecurityConversation == convoStatus.Complete &&
           Ch2TruckAlarmDecisionConversation != convoStatus.Complete &&
           activeScreen == "truck" &&
           (lastMorseCommand == ".-" || lastMorseCommand == "-."))
        {   
            Ch2TruckAlarmDecisionConversation = convoStatus.Ready;
            waitingOnInput = false;
            if(lastMorseCommand == ".-")      { Ch2TruckAlarmDecision = true; }
            else if(lastMorseCommand == "-.") { Ch2TruckAlarmDecision = false; }
            if(Ch2TruckAlarmDecision == false)
            {
                //TK Destroy the truck object and turn the light off
            }
            taskManager.queueNewTasks(taskManager.Ch2Queue2);
        }

        if(Ch2TruckAlarmDecisionConversation == convoStatus.Complete &&
           Ch2EntryPeskyScannerConversation != convoStatus.Complete &&
           activeScreen == "entry" &&
           lastMorseCommand == "..")
        {
            Ch2EntryPeskyScannerConversation = convoStatus.Ready;
        }

        if(Ch2EntryPeskyScannerConversation == convoStatus.Complete &&
           Ch2EntryAlarmDecisionConversation != convoStatus.Complete &&
           activeScreen == "entry" &&
           lastMorseCommand == ".-")
        {
            Ch2EntryAlarmDecisionConversation = convoStatus.Ready;
            if(inputManager.whichEntryDoor == -1) { Ch2EntryAlarmDecision = false; }
            else { Ch2EntryAlarmDecision = true; }

            taskManager.queueNewTasks(taskManager.Ch2Queue3);

        }

        if(Ch2EntryAlarmDecisionConversation == convoStatus.Complete &&
           Ch2InjuryReportConversation != convoStatus.Complete &&
           truckTasksCompleted >= 4 &&
           scannerTasksCompleted >= 3 &&
           sortingTasksCompleted >= 1)
        {
            Ch2InjuryReportConversation = convoStatus.Ready;
            Ch2NotCountingStartNumber = scannerTasksCompleted;
            taskManager.queueNewTasks(taskManager.Ch2Queue4);
        }

        if(Ch2InjuryReportConversation == convoStatus.Complete &&
           Ch2NotCountingConversation1 != convoStatus.Complete &&
           scannerTasksCompleted >= Ch2NotCountingStartNumber + 1)
        {
            Ch2NotCountingConversation1 = convoStatus.Ready;
        }

        if(Ch2NotCountingConversation1 == convoStatus.Complete &&
           Ch2NotCountingConversation2 != convoStatus.Complete &&
           scannerTasksCompleted >= Ch2NotCountingStartNumber + 2)
        {
            Ch2NotCountingConversation2 = convoStatus.Ready;
        }

        if(Ch2NotCountingConversation2 == convoStatus.Complete &&
           Ch2NotCountingConversation3 != convoStatus.Complete &&
           scannerTasksCompleted >= Ch2NotCountingStartNumber + 3)
        {
            Ch2NotCountingConversation3 = convoStatus.Ready;
        }

        if(Ch2NotCountingConversation3 == convoStatus.Complete &&
           Ch2MediocreEvaluationConversation != convoStatus.Complete)
        {
            Ch2MediocreEvaluationConversation = convoStatus.Ready;
            taskManager.queueNewTasks(taskManager.Ch2Queue5);

        }

        if(Ch2MediocreEvaluationConversation == convoStatus.Complete &&
           Ch2PackagedFunFactConversation != convoStatus.Complete &&
           activeScreen == "sorting")
        {
            Ch2PackagedFunFactConversation = convoStatus.Ready;
            // taskManager.queueNewTasks(taskManager.Ch2Queue6);

        }

        if(Ch2PackagedFunFactConversation == convoStatus.Complete &&
           Ch2AllowPackagesDecisionConversation != convoStatus.Complete
           // &&
           //TKNEEDTOADDCHECKFORLETTINGINCORRECTIN)
           )
        {
            Ch2AllowPackagesDecisionConversation = convoStatus.Ready;
            Ch2AllowPackagesDecision = true;
            // if(inputManager.whichEntryDoor == -1) { Ch2EntryAlarmDecision = false; }
            // else( Ch2EntryAlarmDecision = true; )
            taskManager.queueNewTasks(taskManager.Ch2Queue7);

        }

        if(Ch2AllowPackagesDecisionConversation == convoStatus.Complete &&
           Ch2HeadOfficeMemoConversation != convoStatus.Complete &&
           truckTasksCompleted == 5 &&
           scannerTasksCompleted == 7 &&
           sortingTasksCompleted == 3
           )
        {
            Ch2HeadOfficeMemoConversation = convoStatus.Ready;
            waitingOnInput = true;
            Ch2DisplayErrorMessageScreen = true;
        }

        if(Ch2HeadOfficeMemoConversation == convoStatus.Complete &&
           Ch2ConfirmCleanSystemConversation != convoStatus.Complete &&
           (lastMorseCommand == ".-" || lastMorseCommand == "-.") )
        {
            Ch2DisplayErrorMessageScreen = false;
            Ch2ConfirmCleanSystemConversation = convoStatus.Ready;
            waitingOnInput = false;
            if(lastMorseCommand == "-.") {Ch2ConfirmCleanSystem = true;}
            else if (lastMorseCommand == ".-") {Ch2ConfirmCleanSystem = false;}
        }

	}

	void ChapterThreeTriggerController()
	{
        if(dialogueActive != true)
        {
            ChapterThreeDialogueTriggers();
        }

        // public bool phoneRinging;
        // public bool onPhone;
        // public bool fallenAnimationActive;
        // public bool virusOnScreen;
        // public bool terminatedAnimationActive;
        // public bool camerasFritzing;
        // public bool explosion;
        // public bool virusDeath;

        Debug.Log("I AM LOOKING AROUND IN HERE");

        if(phoneRinging){ desktopControls.bexosCalling(); }
        if(!phoneRinging){ desktopControls.hideBexosCall(); }

        if(onPhone)  { desktopControls.areOnThePhone(); }
        if(!onPhone) { desktopControls.hideOnThePhone(); }

        if(explosion)  { desktopControls.triggerExplosion(); }
        if(!explosion) { desktopControls.hideExplosion(); }

        if(camerasFritzing)  { desktopControls.triggerStatic(); }
        if(!camerasFritzing) { desktopControls.hideStatic(); }

        if(virusOnScreen)  { desktopControls.showVirusOnScreen(); }
        if(!virusOnScreen) { desktopControls.hideVirusOnScreen(); }

        if(virusDeath)  { desktopControls.triggerVirusDeath(); }
        if(!virusDeath) { desktopControls.hideVirusDeath(); }


	}

    void ChapterThreeDialogueTriggers()
    {
        // bool activatedTerminationAnimation;
        // TK Make sure entry tasks are Queued in TaskManager
        

        if(D1IVAALConversation == convoStatus.Complete &&
           D2VirusConversation != convoStatus.Complete
        )
        {
            D2VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D2VirusConversation == convoStatus.Complete &&
           D3IVAALConversation != convoStatus.Complete
        )
        {
            D3IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        // TK GOTO ENTRYWAY
        if(D3IVAALConversation == convoStatus.Complete &&
           D4IVAALConversation  != convoStatus.Complete &&
           activeScreen == "entry"
        )
        {
			taskManager.queueNewTasks(taskManager.Ch3Queue1);
            D4IVAALConversation = convoStatus.Ready;
        }

        // TK Set the number of scanner tasks based on Queue in TaskManager
        if(D4IVAALConversation == convoStatus.Complete &&
           D5IVAALConversation  != convoStatus.Complete &&
           activeScreen == "entry" &&
           scannerTasksCompleted == 1 //tk this is the place
        )
        {
            D5IVAALConversation = convoStatus.Ready;
            fallenAnimationActive = true;
        }

        if(D5IVAALConversation == convoStatus.Complete &&
           D6VirusConversation  != convoStatus.Complete
        )
        {
            D6VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
            fallenAnimationActive = false;
        }

        // TK Queue a sorting task
        if(D6VirusConversation == convoStatus.Complete &&
           D7IVAALConversation  != convoStatus.Complete
        )
        {
            D7IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
            taskManager.queueNewTasks(taskManager.Ch3Queue3);
        }

        if(D7IVAALConversation == convoStatus.Complete &&
           D8IVAALConversation  != convoStatus.Complete &&
           activeScreen == "sorting" &&
           sortingTasksCompleted == 1 //TK Change this later to proper value
        )
        {
            D8IVAALConversation = convoStatus.Ready;
            taskManager.queueNewTasks(taskManager.Ch3Queue4);
        }

        if(D8IVAALConversation == convoStatus.Complete &&
           D9VirusConversation  != convoStatus.Complete &&
           activeScreen == "sorting"
        )
        {
            D9VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D9VirusConversation == convoStatus.Complete &&
           D10IVAALConversation != convoStatus.Complete)
        {
            virusOnScreen = false;
        }

        if(D9VirusConversation == convoStatus.Complete &&
           D10IVAALConversation != convoStatus.Complete &&
           activeScreen == "sorting" &&
           sortingTasksCompleted == 1 //TK Change this later to the proper value
        )
        {
            //TK DisAllow dialogue from leaving
            taskManager.queueNewTasks(taskManager.Ch3Queue5);
            D10IVAALConversation = convoStatus.Ready;
        }

        if(D10IVAALConversation == convoStatus.Complete &&
           D11VirusConversation != convoStatus.Complete
        )
        {
            //TK DisAllow dialogue from leaving
            D11VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D11VirusConversation == convoStatus.Complete &&
           D12IVAALConversation != convoStatus.Complete
        )
        {
            D12IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
            //TK Allow dialogue box to leave
        }

        // TK Make sure these triggers are correct, friend
        if(D12IVAALConversation == convoStatus.Complete &&
           D13IVAALConversation != convoStatus.Complete &&
           activeScreen == "truck" &&
           truckTasksCompleted == 1 //TK Change this value to be the proper one based on number of tasks
        )
        {
            //TK Queue another task (the door opening task)
            D13IVAALConversation = convoStatus.Ready;
        }

        if(D13IVAALConversation == convoStatus.Complete &&
           D14IVAALConversation != convoStatus.Complete &&
           activeScreen == "truck" // TK Add logic for determining if the truck has been correctly let in.
        )
        {
            D14IVAALConversation = convoStatus.Ready;
            //TK Dont allow dialogue box to leave
        }

        if(D14IVAALConversation == convoStatus.Complete &&
           D15VirusConversation != convoStatus.Complete
        )
        {
            D15VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
            //TK Dont allow dialogue box to leave

        }

        if(D15VirusConversation == convoStatus.Complete &&
           D16IVAALConversation != convoStatus.Complete
        )
        {
            D16IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
            //TK Allow Dialogue Box to Leave
            taskManager.queueNewTasks(taskManager.Ch3Queue6);
        }

        if(D16IVAALConversation == convoStatus.Complete &&
           D17VirusConversation != convoStatus.Complete 
           // TK Add checks for being done the proper amount of tasks
        )
        {
            D17VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
            //TK Dont allow dialogue box to leave
        }

        if(D17VirusConversation == convoStatus.Complete &&
           D18IVAALConversation != convoStatus.Complete
        )
        {
            D18IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
            //TK Allow Dialogue Box to Leave
            taskManager.queueNewTasks(taskManager.Ch3Queue7);
        }

        if(D18IVAALConversation == convoStatus.Complete &&
           D19IVAALConversation != convoStatus.Complete 
           // TK add check for completing the correct amount of sorting tasks
        )
        {
            taskManager.queueNewTasks(taskManager.Ch3Queue8);
            D19IVAALConversation = convoStatus.Ready;
        }

        if(D19IVAALConversation == convoStatus.Complete &&
           D20IVAALConversation != convoStatus.Complete
           // TK Check for completing correct amount of entry tasks
        )
        {
            taskManager.queueNewTasks(taskManager.Ch3Queue9);
            D20IVAALConversation = convoStatus.Ready;
        }

        if(D20IVAALConversation == convoStatus.Complete &&
           D21VirusConversation != convoStatus.Complete
           // TK Add check for completing the correct amount of trucking tasks
        )
        {
            //TK Dont allow dialogue box to leave
            D21VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D21VirusConversation == convoStatus.Complete &&
           D22IVAALConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            D22IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        if(D22IVAALConversation == convoStatus.Complete &&
           D23VirusConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            D23VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D23VirusConversation == convoStatus.Complete &&
           D24IVAALConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            D24IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        if(D24IVAALConversation == convoStatus.Complete &&
           D25VirusConversation != convoStatus.Complete
        )
        {
            // TK QUEUE A main task notification
			TK taskManager.queueNewTasks(taskManager.Ch3Queue10);
            //TK allow dialogue box to leave
            D25VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D25VirusConversation == convoStatus.Complete &&
           D26IVAALConversation != convoStatus.Complete)
        {
            virusOnScreen = false;
        }

        if(D25VirusConversation == convoStatus.Complete &&
           D26IVAALConversation != convoStatus.Complete &&
           activeScreen == "main"
        )
        {
            //TK Dont allow dialogue box to leave
            D26IVAALConversation = convoStatus.Ready;
            phoneRinging = true;
        }

        if(D26IVAALConversation == convoStatus.Complete &&
           D27BexosConversation != convoStatus.Complete
        )
        {
            //TK allow dialogue box to leave
            D27BexosConversation = convoStatus.Ready;
            phoneRinging = false;
            onPhone = true;
        }
        
        if(D27BexosConversation == convoStatus.Complete &&
           D28BexosConversation != convoStatus.Complete &&
           D29BexosConversation != convoStatus.Complete &&
           activeScreen == "main" && 
           (lastMorseCommand == ".-" || lastMorseCommand == "-.")
        )
        {
            if(lastMorseCommand == ".-")
            {
                D28BexosConversation = convoStatus.Ready;
                // endingCode = 1;
            }
            if(lastMorseCommand == "-.")
            {
                D29BexosConversation = convoStatus.Ready;
            }
        }

        if(D28BexosConversation == convoStatus.Complete)
        {
            terminatedAnimationActive = true;
        }

        if(D29BexosConversation == convoStatus.Complete &&
           D30VirusConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            D30VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D30VirusConversation == convoStatus.Complete &&
           D31IVAALConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            D31IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        if(D31IVAALConversation == convoStatus.Complete &&
           D32VirusConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            D32VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D32VirusConversation == convoStatus.Complete &&
           D33IVAALConversation != convoStatus.Complete
        )
        {
            //TK Dont allow dialogue box to leave
            taskManager.queueNewTasks(taskManager.Ch3Queue11);
            D33IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        if(D33IVAALConversation == convoStatus.Complete &&
           D34VirusConversation != convoStatus.Complete
        )
        {
            //TK allow dialogue box to leave
            D34VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D34VirusConversation == convoStatus.Complete &&
           D35IVAALConversation != convoStatus.Complete
        )
        {
            virusOnScreen = false;
        }

        if(D34VirusConversation == convoStatus.Complete &&
           D35IVAALConversation != convoStatus.Complete &&
           activeScreen == "truck"
        )
        {
            D35IVAALConversation = convoStatus.Ready;
            decisionTimer = 15;
            obeyedIVAALCount = 0;
            ignoredIVAALCount = 0;
        }

        // Opened the door
        if(D35IVAALConversation == convoStatus.Complete &&
           D36IVAALConversation != convoStatus.Complete &&
           activeScreen == "truck" && 
           lastMorseCommand == ".-" &&
           decisionTimer != 0
        )
        {
            taskManager.queueNewTasks(taskManager.Ch3Queue12);
            D36IVAALConversation = convoStatus.Ready;
            ignoredIVAALCount++;
        }

        // Do not open door
        if(D35IVAALConversation == convoStatus.Complete &&
           D37IVAALConversation != convoStatus.Complete &&
           decisionTimer == 0
        )
        {
            taskManager.queueNewTasks(taskManager.Ch3Queue12);
            D37IVAALConversation = convoStatus.Ready;
            obeyedIVAALCount++;
        }

        // Entry task decision
        if((D37IVAALConversation == convoStatus.Complete ||
            D36IVAALConversation == convoStatus.Complete) &&
           D38IVAALConversation != convoStatus.Complete &&
           activeScreen == "entry"
        )
        {
            D38IVAALConversation = convoStatus.Ready;
            decisionTimer = 15;
        }

        // Allow the person in (TK Right now it triggers for either direction)
        if(D38IVAALConversation == convoStatus.Complete &&
           D39IVAALConversation != convoStatus.Complete &&
           activeScreen == "entry" &&
           lastMorseCommand == ".-" &&
           decisionTimer != 0
        )
        {
            taskManager.queueNewTasks(taskManager.Ch3Queue13);
            D39IVAALConversation = convoStatus.Ready;
            ignoredIVAALCount++;
        }

        // Wait it out, not allowing them in
        if(D38IVAALConversation == convoStatus.Complete &&
           D40IVAALConversation != convoStatus.Complete &&
           decisionTimer == 0
        )
        {
            taskManager.queueNewTasks(taskManager.Ch3Queue13);
            D40IVAALConversation = convoStatus.Ready;
            obeyedIVAALCount++;
        }

        //Sorting decision
        if((D40IVAALConversation == convoStatus.Complete ||
            D39IVAALConversation == convoStatus.Complete) &&
           D41IVAALConversation != convoStatus.Complete &&
           activeScreen == "sorting"
        )
        {
            D41IVAALConversation = convoStatus.Ready;
            decisionTimer = 15;
            performedFinalScanResultingTaskCount = sortingTasksCompleted + 1;
        }

        //Scan them
        if(D41IVAALConversation == convoStatus.Complete &&
           D42IVAALConversation != convoStatus.Complete &&
           activeScreen == "sorting" &&
           sortingTasksCompleted == performedFinalScanResultingTaskCount &&
           decisionTimer != 0
        )
        {
            //TK Don't allow dialogue box to leave
            D42IVAALConversation = convoStatus.Ready;
            ignoredIVAALCount++;
        }

        //You didn't do it, so I have to!
        if(D42IVAALConversation == convoStatus.Complete &&
           D43VirusConversation != convoStatus.Complete
        )
        {
            D43VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        if(D43VirusConversation == convoStatus.Complete && virusOnScreen &&
           D44IVAALConversation != convoStatus.Complete)
        {
            virusOnScreen = false;
            explosion = true;
            decisionTimer = 5;
        }

        if(explosion && decisionTimer == 0 && 
           D44IVAALConversation != convoStatus.Complete)
        {
            decisionTimer = 5;
            camerasFritzing = true;
            explosion = false;
        }

        if(camerasFritzing && decisionTimer == 0 &&
           D44IVAALConversation != convoStatus.Complete)
        {
            D44IVAALConversation = convoStatus.Ready;
        }

        if(D43VirusConversation == convoStatus.Complete &&
           D44IVAALConversation != convoStatus.Complete
        )
        {
            D44IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        // TK Make sure these triggers are correct, friend
        if(D44IVAALConversation == convoStatus.Complete &&
           D45IVAALConversation != convoStatus.Complete
        )
        {
            D45IVAALConversation = convoStatus.Ready;
        }

        // TK Make sure these triggers are correct, friend
        if(D45IVAALConversation == convoStatus.Complete &&
           D46VirusConversation != convoStatus.Complete
        )
        {
            D46VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        // TK Make sure these triggers are correct, friend
        if(D46VirusConversation == convoStatus.Complete &&
           D47IVAALConversation != convoStatus.Complete
        )
        {
            D47IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        // TK Make sure these triggers are correct, friend
        if(D47IVAALConversation == convoStatus.Complete &&
           D48IVAALConversation != convoStatus.Complete
        )
        {
            D48IVAALConversation = convoStatus.Ready;
        }

        // TK Make sure these triggers are correct, friend
        if(D48IVAALConversation == convoStatus.Complete &&
           D49VirusConversation != convoStatus.Complete
        )
        {
            D49VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        // TK Make sure these triggers are correct, friend
        if(D49VirusConversation == convoStatus.Complete &&
           D50IVAALConversation != convoStatus.Complete
        )
        {
            D50IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        // TK Make sure these triggers are correct, friend
        if(D50IVAALConversation == convoStatus.Complete &&
           D51IVAALConversation != convoStatus.Complete
        )
        {
            D51IVAALConversation = convoStatus.Ready;
        }

        // TK Make sure these triggers are correct, friend
        if(D51IVAALConversation == convoStatus.Complete &&
           D52BexosConversation != convoStatus.Complete
        )
        {
            D52BexosConversation = convoStatus.Ready;
        }

        // TK Make sure these triggers are correct, friend
        if(D52BexosConversation == convoStatus.Complete &&
           D53VirusConversation != convoStatus.Complete
        )
        {
            D53VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        // TK Make sure these triggers are correct, friend
        if(D53VirusConversation == convoStatus.Complete &&
           D54BexosConversation != convoStatus.Complete
        )
        {
            D54BexosConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        // TK Make sure these triggers are correct, friend
        if(D54BexosConversation == convoStatus.Complete &&
           D55VirusConversation != convoStatus.Complete
        )
        {
            D55VirusConversation = convoStatus.Ready;
            virusOnScreen = true;
        }

        // TK Make sure these triggers are correct, friend
        if(D55VirusConversation == convoStatus.Complete &&
           D56IVAALConversation != convoStatus.Complete
        )
        {
            D56IVAALConversation = convoStatus.Ready;
            virusOnScreen = false;
        }

        // TK Make sure these triggers are correct, friend
        if(D56IVAALConversation == convoStatus.Complete &&
           D57BexosConversation != convoStatus.Complete
        )
        {
            D57BexosConversation = convoStatus.Ready;
        }

        // TK Make sure these triggers are correct, friend
        if(D57BexosConversation == convoStatus.Complete &&
           D58UnknownConversation != convoStatus.Complete
        )
        {
            D58UnknownConversation = convoStatus.Ready;
        }
     }

    public void resetEntryTaskTimer()
    {
        entryTaskTimer = entryTaskTimerValue;
    }
}

