using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string examine = "";
    public float weight = 0;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
