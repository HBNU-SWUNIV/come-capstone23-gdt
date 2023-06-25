using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{


    public Player_Status status;
    public Inventory inven;
    public GameObject inventoryPanel;
    bool activeInventory = false;
    public GameObject shop;
    public Button closeShop;
    public bool isStoreActive;
    public Slot[] slots;
    public Transform slotHoler;

    public GameObject player;

    public int slot_activate_fee;//�߰� ���� Ȱ��ȭ ���

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        status = player.GetComponent<Player_Status>();
        inven = player.GetComponent<Inventory>();
        slots = slotHoler.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
        closeShop.onClick.AddListener(DeActiveShop);//�̺�Ʈ �Լ� ����
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
        
        if (Input.GetKeyDown(KeyCode.I)&&!isStoreActive)//������ ���������� �κ��丮 �ܵ� �ۿ� �Ұ���
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RayShop();
        }
    }

    public void AddSlot()//������ɿ� �߰� 
    {

        if(status.pocket_money>= slot_activate_fee)
        {
            if (inven.SlotCnt < slots.Length)
            {
                inven.SlotCnt++;
                status.pocket_money -= slot_activate_fee;
            }
            else if (inven.SlotCnt == slots.Length)
            {
                Debug.Log("��� �κ��丮�� Ȱ��ȭ�Ǿ����ϴ�.");
            }
        }
        else if(status.pocket_money < slot_activate_fee)
        {
            Debug.Log("�ݾ��� ���ڶ��ϴ�.");
        }

        
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

    

    public void RayShop()
    {
        Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -10;
        RaycastHit2D hit2d = Physics2D.Raycast(mousePos, transform.forward, 30);
        if (hit2d.collider != null)
        {
            if (hit2d.collider.CompareTag("Store"))
            {
                if (!isStoreActive)
                {
                    ActiveShop(true);
                }
                
            }
        }
    }

    public void ActiveShop(bool isOpen)
    {
        if (!activeInventory)
        {
            activeInventory = isOpen;
            isStoreActive = isOpen;
            shop.SetActive(isOpen);
            inventoryPanel.SetActive(isOpen);
        }
    }
    public void DeActiveShop()
    {
        isStoreActive = false;
        shop.SetActive(false);
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
