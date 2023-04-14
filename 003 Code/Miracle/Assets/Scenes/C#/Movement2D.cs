using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class Movement2D : MonoBehaviour
{

    [SerializeField]
    private float speed=5.0f;

    [SerializeField]
    private float jumpforce = 8.0f;

    private Rigidbody2D rigid2d;

    [SerializeField]
    private LayerMask groundLayer;
    private CapsuleCollider2D capsulecollider2d;
    private bool isGround;
    private Vector3 footposition;

    



    // Start is called before the first frame update
    private void Awake()
    {
        rigid2d=GetComponent<Rigidbody2D>();
        capsulecollider2d = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        Bounds bounds = capsulecollider2d.bounds;
        footposition = new Vector2(bounds.center.x, bounds.min.y);
        isGround = Physics2D.OverlapCircle(footposition, 0.1f, groundLayer);

        

    }



    public void Move(float x)
    {
        rigid2d.velocity = new Vector2(x * speed, rigid2d.velocity.y);
    }

    public void Jump() {

        if (isGround==true) {
            rigid2d.velocity = Vector2.up * jumpforce;

            
        }
        
    }
}
