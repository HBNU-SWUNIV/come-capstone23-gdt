using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Mode { assassin,shock,shooter}

public class playercontroller : MonoBehaviour//피격 상태정의 
{
    public Mode mode;
    public Animator[] animators;
    private Movement2D movement2d;
    private Player_Status status;
    private InventoryUI inventory_ui;
    AudioSource audiosrc;
    bool isMoving = false;
    //bool is_Shop_open;
    GameObject fade_system, manager;
    FadeSystem performer_fade_system;
    Animator animator;
    public RuntimeAnimatorController[] animation_controllers= new RuntimeAnimatorController[3];
    private Rigidbody2D rigid;

    [SerializeField]GameObject condition_applicator;
    [SerializeField] Condition_applicator applicator;



    // Start is called before the first frame update
    private void Awake()
    {
        movement2d = GetComponent<Movement2D>();
        status= GetComponent<Player_Status>();
        condition_applicator = GameObject.FindWithTag("Condition_applicator");
        applicator = condition_applicator.GetComponent<Condition_applicator>();
        audiosrc = GetComponent<AudioSource>();
        fade_system = GameObject.FindWithTag("Fade");
        performer_fade_system = fade_system.GetComponent<FadeSystem>();
        manager = GameObject.FindWithTag("GameManager");
        inventory_ui = manager.GetComponent<InventoryUI>();
        //is_Shop_open = false;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        animators = new Animator[2];
        animators = GetComponentsInChildren<Animator>();
    }
   
   
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        
        if (collision.gameObject.tag.Equals("Enemy_weapon"))//적의 공격에 당할경우 
        {
            if (this.CompareTag("Player"))
            {
                animator.SetTrigger("Player_damaged");
                float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;
                movement2d.OnDamaged(collision.transform.position);
                if (status.Is_protective_film == true)//캐릭터의 보호막이 있는 경우 
                {
                    if (status.protective_film >= enemy_offensive)//실수치 깎아내기 
                    {
                        status.protective_film -= enemy_offensive;

                    }
                    else if (status.protective_film < enemy_offensive)
                    {
                        float Remaining_attack_power = enemy_offensive - status.protective_film;
                        status.protective_film = 0f;
                        status.Is_protective_film = false;
                        status.current_hp -= Remaining_attack_power - (status.defensive_power / 10);
                    }

                }
                else if (status.Is_protective_film == false)//캐릭터의 보호막이 없는 경우 
                {
                    status.current_hp -= enemy_offensive - (status.defensive_power / 10);
                }
            }
            
        }
        else if (collision.gameObject.tag.Equals("Enemy"))//적에게 접촉할경우 
        {
            if (this.CompareTag("Player"))
            {
                animator.SetTrigger("Player_damaged");//피격 모션 활성화
                float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;
                movement2d.OnDamaged(collision.transform.position);
                if (status.Is_protective_film == true)//캐릭터의 보호막이 있는 경우 
                {
                    if (status.protective_film >= enemy_offensive)//실수치 깎아내기 
                    {
                        status.protective_film -= enemy_offensive;

                    }
                    else if (status.protective_film < enemy_offensive)
                    {
                        float Remaining_attack_power = enemy_offensive - status.protective_film;
                        status.protective_film = 0f;
                        status.Is_protective_film = false;
                        status.current_hp -= Remaining_attack_power - (status.defensive_power / 10);
                    }

                }
                else if (status.Is_protective_film == false)//캐릭터의 보호막이 없는 경우 
                {
                    status.current_hp -= enemy_offensive - (status.defensive_power / 10);
                }
            }


        }
        else if (collision.gameObject.tag.Equals("Coin"))
        {
            Gold_Coin gold_coin = collision.gameObject.GetComponent<Gold_Coin>();
            if (gold_coin != null)
            {
                status.pocket_money += gold_coin.money;
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (Input.GetKeyDown(KeyCode.F))// 포탈이용시 f키 사용
        {
            if (collision.gameObject.tag.Equals("Teleport_Village"))
            {
                SceneManager.LoadScene("Village");
            }
            else if (collision.gameObject.tag.Equals("Teleport_Desert_normal"))
            {
                SceneManager.LoadScene("Desert_normal");
            }
            else if (collision.gameObject.tag.Equals("Teleport_Lake_normal"))
            {
                SceneManager.LoadScene("Lake_normal");
            }
            else if (collision.gameObject.tag.Equals("Teleport_Deepforest_normal"))
            {
                SceneManager.LoadScene("Deepforest_normal");
            }


            performer_fade_system.total_start();
        }
        
        
        
    }
    public void player_death()//플레이어 사망
    {
        gameObject.layer = 12;

        //플레이어 키보드 입력 막는 코드 필요 
    }
    public void Set_tag_Player()
    {
        gameObject.tag = "Player";
    }
    public void Set_tag_Playerskilling()
    {
        gameObject.tag = "Player_skilling";
    }

    public void end_game() { //게임 종료시 모든 버프 및 디버프 삭제 

        for (int i = 0; i < 12; i++) {
            applicator.Init_state(i);
        }
    
    }


    // Update is called once per frame
    void Update()//실질적 움직임 컨트롤
    {

        float x = Input.GetAxisRaw("Horizontal");

        if (x != 0)
        {
            movement2d.Move(x);
            isMoving = true;
            animator.SetBool("IsMove", isMoving);
        }
        else if (x == 0)
        {
            movement2d.Move(0);
            isMoving = false;
            animator.SetBool("IsMove", isMoving);
        }

        /*if (isMoving && movement2d.isGround)//땅위에 있고 움직인다는 가정
        {

            if (!audiosrc.isPlaying)
            {
                audiosrc.Play();
            }
        }
        else {
            audiosrc.Stop();
        }*/

        if (rigid.velocity.y < 0)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("Ground"));

            if (raycastHit.collider != null)
            {
                if (raycastHit.distance <= 0.5f)
                {
                    animator.SetBool("IsAir", false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!inventory_ui.isStoreActive)
            {
                movement2d.Jump();
                animator.SetTrigger("jump");
                animator.SetBool("IsAir", true);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inventory_ui.isStoreActive)
            {
                animator.SetTrigger("Skill_attack");
               
            }
                
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!inventory_ui.isStoreActive && !inventory_ui.activeInventory)
            {
                animator.SetTrigger("Attack");
            }
            
        }


        if (Input.GetKeyDown(KeyCode.F1))
        {
            mode = Mode.assassin;
            animator.runtimeAnimatorController = animation_controllers[0];
            animators[1].SetTrigger("Change_class");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            mode = Mode.shock;
            animator.runtimeAnimatorController = animation_controllers[1];
            animators[1].SetTrigger("Change_class");
           
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            mode = Mode.shooter;
            animator.runtimeAnimatorController = animation_controllers[2];
            animators[1].SetTrigger("Change_class");
        }
    }
}
