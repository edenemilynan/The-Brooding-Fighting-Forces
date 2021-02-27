﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private Queue<string> tasks = new Queue<string>();
    public string task = null;
    
    // Start is called before the first frame update
    void Start()
    {
        //For intro it might make sense to hard code the first
        //task or two, and then randomize the rest
        tasks.Enqueue("truck");
        tasks.Enqueue("people");
        tasks.Enqueue("truck");
        task = tasks.Dequeue();
    }

    public void GetTask()
    {
        if (tasks.Count != 0)
        {
            task = tasks.Dequeue();
            //Good place to trigger light above door that indicates task is waiting
        }

        else task = null;
    }

}