using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool UseEvents;
    public string prompt;
    public virtual string OnLook()
    {
        return prompt;
    }
    public void BaseInteract()
    {
        if(UseEvents)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        }

        Interact();
    }
    protected virtual void Interact()
    {

    }

}
