using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int paddle1Score;
    private int paddle2Score;
    [SerializeField] int scoreToReach = 3;

    public int Paddle1Score
    {
        get => paddle1Score;
        set
        {
            paddle1Score = value;
            UIManager.instance.OnUpdatePaddle1Score?.Invoke(paddle1Score);
            GameManager.instance.GameOver(paddle1Score, scoreToReach);
        }
    }

    public int Paddle2Score
    {
        get => paddle2Score;
        set
        {
            paddle2Score = value;
            UIManager.instance.OnUpdatePaddle2Score?.Invoke(paddle2Score);
            GameManager.instance.GameOver(paddle2Score, scoreToReach);
        }
    }

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
}
