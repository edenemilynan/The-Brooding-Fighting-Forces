using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowPathPeopleInvisible : MonoBehaviour
{
    public MovementPath path;
    public TruckingController pathController;
    public Animator person;
    public InputManager manager;
    public GameObject counterPart;

    public float speed;
    public float MaxDistanceToGoal = .1f;
    public int currentPath;
    public int turn;
    public int door;

    public bool startedOnPath = false;

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

        if ((currentPath == pathController.path && door == manager.whichEntryDoor) || startedOnPath == true)
        {
            if (startedOnPath == false)
            {
                startedOnPath = true;
                manager.entryLocked = true;
                Destroy(counterPart);
                person.SetInteger("facing", turn);
                person.GetComponent<Renderer>().enabled = true;
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
