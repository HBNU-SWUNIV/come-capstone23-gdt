using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


public enum State {  strength, quick, solid, agility, focus, recovery,  burn, weak, deceleration, destroy, toxin, coldair, cooling }



public class Condition_applicator : MonoBehaviour
{

    public State state;

    private float max_filled_time = 60.0f;//�ִ� ���� ���ð�
    private int max_number_state = 3;
    private float input_offensive_power = 5.0f, input_attack_speed = 5.0f, input_defensive_power = 5.0f, input_move_speed = 5.0f, input_critical = 5.0f, input_recovery = 5.0f;
    private float input_weak = 5.0f, input_deceleration = 5.0f, input_destroy = 5.0f,input_coldair=5.0f;
    private int selected_state_index;

    [SerializeField]
    private GameObject player;


    private Player_Status status;
    // Start is called before the first frame update
    void Awake()
    {
        status = player.GetComponent<Player_Status>();//�÷��̾� ������Ʈ�� status ������Ʈ ���� 
    }

    public void Apply_state()//���� ���� 
    {
        switch (state)
        {
            case State.strength://0==����
                selected_state_index=0;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_offensive_power(input_offensive_power);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.quick://1==�ż�
                selected_state_index = 1;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_attack_speed(input_attack_speed);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.solid://2==�߰� 
                selected_state_index = 2;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_defensive_power(input_defensive_power);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.agility://3==��ø
                selected_state_index = 3;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_move_speed(input_move_speed);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;

            case State.focus://4==����
                selected_state_index = 4;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_critical(input_critical);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.recovery://5==ȸ��
                selected_state_index = 5;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_recovery(input_recovery);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.burn://ȭ���� �������ͽ����� ���� 
                
                if (status.current_burn < 1)
                {
                    status.continuous_decline_hp(1);
                }
                break;
            case State.weak://6== ��ȭ 
                selected_state_index = 6;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.reduce_offensive_power(input_weak);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.deceleration://7==����
                selected_state_index = 7;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.reduce_attack_speed(input_deceleration);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.destroy://8==�ı� 
                selected_state_index = 8;
                if (status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.reduce_defensive_power(input_destroy);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.toxin://���� �������ͽ����� ���� 
                if (status.current_toxin < 1)
                {
                    status.continuous_decline_hp(2);
                }
                break;
            case State.coldair://9==�ñ� 
                selected_state_index = 9;
                if (status.current_validnumber_state[selected_state_index] ==max_number_state)//�ð� �ߵ�
                {
                    state = State.cooling;
                    Apply_state();
                }

                else if(status.current_validnumber_state[selected_state_index] < max_number_state)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.reduece_move_speed(input_coldair);
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;
            case State.cooling://10==�ð� 
                selected_state_index = 10;
                if (status.current_validnumber_state[selected_state_index] < 1)
                {
                    status.enumerators[selected_state_index] = start_reuse_waiting_time(selected_state_index);
                    StopCoroutine(status.enumerators[selected_state_index]);//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine(status.enumerators[selected_state_index]);//���ο� ���� ���ð� Ÿ�̸� ����
                    status.movement.jumpforce = 0.0f;
                    status.move_speed = 0.0f;
                    status.current_validnumber_state[selected_state_index]++;
                }
                break;

        }
    }
    public void Init_state(int i)//���� �ʱ�ȭ 
    {
        switch (i)
        {
            case 0:
                status.init_offensive_power();//���� �ʱ�ȭ 
                status.current_validnumber_state[i]=0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 1:
                status.init_attack_speed();//�ż� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 2:
                status.init_defensive_power();//�߰� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 3:
                status.init_move_speed();//��ø �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 4:
                status.init_critical();//���� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 5:
                status.init_recovery();//ȸ�� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 6:
                status.init_offensive_power();//��ȭ �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 7:
                status.init_attack_speed();//���� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 8:
                status.init_defensive_power();//�ı� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;

            case 9:
                status.init_move_speed();//�ñ� �ʱ�ȭ 
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
            case 10://�ð� �ʱ�ȭ 
                status.movement.jumpforce = 8.0f;//���� �ʱⰪ
                status.init_move_speed();//�ʱ� �̵��ӵ� ��
                status.current_validnumber_state[i] = 0;
                status.current_valid_statetime[i] = 0.0f;
                break;
        }

    }
    IEnumerator start_reuse_waiting_time(int i)//���� �ð� ����,60�ʰ� �Ǹ� ���� ��ü 
    {
        status.current_valid_statetime[i] = 0.0f;

        if (i == 10)//�ð� 
        {
            while (true)
            {
                if (status.current_valid_statetime[i] == 10)
                {
                    Init_state(i);
                    yield break;
                }
                yield return new WaitForSeconds(1.0f);//1�ʸ��� ����Ƽ���� ������ �ѱ��
                status.current_valid_statetime[i] += 1.0f;
            }
        }
        if (i != 10)//�ð� �̿��� ���� 
        {
            while (true)
            {
                if (status.current_valid_statetime[i] == max_filled_time)
                {
                    Init_state(i);
                    yield break;
                }
                yield return new WaitForSeconds(1.0f);//1�ʸ��� ����Ƽ���� ������ �ѱ��
                status.current_valid_statetime[i] += 1.0f;
            }


        }
    }
}
