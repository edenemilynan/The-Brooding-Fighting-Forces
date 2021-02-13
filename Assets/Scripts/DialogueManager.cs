using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueText2;
    //public TextMeshProUGUI dialogueText3;
	public int waitTime;
    public Animator animator;
    public Animator animator2;
    public bool talking = false;
    public bool conversationFourDone = false;
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
        talking = true;
        animator.SetBool("IsOpen", true);
        animator2.SetBool("IsOpen", true);
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
        dialogueText2.text = sentence;
        //dialogueText3.text = sentence;
		timer = waitTime;
    }

    void EndDialogue()
    {
        talking = false;
        animator.SetBool("IsOpen", false);
        animator2.SetBool("IsOpen", false);
        if(conversationFourDone)
        {
            SceneManager.LoadScene(0);
        }
    }

}
