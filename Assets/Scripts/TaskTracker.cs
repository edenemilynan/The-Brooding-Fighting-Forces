using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Task {truck, entry};
    public Queue<Task> taskList = new Queue<Task>();
    int N = 10;
    int truckCounter = 0;
    int entryCounter = 0;

    void Start()
    {
        Debug.Log("This is a message");
        for (int i = 0; i < N; ++i)
        {
            // Assures that there will be a good split between the tasks
            // Can change
            if(truckCounter == 6) { taskList.Enqueue(Task.entry); }
            else if(entryCounter == 6) { taskList.Enqueue(Task.truck); }
            else
            {
                Task t = (Task)Random.Range(0, 2);
                if (t == Task.truck) { ++truckCounter; }
                else { ++entryCounter; }

                taskList.Enqueue(t);
            }
        }
        // Debug lines
        /*
        while(taskList.Count != 0)
        {
            string t = taskList.Dequeue().ToString();
            Debug.Log(t);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
