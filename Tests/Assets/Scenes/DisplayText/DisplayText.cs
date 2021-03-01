using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public string[] strings;

    public TextMeshProUGUI testText;
    private int stringValue;
    
    void Start()
    {
        stringValue = 0;
    }
    
    void Update()
    {
        testText.text = strings[stringValue];
    }

    public void NextString()
    {
        if (stringValue < 0)
        {
            stringValue++;
        }

        if (stringValue > 1)
        {

        }
        {
            stringValue = 0;
        }
    }
}
