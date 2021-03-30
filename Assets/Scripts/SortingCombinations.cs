using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingCombinations : MonoBehaviour
{
    //shapes ordered as orange(123), blue(123), green(123)
    public Sprite[] shapes;
    public Sprite[] workers;
    public Sprite[] tries;
    public Dictionary<int, List<Shape>> combinations = new Dictionary<int, List<Shape>>();
    private int count = 0; 
    string str;
    public enum Shape { O1, O2, O3, B1, B2, B3, G1, G2, G3, valid, invalid}; 

    void Start()
    {
        //Dictionary with the pattern number, a list containing the pattern, if its a valid pattern
        //Dictionary(pattern number, {shape1, shape2, shape3, validity})
        //Sorting rule 1: 1 + 2 + 3
        for (int i = 0; i < 3; ++i){
            for (int j = 0; j < 3; ++j){
                for (int k = 0; k < 3; ++k)
                {
                    combinations.Add(count, new List<Shape> { (Shape)(0 + i * 3), (Shape)(1 + j * 3), (Shape)(2 + k * 3) , Shape.invalid});
                    str += combinations[count][0];
                    str += combinations[count][1];
                    str += combinations[count][2] + " ";
                    str += count;
                    //Debug.Log(str);
                    count++;
                    str = "";
                }
            }
        }

        //Sorting rule 2: 1 + 1 + 1
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                for (int k = 0; k < 3; ++k)
                {
                    combinations.Add(count, new List<Shape> { (Shape)(0 + i * 3), (Shape)(0 + j * 3), (Shape)(0 + k * 3), Shape.invalid });
                    str += combinations[count][0];
                    str += combinations[count][1];
                    str += combinations[count][2] + " ";
                    str += count;
                    //Debug.Log(str);
                    count++;
                    str = "";
                }
            }
        }

        //Sorting rule 3: 2 + 2 + 2
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                for (int k = 0; k < 3; ++k)
                {
                    combinations.Add(count, new List<Shape> { (Shape)(1 + i * 3), (Shape)(1 + j * 3), (Shape)(1 + k * 3), Shape.invalid });
                    str += combinations[count][0];
                    str += combinations[count][1];
                    str += combinations[count][2] + " ";
                    str += count;
                    //Debug.Log(str);
                    count++;
                    str = "";
                }
            }
        }

        //Sorting rule 4: 3 + 3 + 3
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                for (int k = 0; k < 3; ++k)
                {
                    combinations.Add(count, new List<Shape> { (Shape)(2 + i * 3), (Shape)(2 + j * 3), (Shape)(2 + k * 3), Shape.invalid });
                    str += combinations[count][0];
                    str += combinations[count][1];
                    str += combinations[count][2] + " ";
                    str += count;
                    //Debug.Log(str);
                    count++;
                    str = "";
                }
            }
        }

        //Debug.Log(count);

        //The valid combinations
        combinations[0][3] = Shape.valid;
        combinations[13][3] = Shape.valid;
        combinations[26][3] = Shape.valid;
        combinations[5][3] = Shape.valid;
        combinations[21][3] = Shape.valid;
        combinations[11][3] = Shape.valid;
        combinations[7][3] = Shape.valid;
        combinations[19][3] = Shape.valid;
        combinations[15][3] = Shape.valid;
        combinations[32][3] = Shape.valid;
        combinations[100][3] = Shape.valid;
        combinations[65][3] = Shape.valid;
    }
}
