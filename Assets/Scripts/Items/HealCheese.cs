using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New heal cheese", menuName ="Inventory/Consumables")]
public class HealCheese : Item
{
    public PlayerStats player;

    public override void Use()
    {
        base.Use();
        Debug.Log("Healing");

        player = PlayerStats.instance;

        if (player != null)
            player.Heal(10);
        else
            Debug.Log("Can't find playerstats");

        RemoveFromInventory();
    }
}
