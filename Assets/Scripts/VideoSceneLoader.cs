using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public void Start()
    {
        videoPlayer.loopPointReached += LoadNextScene;

    }


    public void LoadNextScene(VideoPlayer vp)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

}