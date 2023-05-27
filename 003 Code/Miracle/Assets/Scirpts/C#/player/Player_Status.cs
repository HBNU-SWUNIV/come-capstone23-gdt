using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player_Status : MonoBehaviour//�ʱ� �������ͽ� ����
{
    //[Header("")]
    public float max_hp,current_hp, offensive_power, defensive_power, protective_film, attack_speed, critical, recovery;//�ǽð� ���� ��ġ 
    public float move_speed;

    private float early_max_hp, early_offensive_power, early_defensive_power, early_move_speed,  early_attack_speed, early_critical,early_recovery;//�Է��� �ʱⰪ ���� �Ǵ� �������� �� ����
   

    public float[] current_valid_statetime = new float[12];//�� ���º� �ð� 
    public int[] current_validnumber_state = new int[12]; //�� ���º� Ƚ�� 
    public IEnumerator[] enumerators = new IEnumerator[12];//�ڷ�ƾ ���� ���� 
    public int current_burn=0, current_toxin=0;
    public bool Is_protective_film;

    public Movement2D movement;




    void Start()
    {

        for (int i = 0; i < 7; i++) {//���� ���۽� �������� �� ���� �Ǵ� ���̺��� �ٽ� ���ӽ� ���� ���������� ����
            core_init(i);
        }
        current_hp = max_hp;
       
    }
    public void core_init(int i) {//�Ͻ����� �������ͽ� ����� �ð� ������ �ʱ�ȭ�ϱ� ���� ������ �Ǵ� ���� �������ͽ� ����� ������

        switch (i) {

            case 0://0�� ü��
                early_max_hp = max_hp;
                
                break;
            case 1://1�� ���ݷ�
                early_offensive_power = offensive_power;
               
                break;
            case 2://2�� ����
                early_defensive_power = defensive_power;
                
                break;
            case 3://3�� �̵��ӵ�
                early_move_speed = move_speed;
               
                break;
            case 4://4�� ���ݼӵ� 
                early_attack_speed = attack_speed;
                break;
            case 5://5�� ȸ��
                early_recovery = recovery;
                
                break;
            case 6://ũ��Ƽ��
                early_critical = critical;
               
                break;

        }
        
        
        
       

    }
    public void Awake()
    {
        movement = GetComponent<Movement2D>();

        for (int i = 0; i < current_valid_statetime.Length; i++)
        {
            current_valid_statetime[i] = 0.0f;
            current_validnumber_state[i] = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Is_protective_film = protective_film > 0 ? true : false;

        movement.speed = move_speed;
    }

    public void permanent_add(int i,float input)//�������� �������ͽ� ��½� ����,���� �ý���
    {
        switch (i) 
        {
            case 0://0�� ü��
                this.max_hp += input;
                core_init(0);
                break;
            case 1://1�� ���ݷ�
                this.offensive_power += input;
                core_init(1);
                break;
            case 2://2�� ����
                this.defensive_power += input;
                core_init(2);
                break;
            case 3://3�� �̵��ӵ�
                this.move_speed += input;
                core_init(3);
                break;
            case 4://4�� ���ݼӵ� 
                this.attack_speed += input;
                core_init(4);
                break;
            case 5://5�� ȸ��
                this.recovery += input;
                core_init(5);
                break;
            case 6://ũ��Ƽ��
                this.critical += input;
                core_init(6);
                break;
        }
    }
    
    public void add_hp(float input) {

        float diff = max_hp - current_hp;//�ִ� ü�°� ����ü�� ���� 

        if (current_hp < max_hp) {

            if (diff <= input)
            {
                current_hp += diff;
            }
            else if (diff > input) {
                current_hp += input;
            }
        }
        
        
    }


    public void add_offensive_power(float input)//����
    {
        this.offensive_power += input;
    }
    public void init_offensive_power()//���� �ʱ�ȭ
    {
        this.offensive_power = early_offensive_power;
    }

    public void add_attack_speed(float input)//�ż�
    {
        this.attack_speed += input;
    }
    public void init_attack_speed()//�ż� �ʱ�ȭ 
    {
        this.attack_speed = early_attack_speed;
    }

    public void add_defensive_power(float input)//�߰�  
    {
        this.defensive_power += input;
    }
    public void init_defensive_power()//�߰� �ʱ�ȭ
    {
        this.defensive_power = early_defensive_power;
    }

    public void add_move_speed(float input)//��ø
    {
        this.move_speed += input;
    }
    public void init_move_speed()//��ø �ʱ�ȭ 
    {
        this.move_speed = early_move_speed;
    }
    public void add_critical(float input)//����
    {
        this.critical += input;
    }
    public void init_critical()//���� �ʱ�ȭ 
    {
        this.critical = early_critical;
    }
    public void add_recovery(float input)//ȸ��
    {

        this.recovery += input;
    }
    public void init_recovery()//ȸ�� �ʱ�ȭ 
    {
        this.recovery = early_recovery;
    }
    public void reduce_hp_1()//ȭ��,���� ���//ȭ�󵥹��� 10
    {
        this.current_hp -= 10.0f-(defensive_power/10);
    }
    public void continuous_decline_hp(int i)//ȭ��
    {
        StartCoroutine("recover_reduce_hp", i);
    }
    IEnumerator recover_reduce_hp(int i)//ȭ��
    {
        if (i == 1)
        {
            current_burn=1;
            Invoke("reduce_hp_1", 5f);
            yield return new WaitForSeconds(60.0f);
            current_burn=0;
            CancelInvoke("reduce_hp_1");
        }
    }
    public void reduce_offensive_power(float input)//��ȭ
    {
        this.offensive_power -= input;

    }
    public void reduce_attack_speed(float input)//����
    {

        this.attack_speed -= input;
    }
    public void reduce_defensive_power(float input)//�ı�  
    {
        this.defensive_power -= input;
    }
   
    public void reduece_move_speed(float input)//�ñ�
    {
        this.move_speed -= input;
    }
    public void Start_toxin()//
    {
        this.current_hp -= (5.0f*current_toxin);//�������� ���ô� 5��
    }
    public void InVoke_fuction()
    {
        Invoke("Start_toxin", 5);
    }
    public void InVoke_Cancel_fuction()
    {
        CancelInvoke("Start_toxin");
    }

    public void init_state(int i) {//1=���ݷ� �ʱ�ȭ.2=���ݼӵ� �ʱ�ȭ 3=���� �ʱ�ȭ 4=�̵��ӵ� �ʱ�ȭ 5=ũ��Ƽ�� Ȯ�� �ʱ�ȭ  6=ȸ�� �ʱ�ȭ

        switch (i)
        {
            case 1:
                this.offensive_power = early_offensive_power;
                break;
            case 2:
                this.attack_speed = early_attack_speed;
                break;
            case 3:
                this.defensive_power = early_defensive_power;
                break;
            case 4:
                this.move_speed = early_move_speed;
                break;
            case 5:
                this.critical = early_critical;
                break;
            case 6:
                this.recovery = early_recovery;
                break;
            
        }
    }
}
