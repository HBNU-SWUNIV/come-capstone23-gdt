using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumables,
    Etc
    
}



[System.Serializable]
public class Item  
{
    public string itemname;
    public Sprite itemImage;
    public ItemType itemtype;


    public bool use()
    {
        return false;
    }

}
