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

    public GameObject fieldItemPrefab;
    public Vector3 pos;



    private void Start()
    {
        GameObject go=Instantiate(fieldItemPrefab, pos,Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 2)]);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
