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
        SlotChange(); //�� ĳ���� ������ Ȱ��ȭ�� ���� �������� 
        inventoryPanel.SetActive(activeInventory);
        
    }
    
    void SlotChange()
    {
        Debug.Log("���� Ȱ��ȭ");

        for (int i = 0; i < slots.Length; i++) {

            if (i < inven.slotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;//���� Ȱ��ȭ 
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;//���� ��Ȱ��ȭ
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

    public void AddSlot()//������ɿ� �߰� 
    {
        inven.slotCnt++;
        SlotChange();
    }
}
