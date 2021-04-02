﻿using System.Collections;
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



	// Chapter 3 Triggers



	// General Triggers
	public int convosHad;
	public int tasksCompleted;
	public int truckTasksCompleted;
	public int scannerTasksCompleted;
	public int sortingTasksCompleted;

	public bool trucksVisited;
	public bool entryVisited;
	public bool sortingVisited;

	public string activeScreen;
	public string sceneName;


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
        
    }
}
