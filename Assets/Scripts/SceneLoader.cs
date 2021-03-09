using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //Load
    public Button petuniaB, swethB, mentoB;
    public bool petuniaDone = false, swethDone = false , mentoDone = false;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void LoadScene(Button button)
    {
        // Load character intro and set true if done chapter
        if (button == mentoB)
        {
            SceneManager.LoadScene(2);
            mentoDone = true;
        }
        else if(button == swethB)
        {
            SceneManager.LoadScene(4);
        }
        else if (button == mentoB)
        {
            SceneManager.LoadScene(6);
        }
        

    }

    public void QuitGame()
    {
        Application.Quit();

    }


}
