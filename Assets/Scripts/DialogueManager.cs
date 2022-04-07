using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject player;
    public GameObject character;
    public Animator animator;

    public Queue<string> dialogue;

    private void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<playerInteraction>().enabled = false;
        character.GetComponent<Animator>().enabled = false;

        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentLine = dialogue.Dequeue();

        dialogueText.text = currentLine;
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogueText.text = "";

        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<playerInteraction>().enabled = true;
        character.GetComponent<Animator>().enabled = true;
    }
}
