using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{

    public Animator boxes;
    public Animator openBoxes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBoxes()
    {
        boxes.SetBool("ready", false);
    }

    public void newBoxes()
    {
        openBoxes.SetBool("visible", true);
    }
}
