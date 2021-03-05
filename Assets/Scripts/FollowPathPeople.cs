using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowPathPeople : MonoBehaviour
{
    public MovementPath path;
    public TruckingController pathController;
    public Animator person;

    public float speed;
    public float MaxDistanceToGoal = .1f;
    public int currentPath;
    public int turn;

    private IEnumerator<Transform> pointInPath;
    private bool pathChanged = false;

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

            if ((currentPath % 2) == 0 && pathChanged == false)
            {
                person.SetInteger("facing", turn);
                pathChanged = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

            var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            {
                //truck.SetInteger("facing", turn);
                //person.SetInteger("facing", 0);
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

        //else person.SetInteger("facing", 0);



    }

}
