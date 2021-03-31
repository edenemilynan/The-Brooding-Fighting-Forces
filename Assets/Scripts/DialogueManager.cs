using System.Collections;
using System.Collections.Generic;
using System.IO;
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
		
		// Tick down the timer
		if (timer > 0)
		{
			timer -= 1;
		}

    }

    public void StartDialogue(string fileName)
    {
        talking = true;
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        names.Clear();
        expressions.Clear();
        sounds.Clear();

        StreamReader sr = new StreamReader("Assets/Dialogues/"+fileName+".csv");
		List<string> lines = new List<string>();
		while (!sr.EndOfStream)
		{
			string temp = sr.ReadLine();
			lines.Add(temp);
		}
        for (int i = 0; i < lines.Count; i++)
        {
            string[] line = (lines[i].Trim()).Split("|"[0]);
			
			try
			{
				string w = line[0];
				sentences.Enqueue(w);
			}
			catch{}
			
			try
			{
				string x = line[1];
				names.Enqueue(x);
			}
			catch{}
			
			try
			{
				int y = int.Parse(line[2]);
				expressions.Enqueue(y);
			}
			catch{}
			
			try
			{
				int z = int.Parse(line[3]);
				sounds.Enqueue(z);
			}
            catch
			{
				sounds.Enqueue(0);
			}
		}

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {       
		// Play Dialogue Advancing Daw Sound
		dialogueAudioPlayer.GetComponent<DialogueAudioPlayer>().PlayDialogueSound(3, 0.2f);
        string name = "I.V.A.A.L.";
        int expression = 6;
        int sound = 0; //no sound
        string sentence = sentences.Dequeue();
        
        if(names.Count != 0)      { name       = names.Dequeue(); }
        if(expressions.Count != 0){ expression = expressions.Dequeue(); }
        if(sounds.Count != 0     ){ sound      = sounds.Dequeue(); }


        dialogueText.text = sentence;
        dialogueName.text = name;
        changeInExpression.SetFloat("BlendExpression", expression);
        dialogueAudioPlayer.GetComponent<DialogueAudioPlayer>().PlayDialogueSound(sound);

		timer = waitTime;
    }

    void EndDialogue()
    {
        talking = false;
        animator.SetBool("IsOpen", false);
        if(LastConversation)
        {
            SceneManager.LoadScene(1);
        }
    }

}
