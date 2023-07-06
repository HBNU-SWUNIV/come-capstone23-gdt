using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_creator : MonoBehaviour
{
    GameObject player;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        
    }
    private void Update()
    {
        this.transform.position = player.transform.position;
    }
    public void activate()
    {
        animator.SetTrigger("Change_class");
    }
}
