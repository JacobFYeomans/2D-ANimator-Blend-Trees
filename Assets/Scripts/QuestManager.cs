using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    //list of quest booleans
    public int shinyObjectCount = 0;
    public bool talkedToBoy = false;
    public bool shinyQuestStarted = false;
    public bool foundAllShinyObjects = false;
    public bool directedToGeneral = false;
    public bool talkedToGeneral = false;
    public bool soldierCalledGen = false;
    public bool helmentCalledGen = false;
    public int generalCalled = 0;
    public bool generalAwake = false;
    public bool hasKey = false;
    public bool questOver = false;

    public GameObject winscreen;
    public GameObject player;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shinyObjectCount >= 5 || shinyQuestStarted)
        {
            shinyObjectCount = 5;
            foundAllShinyObjects = true;
        }
        if(generalCalled >= 2)
        {
            generalCalled = 2;
            generalAwake = true;
        }

        if (questOver)
        {
            winscreen.SetActive(false);
            player.GetComponent<PlayerMovement_2D>().enabled = false;
            player.GetComponent<playerInteraction>().enabled = false;
            character.GetComponent<Animator>().enabled = false;
        }
    }
}
