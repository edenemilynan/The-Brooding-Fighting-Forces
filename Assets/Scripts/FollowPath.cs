using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowPath : MonoBehaviour
{
    public MovementPath path;
    public float speed = 1;
    public float MaxDistanceToGoal = .1f;
    public int currentPath;
    private IEnumerator<Transform> pointInPath;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject thePath = GameObject.Find("Path_0");
        //MovementPath movementScript = thePath.GetComponent<MovementPath>();
        //self.transform.position = new Vector3(168, -352, 50);
        pointInPath = path.GetNextPathPoint();
        pointInPath.MoveNext();

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject thePlayer = GameObject.Find("ThePlayer");
        //PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();
        //playerScript.Health -= 10.0f;

        GameObject theController = GameObject.Find("TruckingController");
        TruckingController controllerScript = theController.GetComponent<TruckingController>();

        if (currentPath == controllerScript.path)
        {
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
