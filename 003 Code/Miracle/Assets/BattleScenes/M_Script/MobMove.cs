using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMove : MonoBehaviour
{

    public GameObject player;            // ������ �÷��̾��� Transform
    public float moveSpeed = 5f;        // ������ �̵� �ӵ�
    public float detectionRange = 10f;    // ������ ������ �÷��̾��� �Ÿ�
    public float AtkRange = 7f; // ���Ÿ� ���� �Ÿ�
    public float raycastDistance = 1f;   // ���Ͱ� �÷��̾ �ִ��� üũ�� ����ĳ��Ʈ �Ÿ�


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


       

                // �÷��̾ ���� �Ÿ� �̳��� ���� �� ���� ����
                if (distanceToPlayer <= detectionRange)
            {
                isPlayerInRange = true;

                // �÷��̾���� ������ üũ
                float direction = player.transform.position.x - transform.position.x;

                // �¿� �̵�
                rb.velocity = new Vector2(direction, rb.velocity.y).normalized * moveSpeed;

                // ���Ͱ� �ٶ󺸴� ���� ����
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







        // �÷��̾ �����ϱ� ���� ����ĳ��Ʈ ���
        if (isPlayerInRange)
        {
            Debug.DrawRay(rb.position, Vector2.left, new Color(0, 1, 0));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, !isFacingRight ? Vector2.right : Vector2.left, raycastDistance);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                // �÷��̾�� �浹 ó��
                // ��: �÷��̾�� �������� ������ ���� ������ ����
            }
        }
    }

}
