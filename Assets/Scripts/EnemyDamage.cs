using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] int enemyDamage = 1;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;
    [SerializeField] ParticleSystem goalParticlesPrefab;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessDeath(deathParticlesPrefab);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        Instantiate(hitParticlesPrefab, transform.position, Quaternion.identity);
    }

    private void ProcessDeath(ParticleSystem particleVFX)
    {
        if (hitPoints <= 0)
        {
            Instantiate(particleVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void DamageBase()
    {
        //todo create "health" for base, and do damage to it
        hitPoints = 0;
        ProcessDeath(goalParticlesPrefab);
        FindObjectOfType<PlayerHealth>().DamagePlayer(enemyDamage);
    } 
}

