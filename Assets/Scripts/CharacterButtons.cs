using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterButtons : MonoBehaviour
{
    public Button petuniaB, swethB, mentoB;
    public SpriteRenderer employeeBG;
    public Sprite[] backgrounds;
    public static bool petuniaAlive = true, swethAlive = true, mentoAlive = true;
    private Dictionary<string, int> whosAlive = new Dictionary<string, int>();
    string state = "";

    //Sets the buttons interability when the scene is loaded again
    void Start()
    {
        //Go back to main menu and resets after finishing all chapters
        if ((petuniaAlive == false) && (swethAlive == false) && (mentoAlive == false))
        {
            petuniaAlive = true;
            swethAlive = true;
            mentoAlive = true;
            SceneManager.LoadScene(0);
        }

        //Disable buttons
        petuniaB.interactable = petuniaAlive;
        swethB.interactable = swethAlive;
        mentoB.interactable = mentoAlive;

        //Load the game state
        createLog();
        updateCharacterSelection();
    }

    //initialize dictionary of game states
    void createLog()
    {
        //Person order: Petunia, Sweth, Mento
        whosAlive.Add("TrueTrueTrue", 0); //Everyone Alive
        whosAlive.Add("TrueTrueFalse", 1); //Petunia and Sweth Alive
        whosAlive.Add("TrueFalseTrue", 2); //Petunia and Mento Alive
        whosAlive.Add("TrueFalseFalse", 3); //Petunia Alive
        whosAlive.Add("FalseTrueTrue", 4); //Sweth and Mento Alive
        whosAlive.Add("FalseTrueFalse", 5); //Sweth Alive
        whosAlive.Add("FalseFalseTrue", 6); //Mento Alive
    }

    //Update the background and the button locations
    void updateCharacterSelection()
    {
        state += petuniaAlive;
        state += swethAlive;
        state += mentoAlive;

        int key = whosAlive[state];
        employeeBG.sprite = backgrounds[key];

        //Move buttons x = -643, -30, 622 (everyone alive), -344, 280 (two people alive), -30 (one person alive)
        if (key == 1)
        {
            petuniaB.transform.localPosition = new Vector3(-344, -16, 0);
            swethB.transform.localPosition = new Vector3(280, -16, 0);
        }

        else if (key == 2)
        {
            petuniaB.transform.localPosition = new Vector3(-344, -16, 0);
            mentoB.transform.localPosition = new Vector3(280, -16, 0);
        }

        else if (key == 3)
        {
            petuniaB.transform.localPosition = new Vector3(-30, -16, 0);
            swethB.transform.localPosition = new Vector3(622, -16, 0);
        }

        else if (key == 4)
        {
            swethB.transform.localPosition = new Vector3(-344, -16, 0);
            mentoB.transform.localPosition = new Vector3(280, -16, 0);
        }

        else if (key == 5)
        {
            swethB.transform.localPosition = new Vector3(-30, -16, 0);
        }

        else if (key == 6)
        {
            mentoB.transform.localPosition = new Vector3(-30, -16, 0);
            swethB.transform.localPosition = new Vector3(622, -16, 0);
        }
        else
        {
            petuniaB.transform.localPosition = new Vector3(-643, -16, 0);
            swethB.transform.localPosition = new Vector3(-30, -16, 0);
            mentoB.transform.localPosition = new Vector3(622, -16, 0);
        }
    }

}