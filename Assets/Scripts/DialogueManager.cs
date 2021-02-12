﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
	public int waitTime;
    public Animator animator;
    //public bool pressed = false;

    //IEnumerator coroutine;

    private Queue<string> sentences;
	private int timer;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && timer == 0)
        {
            if (sentences.Count != 0)
            {
                DisplayNextSentence();
            }
            else if (sentences.Count == 0)
            {
                EndDialogue();
            }
        }
		
		if (timer > 0)
		{
			timer -= 1;
		}
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
		timer = waitTime;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}
