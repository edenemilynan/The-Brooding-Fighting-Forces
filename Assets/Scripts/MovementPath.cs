using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementPath : MonoBehaviour
{
    private bool paused = false;
    private int movementDirection = 1;
    private int movingTo = 0;
    public Transform[] pathSequence;
    //public int directionStart;
    //public int directionTurn;
    //public Animator animator;
    public DialogueController dialogueController;
    public GameObject truck;
    //public TruckingController pathControl;

    // Start is called before the first frame update
    void Start()
    {
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
                    truck.GetComponent<FollowPathPeople>().currentPath += 1;
                    truck.GetComponent<Animator>().SetInteger("facing", 0);
                    paused = true;
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

        Destroy(truck);
        dialogueController.tasksCompleted += 1;
    }
}