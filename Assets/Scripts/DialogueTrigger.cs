using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    //public Dialogue dialogue;
    public string dialogueName;

    public void TriggerDialogue() {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogueName);
    }

}
