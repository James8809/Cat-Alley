using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //list of buttons in the menu
    public GameObject menu;
    public GameObject playButton;
    public GameObject restartButton;
    public GameObject controlButton;
    public GameObject exitButton;
    public GameObject instructionText;
    public GameObject returnButton;

    //player to disable aiming while in the menu
    public GameObject player;

    public bool isPaused = true;
    private bool instructionsOpened = false;
    public GameStateManager gameState;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
        instructionText.SetActive(false);
        returnButton.SetActive(false);
        player.GetComponent<PlayerController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameState.gameNotStart)
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
        } else {
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
            playButton.SetActive(false);
            restartButton.SetActive(false);
            controlButton.SetActive(false);
            exitButton.SetActive(false);
            instructionText.SetActive(true);
            returnButton.SetActive(true);
            instructionsOpened = true;
        } else {
            if(!isPaused) restartButton.SetActive(true);
            if(FindObjectOfType<GameStateManager>().gameNotStart) playButton.SetActive(true);
            controlButton.SetActive(true);
            exitButton.SetActive(true);
            instructionText.SetActive(false);
            returnButton.SetActive(false);
            instructionsOpened = false;
        }
    }

    public void PlayGame(){
        playButton.SetActive(false);
        ToggleMenu();
        gameState.startGame();

    }

    public void RestartGame(){
        gameState.restart();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

