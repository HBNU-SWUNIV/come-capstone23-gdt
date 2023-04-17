using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;

    [SerializeField]
    public int movespeed;

    public int nextMove;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
        Invoke("Think", 5);
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(nextMove*movespeed,rigid.velocity.y);


        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("ground"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }

    void Think() {

        nextMove = Random.Range(-1, 2);

        //방향전환
        if (nextMove != 0) {
            sprite.flipX = (nextMove == 1);
        }

        float nextThinktime = Random.Range(2f, 5f);

        Invoke("Think", nextThinktime);
    }

    void Turn() {

        nextMove *= -1;
        sprite.flipX = (nextMove == 1);
        CancelInvoke();
        Invoke("Think", 5);
    }
}
