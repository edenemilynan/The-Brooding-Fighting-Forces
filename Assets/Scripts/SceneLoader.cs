using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public CharacterButtons cb;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void LoadScene(Button button)
    {
        // Load character intro and set false if done chapter
        // Changes the buttons to not be interactable by CharacterButton script
        if (button == cb.mentoB)
        {
            CharacterButtons.mentoNotClicked = false;
            SceneManager.LoadScene(3);
        }
        else if(button == cb.petuniaB)
        {
            CharacterButtons.petuniaNotClicked = false;
            SceneManager.LoadScene(5);
        }
        else if (button == cb.swethB)
        {
            CharacterButtons.swethNotClicked = false;
            SceneManager.LoadScene(7);
        }
        
    }
    
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    

    public void QuitGame()
    {
        Application.Quit();

    }


}
