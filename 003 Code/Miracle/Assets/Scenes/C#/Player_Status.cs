using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    [SerializeField]
    private float hp, offensive_power, defensive_power, move_speed, protective_film, attack_speed, critical, recovery,figure_burn,figure_toxin;//�ǽð� ���� ��ġ 

    private float early_hp, early_offensive_power, early_defensive_power, early_move_speed, early_protective_film, early_attack_speed, early_critical,early_recovery;//�Է��� �ʱⰪ ���� 

    public float[] current_valid_statetime = new float[12];//�� ���º� �ð� 
    public int[] current_validnumber_state = new int[12]; //�� ���º� Ƚ�� 
    public IEnumerator[] enumerators = new IEnumerator[12];//�ڷ�ƾ ���� ���� 

    private bool Is_protective_film;
    void Start()
    {
        
        early_offensive_power = offensive_power;
        early_defensive_power = defensive_power;
        early_move_speed = move_speed;
        early_protective_film = protective_film;
        early_attack_speed = attack_speed;
        early_critical = critical;

       
    }
    public void Awake()
    {
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
    private void reduce_hp_1()//ȭ��,���� ���
    {
        this.hp -= figure_burn-(defensive_power/10);
    }
    private void reduce_hp_2()//��,���� ü�°��� 
    {
        this.hp -= figure_toxin;
    }
    public void continuous_decline_hp(int i)//ȭ��,��
    {
        StartCoroutine("recover_burn",i);
    }
    IEnumerator recover_reduce_hp(int i)//ȭ��,��
    {
        if (i == 1)
        {
            reduce_hp_1();
            Invoke("reduce_hp_1", 5f);
            yield return new WaitForSeconds(60.0f);

            CancelInvoke("reduce_hp_1");
        }
        else if (i == 2)
        {
            reduce_hp_2();
            Invoke("reduce_hp_2", 5f);

            yield return new WaitForSeconds(60.0f);

            CancelInvoke("reduce_hp_2");
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

}
