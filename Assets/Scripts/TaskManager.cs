using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //Had to add allow/disallow to allow tracking of right/wrong decisions later
    public enum Tasks {truck, peopleAllow, peopleDisallow, none};
    public Queue<Tasks> tasks = new Queue<Tasks>();
    public Tasks task = Tasks.none;
    public int nTasks = 6;

    /* For random tasks later
    int truckCounter = 0;
    int maxTrucks = 4;
    int entryCounter = 0;
    int maxEntry = 2;
    
    */


    public Animator indicator;
    public TruckingController personApproaches;
    public InputManager manager;

    
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
        tasks.Enqueue(Tasks.peopleDisallow);
        tasks.Enqueue(Tasks.truck);
        tasks.Enqueue(Tasks.truck);
        tasks.Enqueue(Tasks.peopleAllow);
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
            manager.taskWaiting = false;

            if (task == Tasks.truck)
            {
                indicator.SetBool("IndicatorOn", true);
            }

            if (task == Tasks.peopleAllow || task == Tasks.peopleDisallow)
            {
                personApproaches.path += 1;
            }

            /*if (tasks.Peek() == Tasks.peopleAllow || tasks.Peek() == Tasks.peopleDisallow) 
            {

                if (manager.entryLeftOpen == false && manager.entryRightOpen == false)
                {
                    task = tasks.Dequeue();
                    manager.taskWaiting = false;
                    personApproaches.path += 1;
                }
            }

            if (tasks.Peek() == Tasks.truck)
            {
                if (manager.truckingLeftOpen == false && manager.truckingRightOpen == false)
                {
                    task = tasks.Dequeue();
                    indicator.SetBool("IndicatorOn", true);
                }
            }*/

            //Good place to trigger light above door that indicates task is waiting
            /*if (task == Tasks.truck)
            {
                indicator.SetBool("IndicatorOn", true);
            }

            if (task == Tasks.people)
            {
                personApproaches.path += 1;
            }*/
        }

        else task = Tasks.none;
    }

}
