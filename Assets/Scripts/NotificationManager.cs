using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public Sprite[] notifSprites;
    public SpriteRenderer spriteRend = null;
    public Animator notifBounce;

    //For Animator: 
    //Default = 0; Main = 1; Trucking = 2; Entry = 3

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeSprite('e');
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeSprite('t');
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeSprite('m');
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            ChangeSprite('0');
        }
          
    }
    */

    public void DisplayNotif(TaskManager.Tasks task, string camera)
    {
        //If not the main camera, condition on truck or entry cameraview
        if(camera != "main")
        {
            if ((task == TaskManager.Tasks.truckRight || task == TaskManager.Tasks.truckLeft) && camera != "truck")
            {
                ChangeSprite('t');
            }
            else if ((task == TaskManager.Tasks.peopleAllow || task == TaskManager.Tasks.peopleDisallow) && camera != "entry")
            {
                ChangeSprite('e');
            }
            else if (task == TaskManager.Tasks.none)
            {
                ChangeSprite('m');
            }
            else
                ChangeSprite('0');
        }
        else
        {
            if (task == TaskManager.Tasks.truckRight || task == TaskManager.Tasks.truckLeft)
            {
                ChangeSprite('t');
            }
            else if (task == TaskManager.Tasks.peopleAllow || task == TaskManager.Tasks.peopleDisallow)
            {
                ChangeSprite('e');
            }
            else
                ChangeSprite('0');
        }
        
    }


    public void ChangeSprite(char c)
    {
        switch (c)
        {
            case '0':
                Debug.Log(c);
                spriteRend.sprite = null;
                notifBounce.SetInteger("notification", 0);
                break;
            case 'e':
                Debug.Log(c);
                spriteRend.sprite = notifSprites[0];
                notifBounce.SetInteger("notification", 3);
                break;
            case 't':
                Debug.Log(c);
                spriteRend.sprite = notifSprites[1];
                notifBounce.SetInteger("notification", 2);
                break;
            case 'm':
                Debug.Log(c);
                spriteRend.sprite = notifSprites[2];
                notifBounce.SetInteger("notification", 1);
                break;
            default:
                break;
        }


      

    }
}
