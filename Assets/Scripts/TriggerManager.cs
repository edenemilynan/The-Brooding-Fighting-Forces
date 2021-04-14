using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerManager : MonoBehaviour
{

	public enum convoStatus {NotReady, Ready, Complete};

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
    public convoStatus Ch2ConfirmCleanSystemConversation = convoStatus.NotReady; //CH2 C14
    public bool        Ch2ConfirmCleanSystem; // Affirmative/Negative for CH2 C14


	// Chapter 3 Triggers



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

    public TaskManager taskManager;
    public InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        Ch1IntroConversation = convoStatus.Ready;
        Ch2IntroConversation = convoStatus.Ready;

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
           lastMorseCommand != "")
        {   
            Ch2TruckAlarmDecisionConversation = convoStatus.Ready;
            waitingOnInput = false;
            //TK CUE UP NEW ENTRY TASK
            if(lastMorseCommand == ".-")      { Ch2TruckAlarmDecision = true; }
            else if(lastMorseCommand == "-.") { Ch2TruckAlarmDecision = false; }
            else
            {
                Ch2TruckAlarmDecisionConversation = convoStatus.NotReady;
                waitingOnInput = true;
            }
        }

        if(Ch2TruckAlarmDecisionConversation == convoStatus.Complete &&
           Ch2EntryPeskyScannerConversation != convoStatus.Complete &&
           activeScreen == "entry" &&
           taskManager.taskSorting == TaskManager.Tasks.peopleDisallow &&
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
        }

        if(Ch2EntryAlarmDecisionConversation == convoStatus.Complete &&
           Ch2InjuryReportConversation != convoStatus.Complete &&
           truckTasksCompleted >= 2 &&
           scannerTasksCompleted >= 2 &&
           sortingTasksCompleted >= 1)
        {
            Ch2InjuryReportConversation = convoStatus.Ready;
            Ch2NotCountingStartNumber = scannerTasksCompleted;
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
        }

        if(Ch2MediocreEvaluationConversation == convoStatus.Complete &&
           Ch2PackagedFunFactConversation != convoStatus.Complete &&
           activeScreen == "sorting")
        {
            Ch2PackagedFunFactConversation = convoStatus.Ready;
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
        }

        if(Ch2AllowPackagesDecisionConversation == convoStatus.Complete &&
           Ch2HeadOfficeMemoConversation != convoStatus.Complete
           // TKFIGUREOUTHOWMANYOTHERTASKSNEEDTOBECOMPLETE)
           )
        {
            Ch2HeadOfficeMemoConversation = convoStatus.Ready;
            waitingOnInput = true;
            //TKADDINCHANGEMONITORVARIABLE
        }

        if(Ch2HeadOfficeMemoConversation == convoStatus.Complete &&
           Ch2ConfirmCleanSystemConversation != convoStatus.Complete &&
           lastMorseCommand != "")
        {
            
            Ch2ConfirmCleanSystemConversation = convoStatus.Ready;
            waitingOnInput = false;
            if(lastMorseCommand == "-.") {Ch2ConfirmCleanSystem = true;}
            else if (lastMorseCommand == ".-") {Ch2ConfirmCleanSystem = false;}
            else 
            {
                Ch2ConfirmCleanSystemConversation = convoStatus.NotReady;
                waitingOnInput = true;
            }
        }

	}

	void ChapterThreeTriggerController()
	{

	}

    public void resetEntryTaskTimer()
    {
        entryTaskTimer = entryTaskTimerValue;
    }
}
