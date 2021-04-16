using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System;

public class MovementPath : MonoBehaviour
{
    private bool paused = false;
    private int movementDirection = 1;
    private int movingTo = 0;
    private int taskNumber = 1;
    public Transform[] pathSequence;

    //Making a centralized location for all triggers to reside.
    public TriggerManager triggerManager;

    public DialogueController dialogueController;
    public GameObject truck;
    public InputManager inputManager;
    public InputManager truckingInputManager;

    public FollowPathPeople pathPeople;
    public FollowPathTruck pathTruck;

    public bool openTruck;

    public TaskManager taskManager; 

    //public TruckingController pathControl;

    // Start is called before the first frame update
    void Start()
    {
        GameObject triggerManagerObj = GameObject.Find("/TriggerManager");
        if (triggerManagerObj != null)
        {
            triggerManager = triggerManagerObj.GetComponent<TriggerManager>();
        }
        //animator.SetInteger("facing", directionStart);
        //GameObject conversation = GameObject.Find("DialogueController");
        //DialogueController conversationScript = (DialogueController)conversation.GetComponent<DialogueController>();
    }

    // Update is called once per frame
    public void OnDrawGizmos()
    {
        if (pathSequence == null || pathSequence.Length < 2)
        {
            return;
        }

        for (var i = 1; i < pathSequence.Length; i++)
        {
            Gizmos.DrawLine(pathSequence[i - 1].position, pathSequence[i].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (pathSequence == null || pathSequence.Length < 1)
        {
            yield break;
        }

        while (movingTo < pathSequence.Length)
        {
            yield return pathSequence[movingTo];

            if (pathSequence.Length == 1)
            {
                continue;
            }

            movingTo = movingTo + movementDirection;

            if (pathSequence.Length == 3)
            {
                if (movingTo == 2 && paused == false)
                {
                    if (pathPeople != null)
                    {
                        pathPeople.currentPath += 1;
                        truck.GetComponent<Animator>().SetInteger("facing", pathPeople.turn);
                    }
                    else
                    {
                        pathTruck.currentPath += 1;
                        truck.GetComponent<Animator>().SetInteger("facing", pathTruck.turn);
                    }
                        //truck.GetComponent<Animator>().SetInteger("facing", turn);
                        taskNumber = 0;
                    paused = true;
                    if (inputManager != null)
                    {
                        inputManager.scannable = true;
                    }    
                }
            }
            

            /*if (movingTo == pathSequence.Length - 1)
            {
                animator.SetInteger("facing", directionTurn);
            }*/

            //if (movingTo == pathSequence.Length)
            //{
                
                //int path = truckingPath.path;
                //truckingPath.path = (path + 1);
            //}
    
        }

        if (inputManager != null)
        {
            inputManager.entryLocked = false;
        }

        else
        {
            if (taskManager.taskTrucking == TaskManager.Tasks.truckRight || taskManager.taskTrucking == TaskManager.Tasks.truckAlarm)
            {
                truckingInputManager.truckingRightLocked = false;
            }
            else truckingInputManager.truckingLeftLocked = false;
        }

        string name = truck.name.Substring(0,5);
        Debug.Log(name);
        Destroy(truck);
        Debug.Log("entryTaskTimer = " + triggerManager.entryTaskTimer);
        if(name == "truck" && taskNumber != 0)
        {
            Debug.Log("See ya Truck!");
            triggerManager.truckTasksCompleted++;
        }
        else if(triggerManager.entryTaskTimer == 0 && taskNumber != 0)
        {
            Debug.Log("See ya Person!");
            triggerManager.scannerTasksCompleted++;
            triggerManager.resetEntryTaskTimer();
        }
        
        dialogueController.tasksCompleted += taskNumber;
        if (taskNumber != 0)
        {
            triggerManager.tasksCompleted += 1;
        }
        

    }
}
