using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = playerHealth.ToString();
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        healthText.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            Debug.LogWarning("Player has lost, oh poop");
        }
    }


}
