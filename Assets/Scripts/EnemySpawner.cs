using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 120f)] float secondsBetweenSpawns = 3f;
    [SerializeField] int maxNumberOfSpawns = 10;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text enemySpawnCounter;
    [SerializeField] AudioClip spawnedEnemySFX;
    [SerializeField] AudioClip enemyDeathSFX;
    int spawnCounter;

    
    private void Start()
    {    
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        
        for (int numberOfSpawns = 0; numberOfSpawns < maxNumberOfSpawns; numberOfSpawns++)
        {
            spawnCounter++;
            enemySpawnCounter.text = spawnCounter.ToString();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.Euler(0, 90, 0));
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    public void PlayEnemyDeathSound()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
    }
}
