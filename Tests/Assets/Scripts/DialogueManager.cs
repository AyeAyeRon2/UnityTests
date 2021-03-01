using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    [HideInInspector] public DialogueTrigger dialogueTriggerScript;

    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
        dialogueTriggerScript = FindObjectOfType<DialogueTrigger>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true); // start dialogue
        nameText.text = dialogue.NPCName; // makes the NPC name the name in the inpector 
        sentences.Clear(); // clears all previous sentences
        // puts sentences in a queue/order
        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence(); // after the first dialogue is completed, dipsplays the next sentence
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(); // calls end method when number of sentences is 0/no sentences left
            return;
        }

        string sentence = sentences.Dequeue(); // removes the last sentence
        StopAllCoroutines(); // stop coroutine
        StartCoroutine(TypeSentence(sentence)); // begins coroutine again
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; // variable for text
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; // add letter individually to variable for text
            yield return null; // when finished returns null
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        dialogueTriggerScript.dialogueOpen = false;
    }

    public void Update()
    {
        Debug.Log(sentences.Count);
    }
}
