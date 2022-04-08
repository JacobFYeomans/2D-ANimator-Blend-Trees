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

    public enum CharacterType
    {
        nothing,
        boy,
        girl,
        general,
        solider,
        helmet
    }

    [Header("Type of interactable")]
    public InteractableType interType;

    [Header("Type of character")]
    public CharacterType charType;

    [Header("Simple info Message")]
    public string infoMessage;
    private Text infoText;

    [Header("Conditional Dialogue Text: Before")]
    [TextArea]
    public string[] conSentencesBefore;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentences;

    [Header("Conditional Dialogue Text: After")]
    [TextArea]
    public string[] conSentencesAfter;

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
        GameObject.Find("QuestManager").GetComponent<QuestManager>().shinyObjectCount++;

    }

    public void Dialogue()
    {
        switch (charType)
        {
            case CharacterType.nothing:
                //this shouldn't happen
                break;

            case CharacterType.boy:
                if (GameObject.Find("QuestManager").GetComponent<QuestManager>().hasKey == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesAfter);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().questOver = true;
                }
                else
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().talkedToBoy = true;
                }
                break;

            case CharacterType.girl:
                if (GameObject.Find("QuestManager").GetComponent<QuestManager>().foundAllShinyObjects == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesAfter);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().directedToGeneral = true;
                }
                else if (GameObject.Find("QuestManager").GetComponent<QuestManager>().talkedToBoy == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().shinyQuestStarted = true;
                }
                else
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesBefore);
                }
                break;

            case CharacterType.general:
                if (GameObject.Find("QuestManager").GetComponent<QuestManager>().generalAwake == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesAfter);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().hasKey = true;
                }
                else if (GameObject.Find("QuestManager").GetComponent<QuestManager>().directedToGeneral == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().talkedToGeneral = true;
                }
                else
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesBefore);
                }
                break;

            case CharacterType.solider:
                if (GameObject.Find("QuestManager").GetComponent<QuestManager>().soldierCalledGen == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesAfter);
                }
                else if (GameObject.Find("QuestManager").GetComponent<QuestManager>().talkedToGeneral == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().generalCalled++;
                }
                else
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesBefore);
                }
                break;

            case CharacterType.helmet:
                if (GameObject.Find("QuestManager").GetComponent<QuestManager>().helmentCalledGen == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesAfter);
                }
                else if (GameObject.Find("QuestManager").GetComponent<QuestManager>().talkedToGeneral == true)
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
                    GameObject.Find("QuestManager").GetComponent<QuestManager>().generalCalled++;
                }
                else
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(conSentencesBefore);
                }
                break;
        }
        //GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(sentences);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}
