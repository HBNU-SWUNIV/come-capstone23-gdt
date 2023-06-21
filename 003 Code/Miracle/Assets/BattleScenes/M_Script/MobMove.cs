using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMove : MonoBehaviour
{

    public GameObject player;            // 추적할 플레이어의 Transform
    public float moveSpeed = 5f;        // 몬스터의 이동 속도
    public float detectionRange = 10f;    // 추적을 시작할 플레이어의 거리
    public float AtkRange = 7f; // 원거리 공격 거리
    public float raycastDistance = 1f;   // 몬스터가 플레이어가 있는지 체크할 레이캐스트 거리


    public GameObject bullet;

    private Rigidbody2D rb;
    private bool isPlayerInRange;
    private bool isFacingRight = true;


    public float cooltime;
    private float currenttime;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {

            

            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);


       

                // 플레이어가 일정 거리 이내에 있을 때 추적 시작
                if (distanceToPlayer <= detectionRange)
            {
                isPlayerInRange = true;

                // 플레이어와의 방향을 체크
                float direction = player.transform.position.x - transform.position.x;

                // 좌우 이동
                rb.velocity = new Vector2(direction, rb.velocity.y).normalized * moveSpeed;

                // 몬스터가 바라보는 방향 설정
                if (direction > 0f && isFacingRight)
                {
                    Flip();
                }
                else if (direction < 0f && !isFacingRight)
                {
                    Flip();
                }

                if (distanceToPlayer <= AtkRange)
                {
                    if (currenttime <= 0)
                    {
                        GameObject bulletcopy = Instantiate(bullet, transform.position, Quaternion.identity);

                        currenttime = cooltime;


                    }
                }


            }
            else
            {
                isPlayerInRange = false;
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            currenttime -= Time.deltaTime;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {







        // 플레이어를 감지하기 위해 레이캐스트 사용
        if (isPlayerInRange)
        {
            Debug.DrawRay(rb.position, Vector2.left, new Color(0, 1, 0));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, !isFacingRight ? Vector2.right : Vector2.left, raycastDistance);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                // 플레이어와 충돌 처리
                // 예: 플레이어에게 데미지를 입히는 등의 로직을 구현
            }
        }
    }

}
