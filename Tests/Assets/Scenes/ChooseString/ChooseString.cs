using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseString : MonoBehaviour
{
    private bool firstTime;

    [Header ("Text")]
    public TextMeshProUGUI text;
    
    [Header ("Greetings")]
    [TextArea(3, 10)]
    public string[] greetingSentences;
    
    [Header ("Body")]
    [TextArea(3, 10)]
    public string[] bodySentences;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (firstTime)
            {
                FirstTimeText();
            }

            else
            {
                PresentText();
            }
            //int index = Random.Range(0, sentences.Length);
            //text.text = sentences[index];
        }
    }
    void FirstTimeText()
    {
        text.text = greetingSentences[0];
    }

    void FirstTalkComplete()
    {
        firstTime = false;
    }

    void PresentText()
    {

    }
}
