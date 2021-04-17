using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource altEndingMusic;
    public AudioSource defaultEndingMusic;

    public bool ending = false;

    public void Start()
    {
        if (ending)
        {
            if (SceneLoader.endingNumber == 4)
            {
                altEndingMusic.Play(0);
            }
            else defaultEndingMusic.Play(0);
        }

        videoPlayer.loopPointReached += LoadNextScene;
    }


    public void LoadNextScene(VideoPlayer vp)
    {
        if (!ending)
        {
            int nextScene = SceneLoader.chapter + 4;
            SceneManager.LoadScene(nextScene);
        }

        else 
        {
            SceneManager.LoadScene(0);
        }
    }

}