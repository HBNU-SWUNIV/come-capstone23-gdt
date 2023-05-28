using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dessert_enviroment : MonoBehaviour
{

    public GameObject player;
    private Player_Status status;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        status = player.GetComponent<Player_Status>();
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
