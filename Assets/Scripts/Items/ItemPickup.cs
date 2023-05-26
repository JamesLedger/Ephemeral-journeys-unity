using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
       
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        bool wasPickedUp = Inventory.instance.AddItem(item);

        if (wasPickedUp) 
            Destroy(gameObject);
    }

    private Color startcolor;
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.cyan;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }

}
