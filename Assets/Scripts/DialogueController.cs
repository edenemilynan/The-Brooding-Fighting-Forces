using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public int tasksCompleted = 0;
    public int convosHad = 0;
    public bool secondConversation = true;
    public bool thirdConversation  = true;
    public bool fourthConversation = true;
    public GameObject DialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject go = GameObject.Find("somegameobjectname");
        //ScriptB other = (ScriptB)go.GetComponent(typeof(ScriptB));
        //other.DoSomething()

        //FindObjectOfType<DialogueTrigger>().TriggerDialogue()        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tasksCompleted == 0 && convosHad == 0)
        {
            GameObject conversation = GameObject.Find("FirstConversation");
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



            if (other != null)
            {
                other.TriggerDialogue();
            }
        }

        //These numbers are just for testing purposes
        if (tasksCompleted == 3 && convosHad == 1)
        {
            GameObject conversation = GameObject.Find("FourthConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            fourthConversation = true;
            DialogueManager.GetComponent<DialogueManager>().conversationFourDone = true;
            //DialogueController.GetComponent<DialogueController>().secondConversation = false;

            if (other != null)
            {
                other.TriggerDialogue();
                convosHad += 1;
            }
        }
        
    }
}
