using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    //list of quest booleans
    public bool hasKey = false;
    public bool hasFlower = false;
    public bool knowsPassword = false;
    public bool talkedToGeneral = false;
    public int shinyObjectCount = 0;
    public bool foundAllShinyObjects = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shinyObjectCount >= 5)
        {
            shinyObjectCount = 5;
            foundAllShinyObjects = true;
        }
    }
}
