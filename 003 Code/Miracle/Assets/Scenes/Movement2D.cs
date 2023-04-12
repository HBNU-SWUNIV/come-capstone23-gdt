using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement2D : MonoBehaviour
{

    [SerializeField]
    private float speed=5.0f;

    private Rigidbody2D rigid2d;
 



    // Start is called before the first frame update
    private void Awake()
    {
        rigid2d=GetComponent<Rigidbody2D>();
       
    }

    public void Move(float x)
    {
        rigid2d.velocity = new Vector2(x * speed, rigid2d.velocity.y);
    }

}
