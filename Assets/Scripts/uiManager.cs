using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Button [] buttons;
    public Text scoreText;
    bool gameOver;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("ScoreUpdate", 1.0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score :" + score;
        print(score);
    }

    void ScoreUpdate()
    {   if(gameOver == false)
        {
            score += 1;
        }
       
    }

    public void GameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons) {
            button.gameObject.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("level1");

    }
    public void Restart()
    {
        SceneManager.LoadScene("level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
    }
}
