using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMorseLetter : MonoBehaviour
{
    public Animator ditsAndDaws;
    private string morseLetter;

    // Update is called once per frame
    void Update()
    {
        GameObject morseInput = GameObject.Find("MorseInputs");
        SpaceBarInput input = (SpaceBarInput)morseInput.GetComponent<SpaceBarInput>();
        morseLetter = input.GetCurrentMorseLetter();

        if (morseLetter == "")
        {
            ditsAndDaws.SetFloat("Blend", 14);
        }

        if (morseLetter == "---")
        {
            ditsAndDaws.SetFloat("Blend", 0);
        }

        if (morseLetter == "--")
        {
            ditsAndDaws.SetFloat("Blend", 1);
        }

        if (morseLetter == "--.")
        {
            ditsAndDaws.SetFloat("Blend", 2);
        }

        if (morseLetter == "-")
        {
            ditsAndDaws.SetFloat("Blend", 3);
        }

        if (morseLetter == "-.-")
        {
            ditsAndDaws.SetFloat("Blend", 4);
        }

        if (morseLetter == "-.")
        {
            ditsAndDaws.SetFloat("Blend", 5);
        }

        if (morseLetter == "-..")
        {
            ditsAndDaws.SetFloat("Blend", 6);
        }

        if (morseLetter == "...")
        {
            ditsAndDaws.SetFloat("Blend", 7);
        }

        if (morseLetter == "..")
        {
            ditsAndDaws.SetFloat("Blend", 8);
        }

        if (morseLetter == "..-")
        {
            ditsAndDaws.SetFloat("Blend", 9);
        }

        if (morseLetter == ".")
        {
            ditsAndDaws.SetFloat("Blend", 10);
        }

        if (morseLetter == ".-.")
        {
            ditsAndDaws.SetFloat("Blend", 11);
        }

        if (morseLetter == ".-")
        {
            ditsAndDaws.SetFloat("Blend", 12);
        }

        if (morseLetter == ".--")
        {
            ditsAndDaws.SetFloat("Blend", 13);
        }
    }
}
