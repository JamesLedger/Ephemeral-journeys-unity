using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Consumable", menuName ="Inventory/Consumable")]
public class Consumable : Item
{
    public CharacterStats player;

    private void Awake()
    {
        player = PlayerStats.instance;
    }

    public override void Use()
    {
        base.Use();
        Debug.Log("Healing");

        if (player != null)
            player.Heal(10);
        else
            Debug.Log("Can't find playerstats");

        RemoveFromInventory();
    }
}
