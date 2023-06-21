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
    public ItemType itemtype;
    public string itemname;
    public Sprite itemImage;
    


    public bool use()
    {
        return false;
    }

}
