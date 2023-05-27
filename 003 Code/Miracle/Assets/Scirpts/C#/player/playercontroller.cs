using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour//피격 상태정의 
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
   
   
    
    private void OnCollisionEnter2D(Collision2D collision)//적의 공격에 피격 당할경우 
    {
        
        if (collision.gameObject.tag.Equals("Enemy_weapon"))
        {
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
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
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

    public void end_game() { //게임 종료시 모든 버프 및 디버프 삭제 

        for (int i = 0; i < 12; i++) {
            applicator.Init_state(i);
        }
    
    }

   
    // Update is called once per frame
    void Update()//실질적 움직임 컨트롤
    {
        
       
        float x = Input.GetAxisRaw("Horizontal");
        movement2d.Move(x);

        if (Input.GetKeyDown(KeyCode.Space)) {

            movement2d.Jump();
        
        
        }
    }


}
