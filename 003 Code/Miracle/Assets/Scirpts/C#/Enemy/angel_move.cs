using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angel_move : MonoBehaviour
{
    public Animator bringer_animator;
    public GameObject player, spell_attack_object;
    Rigidbody2D rb;
    public boss_status boss_status_script;
    public SpriteRenderer render;

    public float detectionRange = 10f;    // 추적을 시작할 플레이어의 거리
    public float raycastDistance = 1f;

    public float movespeed;

    private bool isPlayerInRange;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        bringer_animator = GetComponent<Animator>();
        boss_status_script = GetComponent<boss_status>();
        spell_attack_object.GetComponent<Boss_long_range_status>().boss_offensive_power = (int)boss_status_script.offensive_power;
        render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("Bringer_Death_random_attack", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // 플레이어가 일정 거리 이내에 있을 때 추적 시작
            if (distanceToPlayer <= detectionRange)
            {
                bringer_animator.SetBool("IsMove", true);
                isPlayerInRange = true;

                // 플레이어와의 방향을 체크
                float direction = player.transform.position.x - transform.position.x;

                // 좌우 이동
                rb.velocity = new Vector2(direction, rb.velocity.y).normalized * movespeed;

                // 몬스터가 바라보는 방향 설정
                if (direction > 0f && isFacingRight)
                {
                    Flip();
                }
                else if (direction < 0f && !isFacingRight)
                {
                    Flip();
                }
            }
            else
            {
                bringer_animator.SetBool("IsMove", false);
                isPlayerInRange = false;
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
        }
    }

    public void Flip()
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, isFacingRight ? Vector2.right : Vector2.left, raycastDistance);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                bringer_animator.SetTrigger("Death_Attack");//일반 휘두르기 공격
            }
        }
    }
}
