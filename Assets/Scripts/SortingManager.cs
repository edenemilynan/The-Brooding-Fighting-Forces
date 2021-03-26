using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public SpriteRenderer shape1, shape2, shape3, valid, numberTries;
    public SortingCombinations sc;
    int rand;
    int tryCount = 0;

    void Start()
    {
        shape1.sprite = null;
        shape2.sprite = null;
        shape3.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            rand = Random.Range(0, sc.combinations.Count);
            shape1.sprite = sc.shapes[(int)sc.combinations[rand][0]];
            shape2.sprite = sc.shapes[(int)sc.combinations[rand][1]];
            shape3.sprite = sc.shapes[(int)sc.combinations[rand][2]];
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (sc.combinations[rand][3] == SortingCombinations.Shape.invalid)
            {
                valid.sprite = sc.shapes[3];
            }
            else
            {
                valid.sprite = sc.shapes[6];
                ++tryCount;
                if (tryCount > 3)
                {
                    tryCount = 0;
                    triesCountChange(0);
                    shape1.sprite = null;
                    shape2.sprite = null;
                    shape3.sprite = null;
                }
                triesCountChange(tryCount);
                Debug.Log(tryCount);
            }

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(sc.combinations[rand][3] == SortingCombinations.Shape.valid)
            {
                valid.sprite = sc.shapes[6];
            }
            else
            {
                valid.sprite = sc.shapes[3];
                ++tryCount;
                if (tryCount > 3)
                {
                    tryCount = 0;
                    triesCountChange(0);
                    shape1.sprite = null;
                    shape2.sprite = null;
                    shape3.sprite = null;
                }
                triesCountChange(tryCount);
                Debug.Log(tryCount);
            }
            //Debug.Log(sc.combinations[rand][3]);
        }
    }

    void triesCountChange(int tryCount)
    {
        numberTries.sprite = sc.tries[tryCount];

    }
}
