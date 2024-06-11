using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    [SerializeField] GameObject gameOverScreen;
    public bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pause();
        }
    }

    public void GameOver(int paddleScore, int scoreToReach)
    {
        if (paddleScore >= scoreToReach)
        {
            StartCoroutine(CountdownRoutine());
        }
        else
        {
            RestartPosition();
        }
    }

    public void RestartPosition()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }

    IEnumerator CountdownRoutine()
    {
        yield return new WaitForSeconds(0.15f); //Esperas un segundo.

        isGameOver = true;
        ShowGameOverScreen();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

}
