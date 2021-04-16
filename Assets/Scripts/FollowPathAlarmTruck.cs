using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowPathAlarmTruck : MonoBehaviour
{
    public MovementPath path;
    public TruckingController pathController;
    public Animator truck;
    public InputManager manager;
    public GameObject counterPart;

    public float speed;
    public float MaxDistanceToGoal = .1f;
    public int currentPath;
    public int turn;
    public string morseLetter;

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

        if ((currentPath == pathController.pathAlarm && manager.morseCommand == morseLetter) || startedOnPath == true)
        {
            if (startedOnPath == false)
            {
                startedOnPath = true;
                manager.entryLocked = true;
                Destroy(counterPart);
                //truck.SetInteger("facing", turn);
                truck.GetComponent<Renderer>().enabled = true;
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