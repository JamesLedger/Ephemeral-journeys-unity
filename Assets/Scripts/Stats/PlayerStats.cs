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

    public override void Die()
    {
        base.Die();

        PlayerManager.instance.KillPlayer();
        
    }
}
