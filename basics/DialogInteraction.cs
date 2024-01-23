using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        // We can do checks here to see if we really want to return true

        // If all is good, return true
        Debug.Log("Starting Dialog");
        return true;
    }
}