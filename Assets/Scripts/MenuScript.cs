using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //list of buttons in the menu
    public GameObject menu;
    public GameObject controlButton;
    public GameObject quitButton;
    public GameObject instructionText;
    public GameObject returnButton;
    public GameObject controlButtonGO;
    public GameObject restartButtonGO;
    public GameObject quitButtonGO;
    public GameObject instructionTextGO;
    public GameObject returnButtonGO;

    //player to disable aiming while in the menu
    public GameObject player;

    public bool isPaused = false;
    private bool instructionsOpened = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (isPaused == false)
        {
            player.GetComponent<PlayerController>().enabled = false;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = true;
        } else
        {
            player.GetComponent<PlayerController>().enabled = true;
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
        }
    }

    public void ControlsOnClick()
    {
        if (!instructionsOpened)
        {
            controlButton.SetActive(false);
            quitButton.SetActive(false);
            instructionText.SetActive(true);
            returnButton.SetActive(true);
            instructionsOpened = true;
        }
        else
        {
            controlButton.SetActive(true);
            quitButton.SetActive(true);
            instructionText.SetActive(false);
            returnButton.SetActive(false);
            instructionsOpened = false;
        }
    }

    public void ControlsOnClickGameOver()
    {
        if (!instructionsOpened)
        {
            controlButtonGO.SetActive(false);
            restartButtonGO.SetActive(false);
            quitButtonGO.SetActive(false);
            instructionTextGO.SetActive(true);
            returnButtonGO.SetActive(true);
            instructionsOpened = true;
        }
        else
        {
            controlButtonGO.SetActive(true);
            restartButtonGO.SetActive(true);
            quitButtonGO.SetActive(true);
            instructionTextGO.SetActive(false);
            returnButtonGO.SetActive(false);
            instructionsOpened = false;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

