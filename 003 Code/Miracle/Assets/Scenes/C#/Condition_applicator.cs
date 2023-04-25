using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


public enum State { non_good, strength, quick, solid, agility, focus, recovery, non_bad, burn, weak, deceleration, destroy, toxin, coldair, cooling }


public class Condition_applicator : MonoBehaviour
{

    public State state;

    private float max_filled_time = 60.0f;//최대 버프 사용시간
    private int max_number_state = 3;
    private float input_offensive_power = 5.0f, input_defensive_power = 5.0f;
    private int selected_state_index;

    [SerializeField]
    private GameObject player;


    private Player_Status status;
    // Start is called before the first frame update
    void Awake()
    {
        status = player.GetComponent<Player_Status>();//플레이어 오브젝트의 status 컴포넌트 접근 
    }

    public void Apply_state()//상태 적용 
    {
        switch (state)
        {
            case State.strength://0==괴력
                selected_state_index=0;
                if (status.current_validnumber_state[0] < max_number_state)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_offensive_power(input_offensive_power);
                    status.current_validnumber_state[0]++;
                }
                break;
            case State.quick://1==신속
                selected_state_index = 1;
                if (status.current_validnumber_state[1] < max_number_state)
                {
                    StopCoroutine("start_reuse_waiting_time");//기존에 동작하던 현재 버프 사용시간 타이머 중단 
                    StartCoroutine("start_reuse_waiting_time");//새로운 버프 사용시간 타이머 동작
                    status.add_offensive_power(input_defensive_power);
                    status.current_validnumber_state[1]++;
                }
                break;
           






        }
    }
    public void Init_state(int i)//상태 초기화 
    {
        switch (i)
        {
            case 0:
                status.init_offensive_power();//괴력 초기화 
                status.current_validnumber_state[i]=0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 1:
                status.init_attack_speed();//신속 초기화 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;


        }

    }
    IEnumerator start_reuse_waiting_time()//버프 시간 시작,60초가 되면 버프 해체 
    {
        status.current_valid_statetime[selected_state_index] = 0.0f;
        while (true)
        {
            if (status.current_valid_statetime[selected_state_index] == max_filled_time)
            {
                Init_state(selected_state_index);
                yield break;
            }
            yield return new WaitForSeconds(1.0f);//1초마다 유니티에게 통제권 넘기기
            status.current_valid_statetime[selected_state_index] += 1.0f;
        }

    }
}
