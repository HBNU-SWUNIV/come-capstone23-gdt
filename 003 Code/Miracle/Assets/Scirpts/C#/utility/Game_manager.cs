using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class PlayerData //플레이어 이름,플레이어스테이터스,도감상황,무기
{
    public string player_name;
    public Player_Status player_status;
    
}


public class Game_manager : MonoBehaviour
{
    public RingMenu ColorSelectPrefab;
    protected RingMenu ColorSelectInstance;
    
    //single 
    public static Game_manager instance;

    public PlayerData now_player = new PlayerData();

    public string path;
    public int nowSlot;

    public void Awake()
    {
        path = Application.persistentDataPath+ "/save_file";

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }


        

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(1))
        {
            ColorSelectInstance = Instantiate(ColorSelectPrefab, FindAnyObjectByType<Canvas>().transform);
        }

    }

    

    public void SaveData() {
        
        
        string data = JsonUtility.ToJson(now_player);

        File.WriteAllText(path+nowSlot.ToString(), data);
    }

    public void LoadData() 
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        now_player=JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        now_player = new PlayerData();

        
    }

   
}
