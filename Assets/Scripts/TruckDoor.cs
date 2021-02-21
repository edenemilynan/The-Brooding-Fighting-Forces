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
        truckingDoor.SetBool("isTruckingOpen", true);
        audioSource.PlayOneShot(doorSound, 0.7F);

    }

    public void TruckDoorClose()
    {
        truckingDoor.SetBool("isTruckingOpen", false);
        audioSource.PlayOneShot(doorSound, 0.7F);
    }
}
