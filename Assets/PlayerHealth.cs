using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player health is at " + playerHealth);
        if (playerHealth <= 0)
        {
            Debug.LogWarning("Player has lost, oh poop");
        }
    }
}
