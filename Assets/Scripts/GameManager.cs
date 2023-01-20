using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class GameManager: MonoBehaviour
{
    [SerializeField] private GameState state;
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject pipeSpawner;
    private GameObject overCanvas = null;
    public static GameManager manager;
    public static float Difficulty
    { 
        get 
        {
            if (manager.score < 15) return manager.score / 5 + 1;
            else if (manager.score < 25) return 3.5f;
            else return 4f;
        } 
    }
    /// <summary>
    /// the actual bird that was instantiated
    /// </summary>
    private GameObject _bird = null;
    /// <summary>
    /// the actual pipeSpawner that was instantiated
    /// </summary>
    private GameObject _pipeSpawner = null;
    private int score;
    private GameObject scorePanel;
    private TMP_Text scoreText;
    
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager != this)
            Destroy(gameObject);
    }

    void Start()
    {
        state = GameState.welcome;
    }

    /// <summary>
    /// update states
    /// </summary>
    private void UpdateGameState()
    {
        switch (state)
        {
            case GameState.welcome:
                HandleWelcome();
                break;
            case GameState.play:
                HandlePlay();
                break;
            case GameState.over:
                HandleOver();
                break;
        }
    }

    private void HandleOver()
    {
        overCanvas.SetActive(true);
        Destroy(_pipeSpawner);

    }

    private void HandlePlay()
    {
        /*this parameter 'a' has to be here, even tho it was never used in following function body. I wonder why.*/
        SceneManager.LoadSceneAsync("Stage").completed += (a) =>
        {
            //Debug.Log(SceneManager.GetActiveScene().buildIndex);
            _bird = Instantiate(bird, ConfigData.birdPos, Quaternion.identity);
            _pipeSpawner = Instantiate(pipeSpawner, ConfigData.pipeSpawnerPos, Quaternion.identity);
            overCanvas = GameObject.FindGameObjectWithTag("GameOver");
            /*need some real error stuff instead of just a log*/
            if (overCanvas == null)
                Debug.Log("gameManager: " + "Cannot find any Canvas!");
            overCanvas.SetActive(false);
            scorePanel = GameObject.FindGameObjectWithTag("Score");
            scorePanel.SetActive(true);
            score = 0;
            scoreText = scorePanel.transform.Find("TextScore").gameObject.GetComponent<TMP_Text>();
            scoreText.text = score.ToString();
        };
    }

    private void HandleWelcome()
    {
        SceneManager.LoadScene("OpeningMenu");
    }    

    public void PressPlay()
    {
        state = GameState.play;
        UpdateGameState();
    }

    public void PressReplay()
    {
        state = GameState.play;
        UpdateGameState();
    }

    public void HandleBirdDeath()
    {
        state = GameState.over;
        UpdateGameState();
    }

    public void Score()
    {
        ++score;
        scoreText.text = score.ToString();
    }    
    
}

enum GameState
{
    welcome,
    play,
    over
}
