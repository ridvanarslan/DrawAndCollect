using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] [Range(100, 999)] private float forceAmount;

    [SerializeField] private GameObject[] balls;
    [SerializeField] private BasketSpawner basketSpawner;
    [SerializeField] private bool _canSpawnBall = true;
    private int _activeBallIndex;
    public bool CanSpawnBall
    {
        get => _canSpawnBall;
        set => _canSpawnBall = value;
    }


    public void StartSpawningBalls()
    {
        _canSpawnBall = true;
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            if (_canSpawnBall)
            {
                //creates the ball .5f second after the start
                yield return new WaitForSeconds(.5f);
                var ball = balls[_activeBallIndex];

                //gives ball a start position
                ball.transform.position = this.transform.position;
                ball.SetActive(true);
                
                //throwing ball with angle
                ball.GetComponent<Rigidbody2D>().AddForce(GiveAngle() * forceAmount);

                if (_activeBallIndex != balls.Length - 1)
                    _activeBallIndex++;
                else
                    _activeBallIndex = 0;

                //Spawns the basket .3f second after the ball thrown
                yield return new WaitForSeconds(.3f);
                basketSpawner.SpawnBasket();
                _canSpawnBall = false;
            }
            else
            {
                yield return null;
            }
        }
    }
    
    
    /// Creating a random angle to give the ball
    private float CreateAngle(float val1, float val2) => Random.Range(val1, val2);

    /// Giving angle to the ball
    private Vector2 GiveAngle() => Quaternion.AngleAxis(CreateAngle(70f,110f), Vector3.forward) * Vector3.right;
}