using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Player : MonoBehaviour
{

    public float power = 5;
    public float B_speed = 20;
    public float B_jumpUp = 10;
    public Vector3 B_direction;
    public GameObject B_Slash;

    //그림자
    public GameObject Shadow1;
    List<GameObject> Sh = new List<GameObject>();

    //히트 이펙트
    public GameObject hit_lazer;
    Animator BpAnimator;
    Rigidbody2D BpRig2D;
    SpriteRenderer sBp;
        


    // Start is called before the first frame update
    void Start()
    {
        BpAnimator = GetComponent<Animator>();
        BpRig2D = GetComponent<Rigidbody2D>();
        B_direction = Vector2.zero;
        sBp = GetComponent<SpriteRenderer>();




    }

    void B_KeyInput()
    {
        B_direction.x = Input.GetAxisRaw("Horizontal"); // 왼쪽 -1 0 1

        if(B_direction.x < 0)
        {
            sBp.flipX = true;
            BpAnimator.SetBool("Run", true);

            for(int i = 0; i< Sh.Count; i++)
            {
                Sh[i].GetComponent<SpriteRenderer>().flipX = sBp.flipX;
            }
        }
        else if(B_direction.x > 0)
        {
            sBp.flipX = false;
            BpAnimator.SetBool("Run", true);

            for (int i = 0; i < Sh.Count; i++)
            {
                Sh[i].GetComponent<SpriteRenderer>().flipX = sBp.flipX;
            }
        }
        else if(B_direction.x == 0)
        {
            BpAnimator.SetBool("Run", false);

            for(int i = 0; i< Sh.Count; i++)
            {
                Destroy(Sh[i]);
                Sh.RemoveAt(i);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            BpAnimator.SetTrigger("Attack");
            Instantiate(hit_lazer, transform.position, Quaternion.identity); 
        }

    }

    // Update is called once per frame
    void Update() 
    {
        B_KeyInput();
        B_Move();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(BpAnimator.GetBool("Jump")== false)
            {
                B_Jump();
                BpAnimator.SetBool("Jump", true);
            }
           
        }

    }

    private void FixedUpdate()
    {
        Debug.DrawRay(BpRig2D.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(BpRig2D.position, Vector3.down, 2, LayerMask.GetMask("Ground"));

        if(BpRig2D.velocity.y < 0)
        {
            if(rayHit.collider != null)
            {
                if(rayHit.distance < 4.7f)
                {
                    BpAnimator.SetBool("Jump", false);
                }
            }
        }
    }



    public void B_Jump()
    {
        BpRig2D.velocity = Vector2.zero;

        BpRig2D.AddForce(new Vector2(0, B_jumpUp), ForceMode2D.Impulse);
    }


    public void B_Move()
    {
        transform.position += B_direction * B_speed * Time.deltaTime;
    }


    public void AttSlash()
    {
        //플레이어 오른쪽
        if(sBp.flipX == false)
        {
            BpRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
           GameObject go = Instantiate(B_Slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sBp.flipX;
            //마우스 방향으로 이미지가 회전하기에 플립이 필요없음
        }
        else
        {
            BpRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            GameObject go = Instantiate(B_Slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sBp.flipX;
        }

       


    }

    //그림자

    public void RunShadow()
    {
        if (Sh.Count<6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - Sh.Count;
            Sh.Add(go);
        }
    }


}
