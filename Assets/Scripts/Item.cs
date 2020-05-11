using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item"; //Overriding name;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int itemStackSize;

    public virtual void UseItem() {

        // Use the item

        // Something might happen

        Debug.Log("Using " + name);
    
    }


}
