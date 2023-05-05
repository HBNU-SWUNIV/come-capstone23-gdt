using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Slash : MonoBehaviour
{
    private GameObject p;
    public Vector3 direction = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = p.transform.position;
    }


    public void Des()
    {
        Destroy(gameObject);
    }

    

    
}
