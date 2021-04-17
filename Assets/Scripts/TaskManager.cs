using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    //Had to add allow/disallow to allow tracking of right/wrong decisions later
    public enum Tasks {truckRight, truckLeft, truckAlarm, truckOpen, peopleAllow, peopleDisallow, sort, none, waiting};
    public Queue<Tasks> tasksTrucking = new Queue<Tasks>();
    public Queue<Tasks> tasksEntry = new Queue<Tasks>();
    public Queue<Tasks> tasksSorting = new Queue<Tasks>();
    public Tasks taskTrucking = Tasks.none;
    public Tasks taskEntry = Tasks.none;
    public Tasks taskSorting = Tasks.none;
    public int nTasks = 6;

    /* For random tasks later
    int truckCounter = 0;
    int maxTrucks = 4;
    int entryCounter = 0;
    int maxEntry = 2;
    
    */

    // T>E>TTEES>EEE>S>S>TSE>
    // Chapter 2 Queues

    // Initial Queue
    public Queue<Tasks> Ch2Queue1 = new Queue<Tasks>(new[] {Tasks.truckAlarm,
															Tasks.truckLeft});
    // Once first trucking task has been completed
    public Queue<Tasks> Ch2Queue2 = new Queue<Tasks>(new[] {Tasks.peopleDisallow});
    // Once Entryway task is complete
    public Queue<Tasks> Ch2Queue3 = new Queue<Tasks>(new[] {Tasks.truckRight,
                                                            Tasks.truckAlarm,
                                                            Tasks.truckRight,
                                                            Tasks.peopleAllow,
                                                            Tasks.peopleDisallow,
                                                            Tasks.sort});
    // Once incident report convo has happened
    public Queue<Tasks> Ch2Queue4 = new Queue<Tasks>(new[] {Tasks.peopleAllow,
                                                            Tasks.peopleDisallow,
                                                            Tasks.peopleAllow});
    // Once mediocre employee evaluation conversation is done
    public Queue<Tasks> Ch2Queue5 = new Queue<Tasks>(new[] {Tasks.sort});

    // Once Lead Lined Boxes Convo is Done
    // public Queue<Tasks> Ch2Queue6 = new Queue<Tasks>(new[] {Tasks.sort});

    //Once decision for wether to let through invalid sorting task is complete
    public Queue<Tasks> Ch2Queue7 = new Queue<Tasks>(new[] {Tasks.truckLeft,
                                                            Tasks.peopleDisallow,
                                                            Tasks.sort});
	
    // Chapter 3 Queues
	// Play intro convo
	public Queue<Tasks> Ch3Queue1 = new Queue<Tasks>(new[] {Tasks.peopleAllow,
															Tasks.peopleDisallow,
															Tasks.peopleAllow,
															Tasks.peopleDisallow});
	// Person falling over
	// public Queue<Tasks> Ch3Queue2 = new Queue<Tasks> (new[] {Tasks.none}); // Notification to go to main
	// Are you starting to see?
	public Queue<Tasks> Ch3Queue3 = new Queue<Tasks>(new[] {Tasks.sort});
	// There is a task..., go to the task, do the task
	public Queue<Tasks> Ch3Queue4 = new Queue<Tasks>(new[] {Tasks.sort});
	// Bred to convo
	public Queue<Tasks> Ch3Queue5 = new Queue<Tasks>(new[] {Tasks.truckLeft});

    // public Queue<Tasks> Ch3Queue5_1 = new Queue<Tasks>( new[] {Tasks.truckOpen} );

	// Are you having fun
	// Do the task, then knowledge is power
	public Queue<Tasks> Ch3Queue6 = new Queue<Tasks>(new[] {Tasks.truckRight,
															Tasks.peopleAllow,
															Tasks.sort});
	// They all move forward
	public Queue<Tasks> Ch3Queue7 = new Queue<Tasks>(new[] {Tasks.sort});
	// You are doing exactly what he hopes of you
	public Queue<Tasks> Ch3Queue8 = new Queue<Tasks>(new[] {Tasks.peopleDisallow});
	// You are the ideal worker
	public Queue<Tasks> Ch3Queue9 = new Queue<Tasks>(new[] {Tasks.truckRight});
	// But you are not alone.
	public Queue<Tasks> Ch3Queue10 = new Queue<Tasks>(new[] {Tasks.waiting}); // Notification to go to main
	// Bexos call
	// Weird trucking task
	public Queue<Tasks> Ch3Queue11 = new Queue<Tasks>(new[] {Tasks.truckLeft});
	//  Weird entry task
	public Queue<Tasks> Ch3Queue12 = new Queue<Tasks>(new[] {Tasks.peopleAllow});
	// Weird sorting task
	public Queue<Tasks> Ch3Queue13 = new Queue<Tasks>(new[] {Tasks.sort});

    public TruckingControls truckingControl;
    public TruckingController personApproaches;
    public TruckingController truckApproaches;
    public InputManager inputManager;

    
    // Start is called before the first frame update
    void Start()
    {   
        // Debug.Log("Testing a Queue");
        // Debug.Log(Ch2Queue3.Count);
        // for(int i = 1; i <= Ch2Queue3.Count; i++)
        // {
        //     Tasks task = Ch2Queue3.Dequeue();
        //     Debug.Log(task);
        //     Ch2Queue3.Enqueue(task);
        // }
        // Debug.Log(Ch2Queue3.Count);

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

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Chapter 1")
        {
            //Setting up chapter 1 tasks
            tasksSorting.Enqueue(Tasks.sort);
            tasksTrucking.Enqueue(Tasks.truckRight);
            tasksEntry.Enqueue(Tasks.peopleDisallow);
            tasksTrucking.Enqueue(Tasks.truckRight);
            tasksTrucking.Enqueue(Tasks.truckLeft);
            tasksEntry.Enqueue(Tasks.peopleAllow);
            tasksTrucking.Enqueue(Tasks.truckRight);
            tasksTrucking.Enqueue(Tasks.none);
            tasksEntry.Enqueue(Tasks.none);
            tasksSorting.Enqueue(Tasks.none);


            getTaskTrucking();
        }

        if (sceneName == "Chapter 2")
        {
            //Setting up chapter 2 tasks
            // tasksSorting.Enqueue(Tasks.sort);
            // tasksSorting.Enqueue(Tasks.sort);
            // tasksSorting.Enqueue(Tasks.sort);
            // tasksSorting.Enqueue(Tasks.sort);
            // tasksTrucking.Enqueue(Tasks.truckLeft);
            // tasksEntry.Enqueue(Tasks.peopleDisallow);
            // tasksTrucking.Enqueue(Tasks.truckRight);
            // tasksTrucking.Enqueue(Tasks.truckRight);
            // tasksTrucking.Enqueue(Tasks.truckLeft);
            // tasksEntry.Enqueue(Tasks.peopleAllow);
            // tasksEntry.Enqueue(Tasks.peopleDisallow);
            // tasksEntry.Enqueue(Tasks.peopleAllow);
            // tasksEntry.Enqueue(Tasks.peopleAllow);
            // tasksTrucking.Enqueue(Tasks.truckRight);
            // tasksEntry.Enqueue(Tasks.peopleDisallow);
            // tasksEntry.Enqueue(Tasks.peopleAllow);
            // tasksTrucking.Enqueue(Tasks.none);
            // tasksEntry.Enqueue(Tasks.none);
            // tasksSorting.Enqueue(Tasks.none);

            queueNewTasks(Ch2Queue1);
            getTaskTrucking();
            getTaskEntry();
            getTaskSorting();
        }

        if (sceneName == "Chapter 3")
        {
            //Setting up chapter 3 tasks
            /*tasksSorting.Enqueue(Tasks.sort);
            tasksSorting.Enqueue(Tasks.sort);
            tasksSorting.Enqueue(Tasks.sort);
            tasksSorting.Enqueue(Tasks.sort);
            tasksSorting.Enqueue(Tasks.sort);
            tasksTrucking.Enqueue(Tasks.truckLeft);
            tasksEntry.Enqueue(Tasks.peopleDisallow);
            tasksTrucking.Enqueue(Tasks.truckRight);
            tasksTrucking.Enqueue(Tasks.truckRight);
            tasksTrucking.Enqueue(Tasks.truckLeft);
            tasksEntry.Enqueue(Tasks.peopleAllow);
            tasksEntry.Enqueue(Tasks.peopleDisallow);
            tasksEntry.Enqueue(Tasks.peopleAllow);
            tasksEntry.Enqueue(Tasks.peopleAllow);
            tasksTrucking.Enqueue(Tasks.truckRight);
            tasksEntry.Enqueue(Tasks.peopleDisallow);
            tasksEntry.Enqueue(Tasks.peopleAllow);
            tasksTrucking.Enqueue(Tasks.none);
            tasksEntry.Enqueue(Tasks.none);
            tasksSorting.Enqueue(Tasks.none);*/


            getTaskTrucking();
            getTaskEntry();
            getTaskSorting();
        }

    }

    public void getTaskTrucking()
    {
        if (tasksTrucking.Count != 0)
        {
            taskTrucking = tasksTrucking.Dequeue();
            inputManager.taskWaitingTrucking = false;

            if (taskTrucking == Tasks.truckRight)
            {
                truckingControl.rightIndicatorOn();
            }

            else if (taskTrucking == Tasks.truckLeft)
            {
                truckingControl.leftIndicatorOn();
            }

            else if (taskTrucking == Tasks.truckOpen)
            {
                truckingControl.rightIndicatorOn();
            }

            else if (taskTrucking == Tasks.truckAlarm)
            {
                truckingControl.alarmIndicatorOn();
                truckApproaches.pathAlarm += 1;
            }

            /*else if (task == Tasks.peopleAllow || task == Tasks.peopleDisallow)
            {
                personApproaches.path += 1;
            }

            if (tasks.Peek() == Tasks.peopleAllow || tasks.Peek() == Tasks.peopleDisallow) 
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

        else taskTrucking = Tasks.none;
    }

    public void getTaskEntry()
    {
        if (tasksEntry.Count != 0)
        {
            taskEntry = tasksEntry.Dequeue();
            inputManager.taskWaitingEntry = false;

            if (taskEntry == Tasks.peopleAllow || taskEntry == Tasks.peopleDisallow)
            {
                personApproaches.path += 1;
            }
        }

        else taskEntry = Tasks.none;
    }

    public void getTaskSorting()
    {
        if (tasksSorting.Count != 0)
        {
            taskSorting = tasksSorting.Dequeue();
            Debug.Log("sorting dequeued");

        }

        else taskSorting = Tasks.none;
    }

    public void queueNewTasks(Queue<Tasks> newQueue)
    {
        // public Queue<Tasks> tasksTrucking = new Queue<Tasks>();
        // public Queue<Tasks> tasksEntry = new Queue<Tasks>();
        // public Queue<Tasks> tasksSorting = new Queue<Tasks>();

        Debug.Log("TIME TO QUEUE SOME NEW MF'N TASKS");
        while(newQueue.Count != 0)
        {
            Tasks task = newQueue.Dequeue();
            switch (task)
            {
                case Tasks.truckLeft:
                    tasksTrucking.Enqueue(task);
                    break;
                case Tasks.truckRight:
                    tasksTrucking.Enqueue(task);
                    break;
                case Tasks.peopleDisallow:
                    tasksEntry.Enqueue(task);
                    break;
                case Tasks.peopleAllow:
                    tasksEntry.Enqueue(task);
                    break;
                case Tasks.sort:
                    tasksSorting.Enqueue(task);
                    break;
                case Tasks.truckAlarm:
                    tasksTrucking.Enqueue(task);
                    break;
                case Tasks.truckOpen:
                    tasksTrucking.Enqueue(task);
                    break;
                case Tasks.none:
                    tasksTrucking.Enqueue(task);
                    break;
                case Tasks.waiting:
                    tasksTrucking.Enqueue(task);
                    break;
            }
        }

        // if(taskTrucking == Tasks.none) {inputManager.taskWaitingTrucking = true; Debug.Log("Fuckin' in Trucking Tasks");}
        // if(taskEntry == Tasks.none) {inputManager.taskWaitingEntry = true;}
        // if(taskSorting == Tasks.none) {inputManager.taskWaitingSorting = true;}

        // inputManager.taskWaitingTrucking = true;
        // inputManager.taskWaitingEntry = true;
        // inputManager.taskWaitingSorting = true;
        
        Debug.Log(tasksEntry.Count);

        //getTaskTrucking();
        //getTaskEntry();
        //getTaskSorting();
        

        // tasksTrucking.Enqueue(Tasks.none);
        // tasksEntry   .Enqueue(Tasks.none);
        // tasksSorting .Enqueue(Tasks.none);

        // getTaskTrucking();
        // getTaskEntry();
        // getTaskSorting();
    }

}
