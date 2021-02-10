using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceBarInput : MonoBehaviour
{

    private float morseTimer = 0.0f; //timer to track how long someone has pressed the spacebar to input morse code.
    private float dawLength  = 0.35f;
    private float ditLength  = 0.1f;
    private float gapTimer   = 0.0f;
    private enum  Signal {Dit, Daw};
    private List<Signal> morseCodeSignals = new List<Signal>();
    private float gapLength = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            morseTimer += Time.deltaTime;
            gapTimer    = 0.0f;

        }
        else
        {
            gapTimer += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            if(morseTimer > dawLength)
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
            morseTimer = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            PrintLetter(true);
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            morseCodeSignals.RemoveAt(morseCodeSignals.Count - 1);
            PrintLetter();
        }

    }

    void PrintLetter(bool deleteLetter = false)
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

        Debug.Log("Current Letter: " + morseLetter);

        if(deleteLetter)
        {
            morseCodeSignals.Clear();
            Debug.Log("Letter Cleared");
        } 
    }
}