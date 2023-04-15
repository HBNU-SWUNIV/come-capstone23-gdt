using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField]
    public int movespeed;

    public int nextMove;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        
        Invoke("Think", 5);
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(nextMove*movespeed,rigid.velocity.y);

        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

        //RaycastHit2D rayHit=Physics2D.Raycast(rigid.position,Vector3.down,)

    }

    void Think() {

        nextMove = Random.Range(-1, 2);

        Invoke("Think", 5);
    }
}
