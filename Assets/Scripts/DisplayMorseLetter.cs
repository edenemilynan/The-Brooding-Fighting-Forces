using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMorseLetter : MonoBehaviour
{
    public TextMeshProUGUI morseText;
    private string morseLetter;

    // Update is called once per frame
    void Update()
    {
        GameObject morseInput = GameObject.Find("MorseInputs");
        SpaceBarInput input = (SpaceBarInput)morseInput.GetComponent<SpaceBarInput>();
        morseLetter = input.GetCurrentMorseLetter();

        if (morseLetter != null)
        {
            morseText.text = morseLetter;
        }
    }
}
