using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text paddle1ScoreText;
    [SerializeField] private TMP_Text paddle2ScoreText;

    //private int _paddle1Score;
    //private int _paddle2Score;

    public void UpdatePaddle1Score(int paddleScore)
    {
        paddle1ScoreText.text = paddleScore.ToString();
    }

    public void UpdatePaddle2Score(int paddleScore)
    {
        paddle2ScoreText.text = paddleScore.ToString();
    }
}
