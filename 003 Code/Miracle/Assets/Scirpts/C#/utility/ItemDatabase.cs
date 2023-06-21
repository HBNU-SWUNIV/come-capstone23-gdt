using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();


    // Update is called once per frame
    void Update()
    {
        
    }
}
