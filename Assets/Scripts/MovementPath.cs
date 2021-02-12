using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementPath : MonoBehaviour
{
    public int movementDirection = 1;
    public int movingTo = 0;
    public Transform[] pathSequence;
    public int direction;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("facing", direction);
    }

    // Update is called once per frame
    public void OnDrawGizmos()
    {
        if(pathSequence == null || pathSequence.Length < 2)
        {
            return;
        }

        for(var i = 1; i < pathSequence.Length; i++)
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
        }

    }
}
