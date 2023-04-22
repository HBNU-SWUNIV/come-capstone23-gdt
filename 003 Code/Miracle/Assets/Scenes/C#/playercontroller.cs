using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public enum goodstate { non,strength, quick ,solid, agility, focus ,recovery};//괴력,신속,견고,민첩,집중,회복
    public enum badstate { non,burn,weak, deceleration ,destroy,coldair,cooling}//화상,약화,감속,파괴,독,냉기,냉각
    private Movement2D movement2d;
    private Status status;
    private float current_filled_time=0.0f;//현재 버프  사용시간
    private float max_filled_time=60.0f;//최대 버프 사용시간 
    public goodstate new_goodstate = goodstate.non;//새로운 버프 상태 적용
    public goodstate current_goodstate = goodstate.non;//현재 버프 상태 
   
    public badstate current_badstate = badstate.non;//현재 디버프 상태 
    private int currentnumber_goodstate = 0;
    private int maxnumber_goodstate = 3;

   
    
    // Start is called before the first frame update
    private void Awake()
    {
        movement2d = GetComponent<Movement2D>();
        status= GetComponent<Status>();
    }
   
    
    public void Apply_goodstate(goodstate input_new_goodstate)//버프 설정
    {
        switch (input_new_goodstate)
        {
            case goodstate.non://버프 해체
                status.all_init();//모든 버프 초기화 
                current_goodstate = goodstate.non;
                currentnumber_goodstate = 0; 
                break;
            case goodstate.strength://괴력
                init_goodstate(input_new_goodstate);//current_goodstate 변경 없음 
                current_goodstate = goodstate.strength;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_offensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.quick:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.quick;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_attack_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.solid:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.solid;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_defensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.agility:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.agility;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_move_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.focus:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.focus;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_critical();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.recovery:
                status.add_hp(30);
                break;
        }
    }
    public void init_goodstate(goodstate newstate)//새로운 버프 설정시 기존 버프 초기화 
    {
        if(newstate!= current_goodstate)
        {
            switch (current_goodstate)
            {

                case goodstate.strength:
                    currentnumber_goodstate = 0;
                    status.init_offensive_power();
                    break;
                case goodstate.quick:
                    currentnumber_goodstate = 0;
                    status.init_attack_speed();
                    break;
                case goodstate.solid:
                    currentnumber_goodstate = 0;
                    status.init_defensive_power();
                    break;
                case goodstate.agility:
                    currentnumber_goodstate = 0;
                    status.init_move_speed();
                    break;
                case goodstate.focus:
                    currentnumber_goodstate = 0;
                    status.init_critical();
                    break;
            }
        }

    }
    
    public void Apply_badstate(badstate input_new_badstate)//디버프 적용 
    {
        switch (input_new_badstate)
        {
            case badstate.burn://화상
                current_badstate = badstate.burn;
                status.burn();
                break;
            case badstate.weak://약화
                current_badstate = badstate.weak;
                status.reduce_offensive_power();
                break;
            case badstate.deceleration://감속
                current_badstate = badstate.deceleration;
                status.reduce_attack_speed();
                break;
            case badstate.destroy://파괴
                current_badstate = badstate.destroy;
                status.reduce_defensive_powe();
                break;
            case badstate.coldair://냉기
                current_badstate = badstate.coldair;
                status.reduce_move_speed();
                break;
            
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)//적의 공격에 피격 당할경우 
    {
        if (collision.collider.name == "Enemy_weapon")
        {
            float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;
            
            if (status.Is_protective_film == true)//캐릭터의 보호막이 있는 경우 
            {
                if(status.protective_film>=enemy_offensive)//실수치 깎아내기 
                {
                    status.protective_film -= enemy_offensive;

                }
                else if(status.protective_film < enemy_offensive)
                {
                    float Remaining_attack_power = enemy_offensive - status.protective_film;
                    status.protective_film = 0f;
                    status.Is_protective_film = false;
                    status.hp -= Remaining_attack_power - (status.defensive_power / 10);
                }

            }
            else if(status.Is_protective_film == false)//캐릭터의 보호막이 없는 경우 
            {
                status.hp -= enemy_offensive - (status.defensive_power / 10);
            }
        }
    }

    IEnumerator start_reuse_waiting_time()//버프 시간 시작,60초가 되면 버프 해체 
    {
        current_filled_time=0.0f;
        while (true) {

            if (current_filled_time == max_filled_time)
            {
                Apply_goodstate(goodstate.non);
                yield break;
            }
            yield return new WaitForSeconds(1.0f);//1초마다 유니티에게 통제권 넘기기
            current_filled_time+=1.0f;
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
