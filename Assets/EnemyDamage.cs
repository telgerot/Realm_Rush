using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;

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
    }

    private void ProcessDeath()
    {
        if (hitPoints <= 0)
        {
            print("I'm dead!");
            Destroy(gameObject);
        }
    }
}
