using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] [Range(3,5)] private float _timer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rb.velocity == Vector2.zero) /// If the ball stop, call EndTheGame method after 3 seconds
        {
            Invoke("EndTheGame",5f);
        }
        else
        {
            CancelInvoke("EndTheGame"); /// If
        }
    }

    private void EndTheGame()
    {
        gameManager.GameOver();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Basket"))
        {
            gameManager.ScoreHappened();
            this.gameObject.SetActive(false);
            col.transform.parent.gameObject.SetActive(false);
        }
        else if (col.CompareTag("GameOver"))
        {
            this.gameObject.SetActive(false);
            gameManager.GameOver();
            
        }
    }
}
