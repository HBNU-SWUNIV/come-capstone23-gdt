using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    

    public Inventory inven;
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHoler;

    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inven = player.GetComponent<Inventory>();
        slots = slotHoler.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
        
    }
    
    void SlotChange()
    {
        

        for (int i = 0; i < slots.Length; i++) {

            slots[i].slotnum = i;

            if (i < inven.slotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;//���� Ȱ��ȭ 
                Debug.Log(i+"���� Ȱ��ȭ");
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;//���� ��Ȱ��ȭ
                Debug.Log(i+"���� ��Ȱ��ȭ");
            }
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void AddSlot()//������ɿ� �߰� 
    {
        inven.SlotCnt++;
    }

    void RedrawSlotUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }

    }
}
