using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.15f; //en cada golpea su velocidad va aumentar un 15%

    //Collision Detection -> sirve para que la pelota no traspace la barra.
    //                       porque si toma mucha velocidad, puede traspazarla. 

    private Rigidbody2D ballRb;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch() //lanzamiento inicial.
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            ScoreManager.instance.Paddle1Score++;
        }
        else
        {
            ScoreManager.instance.Paddle2Score++;
        }

        if (!GameManager.instance.isGameOver)
        {
            GameManager.instance.RestartPosition();
            //GameManager.Instance.GameOver();
            Launch();
        }
    }
}
