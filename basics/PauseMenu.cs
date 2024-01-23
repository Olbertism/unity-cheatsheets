using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("keydown");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        // playerInput.actions.Disable();
        playerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("click resume");
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        // playerInput.actions.Enable();
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Demo");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}