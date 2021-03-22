using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    //Angry = 1
    //Closed = 2
    //Excited = 3
    //Down right = 4
    //Left = 5
    //Neutral = 6
    //Suspicious = 7
    //Surprised = 8
    //Unamused = 9

    [TextArea(3, 10)]
    public string[] sentences;
    public string[] names;
    public int[] expressions;
    public int[] sounds;

}
