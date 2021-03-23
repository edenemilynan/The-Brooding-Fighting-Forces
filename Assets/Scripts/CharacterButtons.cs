using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour
{
    public Button petuniaB, swethB, mentoB;
    public static bool petuniaNotClicked = true, swethNotClicked = true, mentoNotClicked = true;

    //Sets the buttons interability when the scene is loaded again
    void Start()
    {
        petuniaB.interactable = petuniaNotClicked;
        swethB.interactable = swethNotClicked;
        mentoB.interactable = mentoNotClicked;
    }

}
