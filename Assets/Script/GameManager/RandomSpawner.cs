using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject GroundPrefab;

    public Vector2 SpawnerAreaMin = new Vector2(-15,-8);
    public Vector2 SpawnerAreaMix = new Vector2(15,8);

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnerObject();
        }
    }
    void Update()
    {
        
    }

    void SpawnerObject()
    {
        float x = Random.Range(SpawnerAreaMin.x, SpawnerAreaMix.x);
        float y = Random.Range(SpawnerAreaMin.y, SpawnerAreaMix.y);

        Vector2 randomPosition = new Vector2(x, y);
        Instantiate(GroundPrefab, randomPosition, Quaternion.identity);
    }
}
