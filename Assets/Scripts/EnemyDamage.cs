using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessDeath();
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        Instantiate(hitParticlesPrefab, transform.position, Quaternion.identity);
    }

    private void ProcessDeath()
    {
        if (hitPoints <= 0)
        {
            Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
