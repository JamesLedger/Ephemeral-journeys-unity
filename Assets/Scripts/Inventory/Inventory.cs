using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    public int space = 20;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one inventory found!!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<Item> items = new List<Item>();
    
    public bool AddItem(Item item)
    {
        if (items.Count >= space)
            return false;

        items.Add(item);

        if (onItemChangedCallback != null)  
            onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
