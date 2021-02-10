using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;

    public Animator animator;
    //public bool pressed = false;

    //IEnumerator coroutine;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    /*void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            pressed = true;
        }
    }*/
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (talking == true)
            {
                Debug.Log("made it");
                DisplayNextSentence();
            }

            else
            {
                EndDialogue();
                Debug.Log("why not");
            }
        }

    }*/
        /*if (Input.GetKeyDown(KeyCode.Return) && talking == false)
        {
            EndDialogue();
        }*/
    

    /*IEnumerator waitForInput(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return 0;
            yield return null;
        }
        //yield return new while(() => Input.GetKeyDown(KeyCode.Return));

    }*/

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Are you here?");
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
    }
    public void DisplayNextSentence()
    {
        //pressed = false;

        if (sentences.Count == 0)
        {
            //StartCoroutine(waitForInput(KeyCode.Return));
            
            EndDialogue();
            //pressed = false;
            return;
            
        }
        
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StartCoroutine(wait());
        Debug.Log("What about you?");
        //pressed = false;
        //StartCoroutine(waitForInput(KeyCode.Return));
        if (Input.GetKey(KeyCode.Return))
        {
            DisplayNextSentence();
        }

        //}
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        
    }

}
