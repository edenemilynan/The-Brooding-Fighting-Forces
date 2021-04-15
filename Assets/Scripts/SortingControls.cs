using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingControls : MonoBehaviour
{

    public Animator clipBoard;
    public Animator boxes;
    public Animator openBoxes;
    public bool clipBoardOpen;

    // Start is called before the first frame update
    void Start()
    {
        clipBoardOpen = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showClipBoard()
    {
        clipBoard.SetInteger("showing", 1);
        clipBoardOpen = false;
    }

    public void openClipBoard()
    {
        clipBoard.SetInteger("showing", 2);
        clipBoardOpen = true;
    }

    public void closeClipBoard()
    {
        clipBoard.SetInteger("showing", 0);
        clipBoardOpen = false;
    }

    public void sendBoxes()
    {
        //hideOpenBoxes();
        boxes.SetBool("ready", true);
    }

    /*public void hideOpenBoxes()
    {
        openBoxes.SetBool("visible", false);
    }*/
}
