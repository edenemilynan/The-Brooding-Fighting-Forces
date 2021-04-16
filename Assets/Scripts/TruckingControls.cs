using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckingControls : MonoBehaviour
{
    public Animator rightTruckingDoor;
    public Animator leftTruckingDoor;
    public Animator ramp;
    public Animator indicatorLeft;
    public Animator indicatorRight;
    public Animator alarm;
    public AudioClip doorSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rightTruckingDoor.SetBool("isHighlighted", true);
    }

    public void leftIndicatorOn()
    {
        if (indicatorLeft.GetBool("indicatorOn") != true)
        {
            indicatorLeft.SetBool("indicatorOn", true);
        }
    }

    public void leftIndicatorOff()
    {
        if (indicatorLeft.GetBool("indicatorOn") != false)
        {
            indicatorLeft.SetBool("indicatorOn", false);
        }
    }

    public void rightIndicatorOn()
    {
        if (indicatorRight.GetBool("indicatorOn") != true)
        {
            indicatorRight.SetBool("indicatorOn", true);
        }
    }

    public void rightIndicatorOff()
    {
        if (indicatorRight.GetBool("indicatorOn") != false)
        {
            indicatorRight.SetBool("indicatorOn", false);
        }
    }

    public void rampActivate()
    {
        if (ramp.GetBool("rampDown") != true)
        {
            ramp.SetBool("rampDown", true);
        }
        else ramp.SetBool("rampDown", false);
    }

    public void truckLeftOpen()
    {
        if (leftTruckingDoor.GetBool("isTruckingOpen") != true)
        {
            leftTruckingDoor.SetBool("isTruckingOpen", true);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void truckLeftClose()
    {
        if (leftTruckingDoor.GetBool("isTruckingOpen") != false)
        {
            leftTruckingDoor.SetBool("isTruckingOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void truckRightOpen()
    {
        if (rightTruckingDoor.GetBool("isTruckingOpen") != true)
        {
            rightTruckingDoor.SetBool("isTruckingOpen", true);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void truckRightClose()
    {
        if (rightTruckingDoor.GetBool("isTruckingOpen") != false)
        {
            rightTruckingDoor.SetBool("isTruckingOpen", false);
            audioSource.PlayOneShot(doorSound, 0.7F);
        }
    }

    public void switchHighlight()
    {
        if (rightTruckingDoor.GetBool("isHighlighted") == true)
        {
            rightTruckingDoor.SetBool("isHighlighted", false);
            leftTruckingDoor.SetBool("isHighlighted", true);
        }
        else
        {
            rightTruckingDoor.SetBool("isHighlighted", true);
            leftTruckingDoor.SetBool("isHighlighted", false);
        }
    }

    public void playAlarm()
    {
        alarm.SetBool("visible", true);
    }

    public void resetAlarm()
    {
        alarm.SetBool("visible", false);
    }

}
