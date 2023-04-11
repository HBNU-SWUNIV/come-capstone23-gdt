using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement2D : MonoBehaviour
{

    [SerializeField]
    private float speed=5.0f;

    private Rigidbody2D rigid2d;
    private Vector3 movedirection;



    // Start is called before the first frame update
    void Awake()
    {
        rigid2d=GetComponent<Rigidbody2D>();
        movedirection = Vector3.right;
        speed=5.0f;
    }

    // Update is called once per frame
    void Update()
    {
       

        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        movedirection = new Vector3(x, y, 0);


        rigid2d.velocity = movedirection * speed;
    }

   
}
