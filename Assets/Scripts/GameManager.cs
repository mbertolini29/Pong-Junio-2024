using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    public static UnityEvent<int> OnUpdatePaddle1Score;
    public static UnityEvent<int> OnUpdatePaddle2Score;

    private int paddle1Score;
    private int paddle2Score;

    public int Paddle1Score
    {
        get => paddle1Score;
        set
        {
            paddle1Score = value;
            OnUpdatePaddle1Score?.Invoke(paddle1Score);
        }
    }

    public int Paddle2Score
    {
        get => paddle2Score;
        set
        {
            paddle2Score = value;
            OnUpdatePaddle2Score?.Invoke(paddle2Score);
        }
    }

    // Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }

    public void Win()
    {

    }

}
