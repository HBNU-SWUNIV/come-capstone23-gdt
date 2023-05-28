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


    [SerializeField]GameObject condition_applicator;
    [SerializeField] Condition_applicator applicator;



    // Start is called before the first frame update
    private void Awake()
    {
        movement2d = GetComponent<Movement2D>();
        status= GetComponent<Player_Status>();
        condition_applicator = GameObject.FindWithTag("Condition_applicator");
        applicator = condition_applicator.GetComponent<Condition_applicator>();
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
        movement2d.Move(x);

        if (Input.GetKeyDown(KeyCode.Space)) {

            movement2d.Jump();
        
        
        }
    }


}
