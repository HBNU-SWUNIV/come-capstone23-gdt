using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

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
   
   
    
    private void OnCollisionEnter2D(Collision2D collision)//���� ���ݿ� �ǰ� ���Ұ�� 
    {
        if (collision.gameObject.tag.Equals("Enemy_weapon"))
        {
            float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;

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
                    status.hp -= Remaining_attack_power - (status.defensive_power / 10);
                }

            }
            else if (status.Is_protective_film == false)//ĳ������ ��ȣ���� ���� ��� 
            {
                status.hp -= enemy_offensive - (status.defensive_power / 10);
            }
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
