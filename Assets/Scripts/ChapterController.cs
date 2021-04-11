using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterController : MonoBehaviour
{
    public Animator truck0;
    public Animator truck1;
    public Animator truck2;
    public Animator truck3;
    public Animator sNotif;
    public Animator eNotif;
    public Animator tNotif;
    public Animator mNotif;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
      
        if (currentScene.name == "Chapter 2")
        {
            truck0.SetInteger("chapter", 2);
            truck1.SetInteger("chapter", 2);
            truck2.SetInteger("chapter", 2);
            truck3.SetInteger("chapter", 2);
            mNotif.SetInteger("chapter", 2);
            eNotif.SetInteger("chapter", 2);
            tNotif.SetInteger("chapter", 2);
            sNotif.SetInteger("chapter", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
