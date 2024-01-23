using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Place on the player object. The player object needs an InteractionPoint object (empty) and a Prompt UI (canvas)
/// as childs. Additionally create a Layer which is later assigned to all objects that the player should be able to
/// interact with.
/// </summary>
public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableLayerMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableLayerMask);
        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("Interact");
                    _interactable.Interact(this);
                }
            }

        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }
}
