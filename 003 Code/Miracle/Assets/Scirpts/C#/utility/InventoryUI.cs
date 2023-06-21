using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    //public delegate void OnSlotCountChange(int val);
    //public OnSlotCountChange onSlotCountChange;

    public Inventory inven;
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHoler;

    public GameObject player;
    public int current_activated_slot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inven = player.GetComponent<Inventory>();
        slots = slotHoler.GetComponentsInChildren<Slot>();
        SlotChange(); //각 캐릭터 마다의 활성화된 슬롯 가져오기 
        inventoryPanel.SetActive(activeInventory);
        
    }
    
    void SlotChange()
    {
        Debug.Log("슬롯 활성화");

        for (int i = 0; i < slots.Length; i++) {

            if (i < inven.slotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;//슬롯 활성화 
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;//슬롯 비활성화
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        current_activated_slot = inven.slotCnt;
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void AddSlot()//상점기능에 추가 
    {
        inven.slotCnt++;
        SlotChange();
    }
}
