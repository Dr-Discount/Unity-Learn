using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool debug = false;
    [SerializeField] float restartDelay = 2.0f;

    static TankGameManager instance;
    public static TankGameManager Instance { 
        get {
            if (instance == null) instance = FindFirstObjectByType<TankGameManager>();
            return instance; 
        } 
    }

    public int Score { get; set; } = 0;
    void Start()
    {
        instance = FindFirstObjectByType<TankGameManager>();
        Time.timeScale = (debug) ? 1.0f : 0.0f;   
        titlePanel.SetActive(!debug);
    }

    void Update()
    {
        scoreText.text = Score.ToString();
    }

    public void OnGameStart()
    {
        print("start Game");
        titlePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void onGameWin()
    {
        print("you win");
        Time.timeScale = 0.0f;
    }

    public void onGameOver()
    {
        print("game over");
        Score = 0;
        StartCoroutine(RestartAfterDelay());
    }

    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSecondsRealtime(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
