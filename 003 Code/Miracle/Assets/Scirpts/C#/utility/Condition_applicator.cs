using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


public enum State {  non,strength, quick, solid, agility, focus, recovery,  burn, weak, deceleration, destroy, toxin, coldair, cooling }



public class Condition_applicator : MonoBehaviour
{

    public State state;

    private float max_filled_time = 60.0f;//최대 버프 사용시간
    private int max_number_state = 3;
    private float input_offensive_power = 5.0f, input_attack_speed = 5.0f, input_defensive_power = 5.0f, input_move_speed = 5.0f, input_critical = 5.0f, input_recovery = 5.0f;//중첩당 적용버프 수치
    private float input_burn=5.0f,input_weak = 5.0f, input_deceleration = 5.0f, input_destroy = 5.0f,input_coldair=5.0f;//중첩다 적용 디버프 수치 
    private int selected_state_index;

    
    public GameObject player;


    private Player_Status status;
    // Start is called before the first frame update
    void Awake()
    {
        status = player.GetComponent<Player_Status>();//플레이어 오브젝트의 status 컴포넌트 접근 
       
    }
    public void Set_state(State state) {

        this.state = state;
    }
    public void Apply_state()//상태 적용 
    {
        switch (state)
        {
            case State.strength://0==괴력
                selected_state_index=0;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.add_offensive_power(input_offensive_power);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.quick://1==신속
                selected_state_index = 1;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.add_attack_speed(input_attack_speed);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.solid://2==견고 
                selected_state_index = 2;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.add_defensive_power(input_defensive_power);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.agility://3==민첩
                selected_state_index = 3;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.add_move_speed(input_move_speed);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;

            case State.focus://4==집중
                selected_state_index = 4;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.add_critical(input_critical);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.recovery://5==회복
                selected_state_index = 5;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.add_recovery(input_recovery);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.burn://화상은 스테이터스에서 관리 
                
                if (status.current_burn < 1)
                {
                    status.continuous_decline_hp(1);
                }
                break;
            case State.weak://6== 약화 
                selected_state_index = 6;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.reduce_offensive_power(input_weak);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.deceleration://7==감속
                selected_state_index = 7;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.reduce_attack_speed(input_deceleration);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.destroy://8==파괴 
                selected_state_index = 8;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.reduce_defensive_power(input_destroy);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.toxin://9==독
                selected_state_index = 9;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    status.current_toxin++;
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.InVoke_fuction();
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.coldair://10==냉기 
                selected_state_index = 10;
                if (status.current_validnumber_state[selected_state_index] ==max_number_state)//냉각 발동
                {
                    state = State.cooling;
                    Apply_state();
                }

                else if(status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.reduece_move_speed(input_coldair);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.cooling://11==냉각 
                selected_state_index = 11;
                if (status.current_validnumber_state[selected_state_index] < 1)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine(status.enumerators[selected_state_index]);//새로운 버프 사용시간 타이머 동작
                    status.movement.jumpforce = 0.0f;
                    status.move_speed = 0.0f;
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;

        }
    }
    public void Init_state(int i)//상태 초기화 
    {
        switch (i)
        {
            case 0:
                status.init_state(1);//괴력 초기화 
                status.current_validnumber_state[i]=0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 1:
                status.init_state(2);//신속 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 2:
                status.init_state(3);//견고 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 3:
                status.init_state(4);//민첩 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 4:
                status.init_state(5);//집중 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 5:
                status.init_state(6);//회복 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 6:
                status.init_state(1);//약화 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 7:
                status.init_state(2);//감속 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 8:
                status.init_state(3);//파괴 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 9:
                status.InVoke_Cancel_fuction();//독 초기화 
                status.current_toxin = 0;
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 10:
                status.init_state(4);//냉기 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 11://냉각 초기화 
                status.movement.jumpforce = 8.0f;//점프 초기값
                status.init_state(4);//초기 이동속도 값
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
        }

    }
    IEnumerator start_reuse_waiting_time(int i)//버프 시간 시작,60초가 되면 버프 해체 
    {
        status.current_valid_statetime[i] = 0.0f;

        if (i == 11)//냉각 
        {
            while (true)
            {
                if (status.current_valid_statetime[i] == 10)
                {
                    Init_state(i);
                    yield break;
                }
                yield return new WaitForSeconds(1.0f);//1초마다 유니티에게 통제권 넘기기
                status.current_valid_statetime[i] += 1.0f;
            }
        }
        else if (i != 11)//냉각 이외의 상태 
        {
            while (true)
            {
                if (status.current_valid_statetime[i] == max_filled_time)
                {
                    Init_state(i);
                    yield break;
                }
                yield return new WaitForSeconds(1.0f);//1초마다 유니티에게 통제권 넘기기
                status.current_valid_statetime[i] += 1.0f;
            }


        }
    }
}
