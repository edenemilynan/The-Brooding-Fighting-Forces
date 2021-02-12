using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMorseLetter : MonoBehaviour
{
    public TextMeshProUGUI morseText;
    public TextMeshProUGUI morseText2;
    public TextMeshProUGUI morseText3;
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
            morseText2.text = morseLetter;
            morseText3.text = morseLetter;
        }
    }
}
