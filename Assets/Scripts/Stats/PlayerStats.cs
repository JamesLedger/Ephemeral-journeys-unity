using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    #region Singleton

    public static PlayerStats instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Update()
    {
        if (currentHealth <= 0)
            Die();
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("stats die");

        PlayerManager.instance.KillPlayer();
        
    }
}
