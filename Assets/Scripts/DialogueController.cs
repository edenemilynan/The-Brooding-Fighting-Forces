using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public TaskManager taskManager;

    public int tasksCompleted = 0;
    public int convosHad = 0;
    public bool secondConversation = true;
    public bool thirdConversation  = true;
    public bool startTruckingCompletionConversation = false;
    public bool startEntryIntroConversation = false;
    public bool startEntryErrorConversation = false;
    public bool startEntryCompletionConversation = false;
    public bool fourthConversation = true;
    public bool readyForFourthConvo = false;
    public bool fifthConversation  = true;
	private string sceneName;
    public GameObject DialogueManager;
    public GameObject InputManager;
	
	//Making a centralized location for all triggers to reside.
	public TriggerManager triggerManager;


	// Chapter 2 Specific Dialogue Triggers

    // Start is called before the first frame update
    void Start()
    {
        //GameObject go = GameObject.Find("somegameobjectname");
        //ScriptB other = (ScriptB)go.GetComponent(typeof(ScriptB));
        //other.DoSomething()

        //FindObjectOfType<DialogueTrigger>().TriggerDialogue()        
        Debug.Log(taskManager.nTasks);

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
			ChapterOneDialogueController();
		}
		else if (sceneName == "Chapter 2")
		{
			ChapterTwoDialogueController();
		}
        
    }

	void ChapterOneDialogueController()
	{
		if (tasksCompleted == 0 && convosHad == 0)
        {
            GameObject conversation = GameObject.Find("IntroductoryConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            convosHad += 1;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }
        if (secondConversation == false)
        {
            GameObject conversation = GameObject.Find("SecondConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            secondConversation = true;
            convosHad += 1;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }

        if (startTruckingCompletionConversation){
            GameObject conversation = GameObject.Find("TruckCompletionConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            startTruckingCompletionConversation = false;
            convosHad++;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }

        if (thirdConversation == false)
        {
            GameObject conversation = GameObject.Find("ThirdConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            thirdConversation = true;
            convosHad += 1;



            if (other != null)
            {
                other.TriggerDialogue();
            }
        }


        if(startEntryIntroConversation)
        {
            GameObject conversation = GameObject.Find("EntryIntroConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            startEntryIntroConversation = false;
            convosHad++;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }

        if(startEntryErrorConversation)
        {
            GameObject conversation = GameObject.Find("EntryErrorConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            startEntryErrorConversation = false;
            convosHad++;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }

        if(startEntryCompletionConversation)
        {
            GameObject conversation = GameObject.Find("EntryCompletionConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            startEntryCompletionConversation = false;
            convosHad++;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }




        //These numbers are just for testing purposes
        if (taskManager.tasksEntry.Count == 0 && taskManager.tasksTrucking.Count == 0 && convosHad >= 3 && readyForFourthConvo)
        {
            GameObject conversation = GameObject.Find("FourthConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            fourthConversation = true;
            //DialogueManager.GetComponent<DialogueManager>().conversationFourDone = true;
            InputManager.GetComponent<InputManager>().setConvo4Activated(true);
            //DialogueController.GetComponent<DialogueController>().secondConversation = false;
            readyForFourthConvo = false;

            if (other != null)
            {
                other.TriggerDialogue();
                convosHad += 1;
            }
        }

        if (fifthConversation == false)
        {
            GameObject conversation = GameObject.Find("FifthConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            fifthConversation = true;
            DialogueManager.GetComponent<DialogueManager>().LastConversation = true;



            if (other != null)
            {
                other.TriggerDialogue();
            }
        }
	}

	void ChapterTwoDialogueController()
	{
		if (tasksCompleted == 0 && convosHad == 0)
        {
            TriggerThisDialogue("IntroConversation");
            // GameObject conversation = GameObject.Find("IntroConversation");
            // DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            // triggerManager.convosHad++;
			// convosHad += 1;

            // if (other != null)
            // {
            //     other.TriggerDialogue();
            // }
			triggerManager.Ch2IntroConversation = TriggerManager.convoStatus.Complete;
        }

		if( triggerManager.Ch2TruckSecurityConversation == TriggerManager.convoStatus.Ready)
		{
			TriggerThisDialogue("TruckSecurityConversation");
			triggerManager.Ch2TruckSecurityConversation = TriggerManager.convoStatus.Complete;
		}
	}

	void TriggerThisDialogue(string dialogueName)
	{
		GameObject conversation = GameObject.Find(dialogueName);
		DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
		convosHad += 1;

		if (other != null)
		{
			other.TriggerDialogue();
		}
	}
}
