using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    public enum InteractableType
    {
        nothing, //default
        info, //give info abt itself
        pickup, //can be picked up
        dialogue //obj has dialogue
    }

    [Header("Type of interactable")]
    public InteractableType interType;

    [Header("Simple info Message")]
    public string infoMessage;
    private Text infoText;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentences;

    public void Start()
    {
        infoText = GameObject.Find("infoText").GetComponent<Text>();
    }

    public void Nothing()
    {
        Debug.LogWarning("Object " + this.gameObject.name + " has no type set.");
    }

    public void InfoMessage()
    {
        infoText.text = infoMessage;
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
    }

    public void Pickup()
    {
        this.gameObject.SetActive(false);
    }

    public void Dialogue()
    {
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}
