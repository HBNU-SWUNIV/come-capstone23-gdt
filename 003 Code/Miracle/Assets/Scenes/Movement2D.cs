using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]//해당구문으로 자동으로 컴포넌트 추가 
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement2D : MonoBehaviour
{

    [SerializeField]
    private float speed=5;
    private Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
           

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curentVelocity = velocity * Time.deltaTime;

        transform.position += curentVelocity;
    }

    public void MoveTo(float input) {//input은 움직이는 방향 

        velocity.x = input*speed;

    }
}
