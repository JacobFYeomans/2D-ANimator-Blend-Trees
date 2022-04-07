using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInteractObjScript = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInteractObjScript != null)
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        //interaction logic
        Debug.Log("this is " + currentInterObj.name);

        if(currentInteractObjScript.interType == InteractionObject.InteractableType.nothing)
        {
            currentInteractObjScript.Nothing();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.info)
        {
            currentInteractObjScript.InfoMessage();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.pickup)
        {
            currentInteractObjScript.Pickup();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.dialogue)
        {
            currentInteractObjScript.Dialogue();
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = other.gameObject;
            currentInteractObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentInterObj = null;
        currentInteractObjScript = null;
    }

}
