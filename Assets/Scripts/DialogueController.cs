using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private bool firstConversation = false;
    public bool secondConversation = true;
    public bool thirdConversation  = true;
    public bool fourthConversation = true;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject go = GameObject.Find("somegameobjectname");
        //ScriptB other = (ScriptB)go.GetComponent(typeof(ScriptB));
        //other.DoSomething()

        //FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firstConversation == false)
        {
            GameObject conversation = GameObject.Find("FirstConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            firstConversation = true;

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

        if (fourthConversation == false)
        {
            GameObject conversation = GameObject.Find("FourthConversation");
            DialogueTrigger other = (DialogueTrigger)conversation.GetComponent<DialogueTrigger>();
            fourthConversation = true;

            if (other != null)
            {
                other.TriggerDialogue();
            }
        }
        
    }
}
