using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterButtons : MonoBehaviour
{
    public Button petuniaB, swethB, mentoB;
    public static bool petuniaNotClicked = true, swethNotClicked = true, mentoNotClicked = true;

    //Sets the buttons interability when the scene is loaded again
    void Start()
    {
     
        //Go back to main menu and resets after finishing all chapters
        if((petuniaNotClicked == false) && (swethNotClicked == false) && (mentoNotClicked == false))
        {
            petuniaNotClicked = true;
            swethNotClicked = true;
            mentoNotClicked = true;
            SceneManager.LoadScene(0);
        }
        petuniaB.interactable = petuniaNotClicked;
        swethB.interactable = swethNotClicked;
        mentoB.interactable = mentoNotClicked;
    }

}
