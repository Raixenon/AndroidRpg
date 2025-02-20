﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public string tag = "";
    public string description;
    public int value;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFormInventory()
    {
        Inventory.instance.Remove(this);
    }
    public virtual string GetDescription()
    {
        return name;
    }
}
