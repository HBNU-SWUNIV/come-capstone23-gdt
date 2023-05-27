using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player_Status : MonoBehaviour//초기 스테이터스 설정
{
    //[Header("")]
    public float max_hp,current_hp, offensive_power, defensive_power, protective_film, attack_speed, critical, recovery;//실시간 적용 수치 
    public float move_speed;

    private float early_max_hp, early_offensive_power, early_defensive_power, early_move_speed,  early_attack_speed, early_critical,early_recovery;//입력한 초기값 저장 또는 영구적인 값 저장
   

    public float[] current_valid_statetime = new float[12];//각 상태별 시간 
    public int[] current_validnumber_state = new int[12]; //각 상태별 횟수 
    public IEnumerator[] enumerators = new IEnumerator[12];//코루틴 상태 저장 
    public int current_burn=0, current_toxin=0;
    public bool Is_protective_film;

    public Movement2D movement;




    void Start()
    {

        for (int i = 0; i < 7; i++) {//최초 시작시 영구적인 값 저장 또는 세이브후 다시 접속시 이전 영구데이터 적용
            core_init(i);
        }
        current_hp = max_hp;
       
    }
    public void core_init(int i) {//일시적인 스테이터스 상승후 시간 종료후 초기화하기 위한 값저장 또는 영구 스테이터스 상승후 저장기능

        switch (i) {

            case 0://0은 체력
                early_max_hp = max_hp;
                
                break;
            case 1://1은 공격력
                early_offensive_power = offensive_power;
               
                break;
            case 2://2는 방어력
                early_defensive_power = defensive_power;
                
                break;
            case 3://3은 이동속도
                early_move_speed = move_speed;
               
                break;
            case 4://4는 공격속도 
                early_attack_speed = attack_speed;
                break;
            case 5://5는 회복
                early_recovery = recovery;
                
                break;
            case 6://크리티컬
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

    public void permanent_add(int i,float input)//영구적인 스테이터스 상승시 저장,도감 시스템
    {
        switch (i) 
        {
            case 0://0은 체력
                this.max_hp += input;
                core_init(0);
                break;
            case 1://1은 공격력
                this.offensive_power += input;
                core_init(1);
                break;
            case 2://2는 방어력
                this.defensive_power += input;
                core_init(2);
                break;
            case 3://3은 이동속도
                this.move_speed += input;
                core_init(3);
                break;
            case 4://4는 공격속도 
                this.attack_speed += input;
                core_init(4);
                break;
            case 5://5는 회복
                this.recovery += input;
                core_init(5);
                break;
            case 6://크리티컬
                this.critical += input;
                core_init(6);
                break;
        }
    }
    
    public void add_hp(float input) {

        float diff = max_hp - current_hp;//최대 체력과 현재체력 차이 

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
    public void reduce_hp_1()//화상,방어력 비례//화상데미지 10
    {
        this.current_hp -= 10.0f-(defensive_power/10);
    }
    public void continuous_decline_hp(int i)//화상
    {
        StartCoroutine("recover_reduce_hp", i);
    }
    IEnumerator recover_reduce_hp(int i)//화상
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
    public void Start_toxin()//
    {
        this.current_hp -= (5.0f*current_toxin);//독데미지 스택당 5씩
    }
    public void InVoke_fuction()
    {
        Invoke("Start_toxin", 5);
    }
    public void InVoke_Cancel_fuction()
    {
        CancelInvoke("Start_toxin");
    }

    public void init_state(int i) {//1=공격력 초기화.2=공격속도 초기화 3=방어력 초기화 4=이동속도 초기화 5=크리티컬 확률 초기화  6=회복 초기화

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
