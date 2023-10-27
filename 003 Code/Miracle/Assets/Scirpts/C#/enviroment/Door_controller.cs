using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_controller : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player= GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
