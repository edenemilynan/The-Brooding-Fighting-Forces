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
	public convoStatus Ch2IntroConversation;          //CH2 C1
	public convoStatus Ch2TruckSecurityConversation;  //CH2 C2
    public convoStatus Ch2TruckAlarmDecisionConversation; //CH2 C3 - Negative/Affirmative
    public bool        Ch2TruckAlarmDecision; //Whether the player selected affirmative/negative
    public convoStatus Ch2EntryPeskyScannerConversation; //CH2 C4
    public convoStatus Ch2EntryAlarmDecisionConversation; //CH2 C5 - Negative/Affirmative
    public bool        Ch2EntryAlarmDecision; // Affirmative/negative for CH2 C5 choice
    //CH2 C6
    //CH2 C7
    //CH2 C8
    //CH2 C9
    //CH2 C10
    //CH2 C11
    //CH2 C12
    //CH2 C13
    //CH2 C14


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
