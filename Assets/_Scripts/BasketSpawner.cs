using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject basket;
    [SerializeField] private Transform spawnArea;
    
    //TODO: Basket spawn pozisyonlarını düzenle
    public void SpawnBasket()
    {
        var randomX = Random.Range(spawnArea.position.x, -spawnArea.position.x);
        var randomY = Random.Range(spawnArea.position.y + 1, -spawnArea.position.y - 1);

        var __basket = CreateBasket();
        __basket.transform.position = new Vector3(randomX, randomY);
        __basket.SetActive(true);
    }

    private GameObject CreateBasket() => Instantiate(basket, Vector3.zero, quaternion.identity);
}
