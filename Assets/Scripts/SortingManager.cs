using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public SpriteRenderer shape1, shape2, shape3, valid, numberTries, workers;
    public SortingCombinations sc;
    private int rand;
    private int gotRightCount = 0;

    void Start()
    {
        shape1.sprite = null;
        shape2.sprite = null;
        shape3.sprite = null;
    }

    //Update for quick testing sorting. Uncomment to use.
    /*
    void Update()
    {
        if(gotRightCount == 3)
        {
            reset();
        }

        else if(Input.GetKeyDown(KeyCode.N) && shape1.sprite == null)
        {
            reroll();
        }

        else if(Input.GetKeyDown(KeyCode.W) && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.invalid)
            {
                valid.sprite = sc.shapes[3];
                ++gotRightCount;
                if (gotRightCount > 3)
                {
                    gotRightCount = 0;
                    triesCountChange(0);
                    reset();
                }
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                valid.sprite = sc.shapes[6];
            }
            reroll();

        }

        else if(Input.GetKeyDown(KeyCode.R) && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.valid)
            {
                valid.sprite = sc.shapes[6];
                ++gotRightCount;
                if (gotRightCount > 3)
                {
                    gotRightCount = 0;
                    triesCountChange(0);
                    reset();
                }
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                valid.sprite = sc.shapes[3];
            }
            reroll();
            //Debug.Log(sc.combinations[rand][3]);
        }
    }
    */

    public void validate(string command)
    {
        if(gotRightCount == 3)
        {
            reset();
            workers.sprite = sc.workers[0];
        }
        //If there are no shapes, roll new ones
        if(command == "interact" && shape1.sprite == null)
        {
            workers.sprite = sc.workers[1];
            reroll();
        }

        //If the combination is valid
        else if(command == "affirm" && shape1.sprite != null)
        {

            if (sc.combinations[rand][3] == SortingCombinations.Shape.valid)
            {
                valid.sprite = sc.shapes[6];
                ++gotRightCount;
                if (gotRightCount > 3)
                {
                    gotRightCount = 0;
                    triesCountChange(0);
                    reset();
                }
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                valid.sprite = sc.shapes[3];
            }
            reroll();
            //Debug.Log(sc.combinations[rand][3]);
        }

        //If the combination is invalid
        else if(command == "negative" && shape1.sprite != null)
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.invalid)
            {
                valid.sprite = sc.shapes[3];
                ++gotRightCount;
                if (gotRightCount > 3)
                {
                    gotRightCount = 0;
                    triesCountChange(0);
                    reset();
                }
                triesCountChange(gotRightCount);
                Debug.Log(gotRightCount);
            }
            else
            {
                valid.sprite = sc.shapes[6];
            }
            reroll();
        }

        else
        {
            return;
        }
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

    //Reroll shapes when command is affirm or negative
    void reroll()
    {
        rand = Random.Range(0, sc.combinations.Count);
        shape1.sprite = sc.shapes[(int)sc.combinations[rand][0]];
        shape2.sprite = sc.shapes[(int)sc.combinations[rand][1]];
        shape3.sprite = sc.shapes[(int)sc.combinations[rand][2]];
    }
}
