using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 120f)] float secondsBetweenSpawns = 3f;
    [SerializeField] int numberOfSpawns = 10;
    [SerializeField] GameObject enemy;

    private void Start()
    {
            StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (numberOfSpawns = 0; numberOfSpawns < 10; numberOfSpawns++)
        {
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 90, 0));
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
