using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueName;

	public int waitTime;

    public Animator animator;
    public Animator changeInExpression;

    public bool talking = false;
    public bool LastConversation = false;
    //public bool pressed = false;

    //IEnumerator coroutine;

    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<int> expressions;
    private Queue<int> sounds;
    private GameObject dialogueAudioPlayer;
	private int timer;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        expressions = new Queue<int>();
        sounds = new Queue<int>();
        dialogueAudioPlayer = transform.Find("DialogueAudioPlayer").gameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && timer == 0)
        {
            if (sentences.Count != 0)
            {
                DisplayNextSentence();
                Debug.Log("cat");
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
        sentences.Clear();
        names.Clear();
        expressions.Clear();
        sounds.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (int expression in dialogue.expressions)
        {
            expressions.Enqueue(expression);
        }

        foreach (int sound in dialogue.sounds)
        {
            sounds.Enqueue(sound);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {       
        string name = "I.V.A.A.L.";
        int expression = 6;
        int sound = 0; //no sound
        string sentence = sentences.Dequeue();
        
        if(names.Count != 0)      { name       = names.Dequeue(); }
        if(expressions.Count != 0){ expression = expressions.Dequeue(); }
        if(sounds.Count != 0     ){ sound      = sounds.Dequeue(); }


        dialogueText.text = sentence;
        dialogueName.text = name;
        changeInExpression.SetInteger("expression", expression);
        dialogueAudioPlayer.GetComponent<DialogueAudioPlayer>().PlayDialogueSound(sound);

		timer = waitTime;
    }

    void EndDialogue()
    {
        talking = false;
        animator.SetBool("IsOpen", false);
        if(LastConversation)
        {
            SceneManager.LoadScene(0);
        }
    }

}
