using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceBarInput : MonoBehaviour
{

    private float morseTimer = 0.0f; //timer to track how long someone has pressed the spacebar to input morse code.
    private float dawLength  = 0.45f;
    //private float ditLength  = 0.1f;
    //private float gapTimer   = 0.0f;
    public enum  Signal {Dit, Daw};
    public List<Signal> morseCodeSignals = new List<Signal>();
    public string morseReturn;
    public GameObject manager;
    //public GameObject manager;
    //private float gapLength = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isTalking = manager.GetComponent<DialogueManager>().path;

        morseReturn = "";
        if (Input.GetKey(KeyCode.Space))
        {
            
            morseTimer += Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (morseCodeSignals.Count < 2) //&& isTalking == false)
            {
                if (morseTimer > dawLength)
                {
                    morseCodeSignals.Add(Signal.Daw);
                    Debug.Log(morseTimer + " seconds: DAW");
                    PrintLetter();
                }
                else
                {
                    morseCodeSignals.Add(Signal.Dit);
                    Debug.Log(morseTimer + " seconds: DIT");
                    PrintLetter();

                }
            }
            

            morseTimer = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            //PrintLetter(true);

            morseReturn = "";
            Debug.Log("Current String: " + morseReturn);
            foreach (Signal sig in morseCodeSignals)
            {
                if (sig == Signal.Dit)
                {
                    morseReturn += ".";
                }
                else
                {
                    morseReturn += "-";
                }
            }
            morseCodeSignals.Clear();
            Debug.Log("Return String: " + morseReturn);
        }

        if (morseCodeSignals.Count > 0 && Input.GetKeyDown(KeyCode.Backspace))
        {
            morseCodeSignals.RemoveAt(morseCodeSignals.Count - 1);
            PrintLetter();
        }

    }

    void PrintLetter(bool deleteLetter = false)
    {   
        string morseLetter = GetCurrentMorseLetter();

        Debug.Log("Current Letter: " + morseLetter);

        if(deleteLetter)
        {
            morseCodeSignals.Clear();
            Debug.Log("Letter Cleared");
        } 
    }

    public string GetCurrentMorseLetter()
    {
        string morseLetter = "";

        foreach(Signal sig in morseCodeSignals)
        {
            if(sig == Signal.Dit)
            {
                morseLetter += ".";
            }
            else
            {
                morseLetter += "-";
            }
        }

        return morseLetter;
    }
}