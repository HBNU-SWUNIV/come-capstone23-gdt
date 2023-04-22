using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public enum goodstate { non,strength, quick ,solid, agility, focus ,recovery};//����,�ż�,�߰�,��ø,����,ȸ��
    public enum badstate { non,burn,weak, deceleration ,destroy,coldair,cooling}//ȭ��,��ȭ,����,�ı�,��,�ñ�,�ð�
    private Movement2D movement2d;
    private Status status;
    private float current_filled_time=0.0f;//���� ����  ���ð�
    private float max_filled_time=60.0f;//�ִ� ���� ���ð� 
    public goodstate new_goodstate = goodstate.non;//���ο� ���� ���� ����
    public goodstate current_goodstate = goodstate.non;//���� ���� ���� 
   
    public badstate current_badstate = badstate.non;//���� ����� ���� 
    private int currentnumber_goodstate = 0;
    private int maxnumber_goodstate = 3;

   
    
    // Start is called before the first frame update
    private void Awake()
    {
        movement2d = GetComponent<Movement2D>();
        status= GetComponent<Status>();
    }
   
    
    public void Apply_goodstate(goodstate input_new_goodstate)//���� ����
    {
        switch (input_new_goodstate)
        {
            case goodstate.non://���� ��ü
                status.all_init();//��� ���� �ʱ�ȭ 
                current_goodstate = goodstate.non;
                currentnumber_goodstate = 0; 
                break;
            case goodstate.strength://����
                init_goodstate(input_new_goodstate);//current_goodstate ���� ���� 
                current_goodstate = goodstate.strength;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_offensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.quick:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.quick;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_attack_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.solid:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.solid;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_defensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.agility:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.agility;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_move_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.focus:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.focus;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    StopCoroutine("start_reuse_waiting_time");//������ �����ϴ� ���� ���� ���ð� Ÿ�̸� �ߴ� 
                    StartCoroutine("start_reuse_waiting_time");//���ο� ���� ���ð� Ÿ�̸� ����
                    status.add_critical();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.recovery:
                status.add_hp(30);
                break;
        }
    }
    public void init_goodstate(goodstate newstate)//���ο� ���� ������ ���� ���� �ʱ�ȭ 
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
    
    public void Apply_badstate(badstate input_new_badstate)//����� ���� 
    {
        switch (input_new_badstate)
        {
            case badstate.burn://ȭ��
                current_badstate = badstate.burn;
                status.burn();
                break;
            case badstate.weak://��ȭ
                current_badstate = badstate.weak;
                status.reduce_offensive_power();
                break;
            case badstate.deceleration://����
                current_badstate = badstate.deceleration;
                status.reduce_attack_speed();
                break;
            case badstate.destroy://�ı�
                current_badstate = badstate.destroy;
                status.reduce_defensive_powe();
                break;
            case badstate.coldair://�ñ�
                current_badstate = badstate.coldair;
                status.reduce_move_speed();
                break;
            
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)//���� ���ݿ� �ǰ� ���Ұ�� 
    {
        if (collision.collider.name == "Enemy_weapon")
        {
            float enemy_offensive = collision.gameObject.GetComponent<EnemyStatus>().offensive_power;
            
            if (status.Is_protective_film == true)//ĳ������ ��ȣ���� �ִ� ��� 
            {
                if(status.protective_film>=enemy_offensive)//�Ǽ�ġ ��Ƴ��� 
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
            else if(status.Is_protective_film == false)//ĳ������ ��ȣ���� ���� ��� 
            {
                status.hp -= enemy_offensive - (status.defensive_power / 10);
            }
        }
    }

    IEnumerator start_reuse_waiting_time()//���� �ð� ����,60�ʰ� �Ǹ� ���� ��ü 
    {
        current_filled_time=0.0f;
        while (true) {

            if (current_filled_time == max_filled_time)
            {
                Apply_goodstate(goodstate.non);
                yield break;
            }
            yield return new WaitForSeconds(1.0f);//1�ʸ��� ����Ƽ���� ������ �ѱ��
            current_filled_time+=1.0f;
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
