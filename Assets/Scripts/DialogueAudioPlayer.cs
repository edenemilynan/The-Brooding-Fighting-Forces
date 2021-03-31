using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class DialogueAudioPlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip  knockSound;
    public AudioClip  hitSound;
	public AudioClip  dialogueAdvanceDaw;

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
		// 3 - dialogueAdvanceDaw

        switch (audioCode)
        {
            case 1:
                return knockSound;
            case 2:
                return hitSound;
			case 3:
				return dialogueAdvanceDaw;
        }

        return knockSound;        
    }


}
