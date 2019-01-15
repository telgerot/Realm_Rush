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
    [SerializeField] AudioClip enemyDamageBaseSFX;
    [SerializeField] AudioClip enemyTakesDamageSFX;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessDeath(deathParticlesPrefab);
    }

    void ProcessHit()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyTakesDamageSFX);
        hitPoints = hitPoints - 1;
        Instantiate(hitParticlesPrefab, transform.position, Quaternion.identity);
    }

    private void ProcessDeath(ParticleSystem particleVFX)
    {
        if (hitPoints <= 0)
        {
            FindObjectOfType<EnemySpawner>().PlayEnemyDeathSound();
            Instantiate(particleVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void DamageBase()
    {
        hitPoints = 0;
        GetComponent<AudioSource>().PlayOneShot(enemyDamageBaseSFX);
        ProcessDeath(goalParticlesPrefab);
        FindObjectOfType<PlayerHealth>().DamagePlayer(enemyDamage);
    } 
}

