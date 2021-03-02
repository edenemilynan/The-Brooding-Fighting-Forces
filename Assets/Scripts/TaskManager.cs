using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public enum Tasks {truck, people, none};
    private Queue<Tasks> tasks = new Queue<Tasks>();
    public Tasks task = Tasks.none;
    public int nTasks = 6;

    /* For random tasks later
    int truckCounter = 0;
    int maxTrucks = 4;
    int entryCounter = 0;
    int maxEntry = 2;
    
    */


    public Animator indicator;
    
    // Start is called before the first frame update
    void Start()
    {
        //For intro it might make sense to hard code the first
        //task or two, and then randomize the rest

        /* For random tasks later
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
        */
        // For demo 1: 6 tasks (4/2 split)
        tasks.Enqueue(Tasks.truck);
        tasks.Enqueue(Tasks.people);
        tasks.Enqueue(Tasks.truck);
        tasks.Enqueue(Tasks.truck);
        tasks.Enqueue(Tasks.people);
        tasks.Enqueue(Tasks.truck);

        //Randomized
        task = tasks.Dequeue();
        //This only works if first task is hard-coded as truck
        indicator.SetBool("IndicatorOn", true);
    }

    public void GetTask()
    {
        if (tasks.Count != 0)
        {
            task = tasks.Dequeue();
            //Good place to trigger light above door that indicates task is waiting
            if (task == Tasks.truck)
            {
                indicator.SetBool("IndicatorOn", true);
            }
        }

        else task = Tasks.none;
    }

}
