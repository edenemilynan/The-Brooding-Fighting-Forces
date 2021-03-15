using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public Sprite[] notifSprites;
    public SpriteRenderer spriteRend = null;

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
            if (task == TaskManager.Tasks.truck && camera != "truck")
            {
                ChangeSprite('t');
            }
            else if ((task == TaskManager.Tasks.peopleAllow || task == TaskManager.Tasks.peopleDisallow) && camera != "entry")
            {
                ChangeSprite('e');
            }
            else
                ChangeSprite('0');
        }
        else
        {
            if (task == TaskManager.Tasks.truck)
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
                break;
            case 'e':
                Debug.Log(c);
                spriteRend.sprite = notifSprites[0];
                break;
            case 't':
                Debug.Log(c);
                spriteRend.sprite = notifSprites[1];
                break;
            case 'm':
                Debug.Log(c);
                spriteRend.sprite = notifSprites[2];
                break;
            default:
                break;
        }


      

    }
}
