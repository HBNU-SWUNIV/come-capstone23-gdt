using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject B_player;
    public float TwSpeed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        B_player = GameObject.FindGameObjectWithTag("Player");

        transform.position = Vector3.Lerp(transform.position, B_player.transform.position, TwSpeed * Time.deltaTime);
    }
}
