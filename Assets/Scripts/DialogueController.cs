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
    public bool thirdConversation = true;
    public bool startTruckingCompletionConversation = false;
    public bool startEntryIntroConversation = false;
    public bool startEntryErrorConversation = false;
    public bool startEntryCompletionConversation = false;
    public bool startSortingIntroConversation = false;
    public bool startSortingCompletionConversation = false;
    public bool fourthConversation = true;
    public bool readyForFourthConvo = false;
    public bool fifthConversation = true;
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
            //Debug.Log("SHOULDN'T BE HAPPENING");
            ChapterTwoDialogueController();
		}
        else if (sceneName == "Chapter 3")
        {
            //Debug.Log("SHOULDN'T BE HAPPENING");
            ChapterThreeDialogueController();
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

        if(startSortingIntroConversation)
        {
            GameObject conversation = GameObject.Find("SortingIntroConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            startSortingIntroConversation = false;
            //convosHad++;

            if (other != null)
            {
                other.TriggerDialogue();
            }

        }

        if (startSortingCompletionConversation)
        {
            GameObject conversation = GameObject.Find("SortingCompletionConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            startSortingCompletionConversation = false;
            //convosHad++;

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
		if (triggerManager.Ch2IntroConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("IntroConversation");
			triggerManager.Ch2IntroConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2TruckSecurityConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("TruckSecurityConversation");
            triggerManager.Ch2TruckSecurityConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2TruckAlarmDecisionConversation == TriggerManager.convoStatus.Ready)
        {
            string dialogueName;
            if(triggerManager.Ch2TruckAlarmDecision == true)
            {
                dialogueName = "TruckAlarmDecisionConversation-Affirmative";
            }
            else
            {
                dialogueName = "TruckAlarmDecisionConversation-Negative";
            }
            TriggerThisDialogue(dialogueName);
            triggerManager.Ch2TruckAlarmDecisionConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2EntryPeskyScannerConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("EntryPeskyScannerConversation");
            triggerManager.Ch2EntryPeskyScannerConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2EntryAlarmDecisionConversation == TriggerManager.convoStatus.Ready)
        {
            string dialogueName;
            if(triggerManager.Ch2EntryAlarmDecision == true)
            {
                dialogueName = "EntryAlarmDecisionConversation-Affirmative";
            }
            else
            {
                dialogueName = "EntryAlarmDecisionConversation-Negative";
            }
            TriggerThisDialogue(dialogueName);
            triggerManager.Ch2EntryAlarmDecisionConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2InjuryReportConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("InjuryReportConversation");
            triggerManager.Ch2InjuryReportConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2NotCountingConversation1 == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("NotCountingConversation1");
            triggerManager.Ch2NotCountingConversation1 = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2NotCountingConversation2 == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("NotCountingConversation2");
            triggerManager.Ch2NotCountingConversation2 = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2NotCountingConversation3 == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("NotCountingConversation3");
            triggerManager.Ch2NotCountingConversation3 = TriggerManager.convoStatus.Complete;
        }


        if(triggerManager.Ch2MediocreEvaluationConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("MediocreEvaluationConversation");
            triggerManager.Ch2MediocreEvaluationConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2PackagedFunFactConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("PackagedFunFactConversation");
            triggerManager.Ch2PackagedFunFactConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2AllowPackagesDecisionConversation == TriggerManager.convoStatus.Ready)
        {
            string dialogueName;
            if(triggerManager.Ch2EntryAlarmDecision == true)
            {
                dialogueName = "AllowPackagesDecisionConversation-Affirmative";
            }
            else
            {
                dialogueName = "AllowPackagesDecisionConversation-Negative";
            }
            TriggerThisDialogue(dialogueName);
            triggerManager.Ch2AllowPackagesDecisionConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2HeadOfficeMemoConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("HeadOfficeMemoConversation");
            triggerManager.Ch2HeadOfficeMemoConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.Ch2ConfirmCleanSystemConversation == TriggerManager.convoStatus.Ready)
        {
            string dialogueName;
            if(triggerManager.Ch2ConfirmCleanSystem == true)
            {
                dialogueName = "ConfirmCleanSystemConversation-Affirmative";
            }
            else
            {
                dialogueName = "ConfirmCleanSystemConversation-Negative";
            }
            TriggerThisDialogue(dialogueName);
            triggerManager.Ch2ConfirmCleanSystemConversation = TriggerManager.convoStatus.Complete;
        }

        
        // if(triggerManager.xxx == TriggerManager.convoStatus.Ready)
        // {
        //     TriggerThisDialogue(xxx)
        //     triggerManager.xxx = TriggerManager.convoStatus.Complete;
        // }

        // if(triggerManager.xxx == TriggerManager.convoStatus.Ready)
        // {
        //     string dialogueName;
        //     if(triggerManager.Ch2EntryAlarmDecision == true)
        //     {
        //         dialogueName = "xxx-Affirmative";
        //     }
        //     else
        //     {
        //         dialogueName = "xxx-Negative";
        //     }
        //     TriggerThisDialogue(dialogueName);
        //     triggerManager.xxx = TriggerManager.convoStatus.Complete;
        // }
	}

    void ChapterThreeDialogueController()
    {
        if(triggerManager.D1IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D1IVAALConversation");
            triggerManager.D1IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D2VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D2VirusConversation");
            triggerManager.D2VirusConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D3IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D3IVAALConversation");
            triggerManager.D3IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D4IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D4IVAALConversation");
            triggerManager.D4IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D5IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D5IVAALConversation");
            triggerManager.D5IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D6VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D6VirusConversation");
            triggerManager.D6VirusConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D7IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D7IVAALConversation");
            triggerManager.D7IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D8IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D8IVAALConversation");
            triggerManager.D8IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D9VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D9VirusConversation");
            triggerManager.D9VirusConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D10IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D10IVAALConversation");
            triggerManager.D10IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D11VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D11VirusConversation");
            triggerManager.D11VirusConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D12IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D12IVAALConversation");
            triggerManager.D12IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D13IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D13IVAALConversation");
            triggerManager.D13IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D14IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D14IVAALConversation");
            triggerManager.D14IVAALConversation = TriggerManager.convoStatus.Complete;
        }

        if(triggerManager.D15VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D15VirusConversation");
            triggerManager.D15VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D16IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D16IVAALConversation");
            triggerManager.D16IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D17VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D17VirusConversation");
            triggerManager.D17VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D18IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D18IVAALConversation");
            triggerManager.D18IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D19IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D19IVAALConversation");
            triggerManager.D19IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D20IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D20IVAALConversation");
            triggerManager.D20IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D21VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D21VirusConversation");
            triggerManager.D21VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D22IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D22IVAALConversation");
            triggerManager.D22IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D23VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D23VirusConversation");
            triggerManager.D23VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D24IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D24IVAALConversation");
            triggerManager.D24IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D25VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D25VirusConversation");
            triggerManager.D25VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D26IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D26IVAALConversation");
            triggerManager.D26IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D27BexosConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D27BexosConversation");
            triggerManager.D27BexosConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D28BexosConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D28BexosConversation");
            triggerManager.D28BexosConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D29BexosConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D29BexosConversation");
            triggerManager.D29BexosConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D30VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D30VirusConversation");
            triggerManager.D30VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D31IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D31IVAALConversation");
            triggerManager.D31IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D32VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D32VirusConversation");
            triggerManager.D32VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D33IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D33IVAALConversation");
            triggerManager.D33IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D34VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D34VirusConversation");
            triggerManager.D34VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D35IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D35IVAALConversation");
            triggerManager.D35IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D36IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D36IVAALConversation");
            triggerManager.D36IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D37IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D37IVAALConversation");
            triggerManager.D37IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D38IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D38IVAALConversation");
            triggerManager.D38IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D39IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D39IVAALConversation");
            triggerManager.D39IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D40IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D40IVAALConversation");
            triggerManager.D40IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D41IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D41IVAALConversation");
            triggerManager.D41IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D42IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D42IVAALConversation");
            triggerManager.D42IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D43VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D43VirusConversation");
            triggerManager.D43VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D44IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D44IVAALConversation");
            triggerManager.D44IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D45IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D45IVAALConversation");
            triggerManager.D45IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D46VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D46VirusConversation");
            triggerManager.D46VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D47IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D47IVAALConversation");
            triggerManager.D47IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D48IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D48IVAALConversation");
            triggerManager.D48IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D49VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D49VirusConversation");
            triggerManager.D49VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D50IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D50IVAALConversation");
            triggerManager.D50IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D51IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D51IVAALConversation");
            triggerManager.D51IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D52BexosConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D52BexosConversation");
            triggerManager.D52BexosConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D53VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D53VirusConversation");
            triggerManager.D53VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D54BexosConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D54BexosConversation");
            triggerManager.D54BexosConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D55VirusConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D55VirusConversation");
            triggerManager.D55VirusConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D56IVAALConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D56IVAALConversation");
            triggerManager.D56IVAALConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D57BexosConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D57BexosConversation");
            triggerManager.D57BexosConversation = TriggerManager.convoStatus.Complete;
        }
        
        if(triggerManager.D58UnknownConversation == TriggerManager.convoStatus.Ready)
        {
            TriggerThisDialogue("D58UnknownConversation");
            triggerManager.D58UnknownConversation = TriggerManager.convoStatus.Complete;
        }
    }

	void TriggerThisDialogue(string dialogueName)
	{
		GameObject conversation = GameObject.Find(dialogueName);
		DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();

		if (other != null)
		{
			other.TriggerDialogue();
		}
	}
}
