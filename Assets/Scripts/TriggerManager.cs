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
	public convoStatus Ch2IntroConversation;
	public convoStatus Ch2TruckSecurityConversation;



	// Chapter 3 Triggers



	// General Triggers
	public int convosHad;
	public int tasksCompleted;
	public int truckTasksCompleted;
	public int scannerTasksCompleted;
	public int sortingTasksCompleted;

	public bool trucksVisited; //This is successfully changed through InputManager now
	public bool entryVisited; //This is successfully changed through InputManager now
	public bool sortingVisited; //This is successfully changed through InputManager now

	public string activeScreen; //This is successfully changed through InputManager now
	public string sceneName;    //This will be successfully changed on each startup


    // Start is called before the first frame update
    void Start()
    {
        Ch1IntroConversation = convoStatus.Ready;
        Ch2IntroConversation = convoStatus.Ready;

		// Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();
 
		// Retrieve the name of this scene.
		sceneName = currentScene.name;
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
    }

	void ChapterOneTriggerController()
	{

	}

	void ChapterTwoTriggerController()
	{
		if(Ch2IntroConversation == convoStatus.Complete &&
		   activeScreen == "truck")
		{
			Ch2TruckSecurityConversation = convoStatus.Ready;
		}
	}

	void ChapterThreeTriggerController()
	{

	}
}
