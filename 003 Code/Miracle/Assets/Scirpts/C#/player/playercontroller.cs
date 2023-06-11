using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour//�ǰ� �������� 
{
    
    private Movement2D movement2d;
    private Player_Status status;
    AudioSource audiosrc;
    bool isMoving = false;
    GameObject fade_system;
    FadeSystem performer_fade_system;


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
    }
   
   
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        
        if (collision.gameObject.tag.Equals("Enemy_weapon"))//���� ���ݿ� ���Ұ�� 
        {
            float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;
            movement2d.OnDamaged(collision.transform.position);
            if (status.Is_protective_film == true)//ĳ������ ��ȣ���� �ִ� ��� 
            {
                if (status.protective_film >= enemy_offensive)//�Ǽ�ġ ��Ƴ��� 
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
            else if (status.Is_protective_film == false)//ĳ������ ��ȣ���� ���� ��� 
            {
                status.current_hp -= enemy_offensive - (status.defensive_power / 10);
            }
        }
        else if (collision.gameObject.tag.Equals("Enemy"))//������ �����Ұ�� 
        {
            float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;

            movement2d.OnDamaged(collision.transform.position);
            

            if (status.Is_protective_film == true)//ĳ������ ��ȣ���� �ִ� ��� 
            {
                if (status.protective_film >= enemy_offensive)//�Ǽ�ġ ��Ƴ��� 
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
            else if (status.Is_protective_film == false)//ĳ������ ��ȣ���� ���� ��� 
            {
                status.current_hp -= enemy_offensive - (status.defensive_power / 10);
            }


        }
       
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (Input.GetKeyDown(KeyCode.F))//��Ż �̿�� fŰ ���
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



    public void end_game() { //���� ����� ��� ���� �� ����� ���� 

        for (int i = 0; i < 12; i++) {
            applicator.Init_state(i);
        }
    
    }

   
    // Update is called once per frame
    void Update()//������ ������ ��Ʈ��
    {
        
       
        float x = Input.GetAxisRaw("Horizontal");

        if (x != 0)
        {
            movement2d.Move(x);
            isMoving = true;
        }
        else if (x == 0) {
            movement2d.Move(0);
            isMoving = false;
        }

        if (isMoving && movement2d.isGround)//������ �ְ� �����δٴ� ����
        {

            if (!audiosrc.isPlaying)
            {
                audiosrc.Play();
            }
        }
        else {
            audiosrc.Stop();
        }


        if (Input.GetKeyDown(KeyCode.Space)) {

            movement2d.Jump();
        
        
        }
    }


}
