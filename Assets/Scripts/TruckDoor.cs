using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDoor : MonoBehaviour
{
    public Animator truckingDoor;
    public AudioClip doorSound;
    public AudioSource audioSource;

    public void TruckDoorOpen()
    {
        if(truckingDoor.GetBool("isTruckingOpen") != true)
        {
            truckingDoor.SetBool("isTruckingOpen", true);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
        

    }

    public void TruckDoorClose()
    {
        if(truckingDoor.GetBool("isTruckingOpen") != false)
        {
            truckingDoor.SetBool("isTruckingOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }
}
