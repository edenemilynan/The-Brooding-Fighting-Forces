using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDSwitch : MonoBehaviour
{
    public Sprite[] IDsprites;
    public SpriteRenderer ID;
    string currentCharacter;

    void Start()
    {
        currentCharacter = SceneLoader.currentCharacter;
        changeID();
    }
    void changeID()
    {
        if(currentCharacter == "mento")
        {
            ID.sprite = IDsprites[0];
        }

        else if (currentCharacter == "pentunia")
        {
            ID.sprite = IDsprites[1];
        }

        else if (currentCharacter == "sweth")
        {
            ID.sprite = IDsprites[2];
        }
    }
    
}
