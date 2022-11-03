using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour
{
    // varables.
    public Vector3 lastCheckPoint; //lets the start point of the player be chosen
    public Transform startPos;
    public GameObject player;

    
   
    

    //parts that apply to UI
    static public bool paused = false;
    static public bool gameOver = false;
    public GameObject endGame;

    //Array
    public GameObject pauseMenu;
    

    //starts before first playthrough
    void Start()
    {
        Time.timeScale = 1f;
        //sends player to start point
        lastCheckPoint = startPos.position;
        player.transform.position = lastCheckPoint;
                
        pauseMenu.SetActive(false);
        player.SetActive(true);
        gameOver = false;
    }


     

    //Pause game when Menue open Code
    public void PauseMenu() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Unpause() //will unpause the game when the menu is closed.
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    //When "esc" key pressed UI menu opens
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseMenu();
            }
            else
            {
                Unpause();
            }
        }
    }
      
    //UI Quit to menu button 
    public void QuitToMenu() //will change the game to the quit to menu is clicked.
    {
        SceneManager.LoadScene("MainMenu");
    }

    //UI quite game button
    public void QuitGame()
    {
        Application.Quit();
    }

    //UI Start Main Game 
    public void StartGame() 
    {
        
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Debug.Log("gameloaded");
    }

    public void GameOver() //will change the game to the quit to menu is clicked and end the game.
    {
        endGame.SetActive(true);
        player.SetActive(false);
        gameOver = true;         
    }
}


