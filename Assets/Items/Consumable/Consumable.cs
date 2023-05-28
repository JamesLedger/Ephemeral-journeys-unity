using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Consumable", menuName ="Inventory/Consumable")]
public class Consumable : Item
{
    public int healValue = 5;

    public override void Use()
    {
        base.Use();
        Debug.Log("Using Consumable");

        Player.instance.Heal(healValue);

        RemoveFromInventory();
    }
}
