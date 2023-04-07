using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]//�ش籸������ �ڵ����� ������Ʈ �߰� 
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

    public void MoveTo(float input) {//input�� �����̴� ���� 

        velocity.x = input*speed;

    }
}
