using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Text heightText;
    public int gameOverHeight = 10;

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject inGameMenu;
    public TextMeshProUGUI difficultyText;

    public GameObject playerEasy;
    public GameObject playerNormal;
    public GameObject playerHard;


    public void UpdateHeightText(int height)
    {
        heightText.text = "Height: " + height.ToString();
        if (height >= gameOverHeight)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        inGameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        inGameMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        inGameMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficulty(int level)///difficulty level 1-easy 2-normal 3-hard
    {
        switch (level)
        {
            case 1: //easy
                difficultyText.text = "easy";
                break;
            case 2: //normal
                difficultyText.text = "normal";
                break;
            case 3: //hard
                difficultyText.text = "hard";
                break;
        }
    }
}
