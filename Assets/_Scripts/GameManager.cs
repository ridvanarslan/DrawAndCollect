using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private UI uiManager;
    [SerializeField] private AudioManager audioManager;

    private int _score;
    private int _bestScore;
    

    private void Start()
    {
        Time.timeScale = 0;
        GetBestScore();
    }

    public void ScoreHappened()
    {
        audioManager.ScoreSound.Play();
        ballSpawner.CanSpawnBall = true;
        lineDrawer.DestroyCreatedLines();
        lineDrawer.UpdateDrawAmount(5);
        _score++;
        
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        uiManager.PanelController(false, 0);
        uiManager.PanelController(true, 2);
        
        ballSpawner.StartSpawningBalls();
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void GameOver()
    {
        ballSpawner.CanSpawnBall = false;
        
        uiManager.PanelController(true, 1);
        uiManager.PanelController(false, 2);

        uiManager.UpdateScoreText(_bestScore,1);
        uiManager.UpdateScoreText(_score,2);
        audioManager.GameOverSound.Play();
        if (_bestScore < _score)
        {
            SetBestScore(_score);
        }
        SetBestScore(_score);
    }

    public void QuitGame() => Application.Quit();
    private void GetBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            _bestScore = PlayerPrefs.GetInt("BestScore");
            uiManager.UpdateScoreText(_bestScore, 0);
        }
        else
        {
            uiManager.UpdateScoreText(0, 0);
        }
    }
    private void SetBestScore(int score) => PlayerPrefs.SetInt("BestScore", score);
    
    
}