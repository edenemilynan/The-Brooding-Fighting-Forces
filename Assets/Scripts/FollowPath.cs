using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowPath : MonoBehaviour
{
    public MovementPath path;
    public float speed = 1;
    public float MaxDistanceToGoal = .1f;
    public TruckingController pathController;
    public int currentPath;
    //public int turn;

    //public Animator actor;
    private IEnumerator<Transform> pointInPath;

    // Start is called before the first frame update
    void Start()
    {
        pointInPath = path.GetNextPathPoint();
        pointInPath.MoveNext();

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentPath == pathController.path)
        {

            if ((currentPath % 2) == 0)
            {
                //truck.SetInteger("facing", turn);
            }

            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

            var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            {
                //truck.SetInteger("facing", turn);
                pointInPath.MoveNext();

            }
            /*if (transform.position == pointInPath.Current.position)
            {
                Destroy(gameObject);
            }*/
            /*else
            {
                if (movementScript.movingTo > movementScript.pathSequence.Length)
                {
                    controllerScript.path = controllerScript.path + 1;
                }
                
            }*/
        }



    }

}
