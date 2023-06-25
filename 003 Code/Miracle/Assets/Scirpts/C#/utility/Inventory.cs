using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnSlotCountChange();
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public int slotCnt;//

    public List<Item> items = new List<Item>();

    private void Start()
    {
        onSlotCountChange.Invoke();
    }


    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke();//델리게이트 호출
        }
    }

    public bool AddItem(Item _item)
    {
        if (items.Count < slotCnt)
        {
            items.Add(_item);
            if(onChangeItem!=null)
            onChangeItem.Invoke();
            return true;
        }
        Debug.Log("인벤토리가 가득입니다.");
        return false;
        
    }

    public void RemoveItem(int index)
    {
        items.RemoveAt(index);
        onChangeItem.Invoke();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FieldItem"))
        {
            Debug.Log("아이템 휙득 ");
            FieldItems fieldItems = collision.gameObject.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
            {
                fieldItems.DestroyItem();
            }


        }


    }
}
