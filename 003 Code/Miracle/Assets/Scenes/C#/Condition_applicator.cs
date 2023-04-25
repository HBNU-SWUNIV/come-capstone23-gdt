using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


public enum State { non_good, strength, quick, solid, agility, focus, recovery, non_bad, burn, weak, deceleration, destroy, toxin, coldair, cooling }


public class Condition_applicator : MonoBehaviour
{

    public State state;

    private float max_filled_time = 60.0f;//�ִ� ���� ���ð�
    private int max_number_state = 3;
    private float input_offensive_power = 5.0f, input_defensive_power = 5.0f;
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
                if (status.current_validnumber_state[0] < max_number_state)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_offensive_power(input_offensive_power);
                    status.current_validnumber_state[0]++;
                }
                break;
            case State.quick://1==�ż�
                selected_state_index = 1;
                if (status.current_validnumber_state[1] < max_number_state)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_offensive_power(input_defensive_power);
                    status.current_validnumber_state[1]++;
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


        }

    }
    IEnumerator start_reuse_waiting_time()//���� �ð� ����,60�ʰ� �Ǹ� ���� ��ü 
    {
        status.current_valid_statetime[selected_state_index] = 0.0f;
        while (true)
        {
            if (status.current_valid_statetime[selected_state_index] == max_filled_time)
            {
                Init_state(selected_state_index);
                yield break;
            }
            yield return new WaitForSeconds(1.0f);//1�ʸ��� ����Ƽ���� ������ �ѱ��
            status.current_valid_statetime[selected_state_index] += 1.0f;
        }

    }
}
