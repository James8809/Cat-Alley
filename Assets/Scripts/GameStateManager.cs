using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public int lives = 4;
    public int score = 0;
    public Text scoreText;
    public int points;
    public GameObject player;
    public GameObject gameOverMenu;
    public GameObject canvas;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public float AlleySpeed = 15f;
    public float maxSpeed;
    public float speedAdd;
    private string scoreTextValue;
    private float time;

    private void Start() {
        FindObjectOfType<resetTracker>().Spawn();
        player.GetComponent<PlayerController>().enabled = true;
    }
    void Update()
    {
        if(lives <= 0){
            gameOver();
        } 
        scoreTextValue = "Score: " + score;
        scoreText.text = scoreTextValue;

        this.checkHeart();
        this.addSpeed();
    }
    public void addScore(){
        score += points;
    }

    public void minusLive(){
        lives--;
    }

    public void addSpeed(){
        if (canvas.GetComponent<MenuScript>().isPaused && AlleySpeed < maxSpeed){
        } else{
            time+= Time.deltaTime;
            if(time>10){
                AlleySpeed += speedAdd;
                time = 0;
                Debug.Log("faster");
            }
        }
    }
    public void checkHeart(){
        if (lives == 3){
            heart4.enabled = false;
        }
        if (lives == 2){
            heart3.enabled = false;
        }
        if (lives == 1){
            heart2.enabled = false;
        }
        if (lives == 0){
            heart1.enabled = false;
        }
    }

    public void restart(){
        SceneManager.LoadScene("prototype");
    }

    public void gameOver(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<PlayerController>().enabled = false;
        gameOverMenu.SetActive(true);
    }
}
