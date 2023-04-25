using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    [SerializeField]
    private float hp, offensive_power, defensive_power, move_speed, protective_film, attack_speed, critical, recovery,figure_burn,figure_toxin;//실시간 적용 수치 

    private float early_hp, early_offensive_power, early_defensive_power, early_move_speed, early_protective_film, early_attack_speed, early_critical,early_recovery;//입력한 초기값 저장 

    public float[] current_valid_statetime = new float[12];//각 상태별 시간 
    public int[] current_validnumber_state = new int[12]; //각 상태별 횟수 
    public IEnumerator[] enumerators = new IEnumerator[12];//코루틴 상태 저장 

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

    public void add_offensive_power(float input)//괴력
    {
        this.offensive_power += input;
    }
    public void init_offensive_power()//괴력 초기화
    {
        this.offensive_power = early_offensive_power;
    }

    public void add_attack_speed(float input)//신속
    {
        this.attack_speed += input;
    }
    public void init_attack_speed()//신속 초기화 
    {
        this.attack_speed = early_attack_speed;
    }

    public void add_defensive_power(float input)//견고  
    {
        this.defensive_power += input;
    }
    public void init_defensive_power()//견고 초기화
    {
        this.defensive_power = early_defensive_power;
    }

    public void add_move_speed(float input)//민첩
    {
        this.move_speed += input;
    }
    public void init_move_speed()//민첩 초기화 
    {
        this.move_speed = early_move_speed;
    }
    public void add_critical(float input)//집중
    {
        this.critical += input;
    }
    public void init_critical()//집중 초기화 
    {
        this.critical = early_critical;
    }
    public void add_recovery(float input)//회복
    {

        this.recovery += input;
    }
    public void init_recovery()//회복 초기화 
    {
        this.recovery = early_recovery;
    }
    private void reduce_hp_1()//화상,방어력 비례
    {
        this.hp -= figure_burn-(defensive_power/10);
    }
    private void reduce_hp_2()//독,순수 체력감소 
    {
        this.hp -= figure_toxin;
    }
    public void continuous_decline_hp(int i)//화상,독
    {
        StartCoroutine("recover_burn",i);
    }
    IEnumerator recover_reduce_hp(int i)//화상,독
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
    public void reduce_offensive_power(float input)//약화
    {
        this.offensive_power -= input;

    }
    public void reduce_attack_speed(float input)//감속
    {

        this.attack_speed -= input;
    }
    public void reduce_defensive_power(float input)//파괴  
    {
        this.defensive_power -= input;
    }
   
    public void reduece_move_speed(float input)//냉기
    {
        this.move_speed -= input;
    }

}
