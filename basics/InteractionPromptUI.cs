using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class for UI element next to player when interaction is possible. Place on child canvas of player object. 
/// Set the canvas to render mode "World Space" and drop the main camera into the reference.
/// InteractionUIPanel can be an image, create a text as child for it. 
/// </summary>
public class InteractionPromptUI : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    void Start()
    {
        _camera = Camera.main;
        _uiPanel.SetActive(false);
    }

    void LateUpdate()
    {
        var rotation = _camera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel?.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel?.SetActive(false);
        IsDisplayed = false;
    }
}