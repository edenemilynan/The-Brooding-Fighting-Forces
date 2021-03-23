using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class DialogueAudioPlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip  knockSound;
    public AudioClip  hitSound;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayDialogueSound(int audioCode, float volume = 0.7F)
    {
        AudioClip currentSound;

        if(audioCode == 0){return;}
        
        currentSound = convertAudioCodeToAudioClip(audioCode);
        //Get sound to be played from the passed in value (possibly the link to an audio file, or just an int to represent what audio file to play.)
        audioSource.PlayOneShot(currentSound, volume);
    }

    private AudioClip convertAudioCodeToAudioClip(int audioCode)
    {
        // 0 - No Sound
        // 1 - Knock Sound
        // 2 - Hit Sound

        switch (audioCode)
        {
            case 1:
                return knockSound;
                break;
            case 2:
                return hitSound;
                break;
        }

        return knockSound;        
    }


}
