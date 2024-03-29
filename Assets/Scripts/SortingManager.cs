﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public DialogueController dialogueController;
    public AudioClip boxFillSound;
    public AudioClip startSound;
    public AudioSource audioSource;


    //Making a centralized location for all triggers to reside.
    public TriggerManager triggerManager;

    public SpriteRenderer shape1, shape2, shape3, numberTries, workers;
    public SortingCombinations sc;
    private int rand;
    private int gotRightCount = 0;
    public bool done = false;

    //Testing variables
    //public SpriteRenderer valid;

    void Start()
    {
        shape1.sprite = null;
        shape2.sprite = null;
        shape3.sprite = null;
        workers.sprite = null;

        GameObject triggerManagerObj = GameObject.Find("/TriggerManager");
        if (triggerManagerObj != null)
        {
            triggerManager = triggerManagerObj.GetComponent<TriggerManager>();
        }
    }

    //Update for quick testing sorting in Sorting Testing scene. Uncomment to use.
    /*
    void Update()
    {
        checkIfComplete();

        if(Input.GetKeyDown(KeyCode.N) && shape1.sprite == null)
        {
            gotRightCount = 0;
            workers.sprite = sc.workers[1];
            triesCountChange(0);
            reroll();
        }

        else if(Input.GetKeyDown(KeyCode.W) && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.invalid)
            {
                //valid.sprite = sc.shapes[3];
                ++gotRightCount;
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                //valid.sprite = sc.shapes[6];
            }
            reroll();

        }

        else if(Input.GetKeyDown(KeyCode.R) && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.valid)
            {
                //valid.sprite = sc.shapes[6];
                ++gotRightCount;
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                //valid.sprite = sc.shapes[3];
            }
            reroll();
            //Debug.Log(sc.combinations[rand][3]);
        }
    }
    */
    

    public void validate(string command)
    {
        //If there are no shapes, roll new ones
        if(command == "interact" && shape1.sprite == null)
        {
            audioSource.PlayOneShot(startSound, 0.7f);
            gotRightCount = 0;
            workers.sprite = sc.workers[0];
            triesCountChange(0);
            reroll();
        }

        //If the combination is valid
        else if(command == "affirm" && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.valid)
            {
                //valid.sprite = sc.shapes[6];
                ++gotRightCount;
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                //valid.sprite = sc.shapes[3];
                --gotRightCount;
                if(gotRightCount < 0)
                {
                    gotRightCount = 0;
                }
                triesCountChange(gotRightCount);
            }
            reroll();
            //Debug.Log(sc.combinations[rand][3]);
        }

        //If the combination is invalid
        else if(command == "negative" && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.invalid)
            {
                //valid.sprite = sc.shapes[3];
                ++gotRightCount;
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                //valid.sprite = sc.shapes[6];
                --gotRightCount;
                if (gotRightCount < 0)
                {
                    gotRightCount = 0;
                }
                triesCountChange(gotRightCount);
            }
            reroll();
        }

        else
        {
            return;
        }
    }

    //An update check in input manager to stop the game
    public bool checkIfComplete()
    {
        if (gotRightCount == 3)
        {
            Debug.Log("check if complete");
            dialogueController.tasksCompleted += 1;
            //triggerManager.tasksCompleted += 1;
            //triggerManager.sortingTasksCompleted += 1;
            reset();
            workers.sprite = null;
            done = true;
            return true;
        }

        else return false;
    }

    //Update sprite for number of tries in the corner
    void triesCountChange(int tryCount)
    {
        numberTries.sprite = sc.tries[tryCount];
    }

    //Reset shapes to nothing
    void reset()
    {
        shape1.sprite = null;
        shape2.sprite = null;
        shape3.sprite = null;
    }

    //Reset everything 
    public void hardReset()
    {
        gotRightCount = 0;
        reset();
        triesCountChange(0);
    }

    //Reroll shapes when command is affirm or negative
    void reroll()
    {
        audioSource.PlayOneShot(boxFillSound, 0.7f);
        rand = Random.Range(0, sc.combinations.Count);
        shape1.sprite = sc.shapes[(int)sc.combinations[rand][0]];
        shape2.sprite = sc.shapes[(int)sc.combinations[rand][1]];
        shape3.sprite = sc.shapes[(int)sc.combinations[rand][2]];
    }
}
