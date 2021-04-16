using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowPathTruck : MonoBehaviour
{
    public MovementPath path;
    public TruckingController pathController;
    public Animator truck;
    public GameObject truck1;

    public float speed;
    public float MaxDistanceToGoal = .1f;
    public int currentPath;
    public int turn;
    public int facing;

    public bool truckOpen;
    public InputManager inputManager;

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
        if (!truckOpen)
        {
            if (currentPath == pathController.pathAlarm)
            {

                if (truckOpen)
                {
                    inputManager.truckingRightLocked = true;
                }

                if ((currentPath % 2) == 0 && pathChanged == false)
                {
                    truck.SetInteger("facing", turn);
                    pathChanged = true;
                    truck1.GetComponent<Renderer>().enabled = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

                var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
                if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
                {
                    //truck.SetInteger("facing", turn);
                    //person.SetInteger("facing", 0);
                    pointInPath.MoveNext();

                }
            }
        }

        else
        {
            if (currentPath == pathController.pathOpen)
            {

                if (truckOpen)
                {
                    inputManager.truckingRightLocked = true;
                }

                if ((currentPath % 2) == 0 && pathChanged == false)
                {
                    truck.SetInteger("facing", turn);
                    pathChanged = true;
                    truck1.GetComponent<Renderer>().enabled = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

                var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
                if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
                {
                    //truck.SetInteger("facing", turn);
                    //person.SetInteger("facing", 0);
                    pointInPath.MoveNext();

                }
            }
        }
        
    }

}
