using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [HideInInspector] public DialogueManager dialogueManager;

    public Dialogue dialogue;

    [HideInInspector] public bool dialogueOpen;

    void Start()
    {
        dialogueOpen = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        // when dialogue is not active and E is pressed
       if (dialogueOpen == false && Input.GetKeyDown(KeyCode.E))
       {
           dialogueManager.StartDialogue(dialogue); // calls the method to start dialogue
           dialogueOpen = true;
           return;
       }

        if (dialogueOpen == true && Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.EndDialogue();
        }
    }
}
