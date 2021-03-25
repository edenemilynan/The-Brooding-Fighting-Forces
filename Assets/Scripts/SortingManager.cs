using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public SpriteRenderer shape1, shape2, shape3, valid;
    public SortingCombinations sc;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            rand = Random.Range(0, sc.combinations.Count);
            shape1.sprite = sc.shapes[(int)sc.combinations[rand][0]];
            shape2.sprite = sc.shapes[(int)sc.combinations[rand][1]];
            shape3.sprite = sc.shapes[(int)sc.combinations[rand][2]];
            
            if(sc.combinations[rand][3] == SortingCombinations.Shape.valid)
            {
                valid.sprite = sc.shapes[6];
            }
            else
            {
                valid.sprite = sc.shapes[3];
            }
            Debug.Log(sc.combinations[rand][3]);
        }
    }
}
