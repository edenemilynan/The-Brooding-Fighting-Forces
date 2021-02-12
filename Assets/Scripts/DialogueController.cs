using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private bool firstConversation = false;
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
        
    }
}
