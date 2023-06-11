using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    public float[] current_valid_statetime = new float[3];//냉기,감속,냉각
    public int[] current_validnumber_state = new int[3]; //0=감속,1=냉기,2=냉각
    public IEnumerator[] enumerators = new IEnumerator[3];
    public int current_burn = 0;


    [Header("초기값 적용")]
    public int hp, offensive_power, defensive_power,attack_speed, move_speed;//체력,공격력,방어력,공격속도,이동속도
    
    private  float initial_hp;//초기체력
    private int  early_move_speed, early_attack_speed;//입력한 초기값 저장 

    private Material Enemy_material;
    private SpriteRenderer render;
    private EnemyMove enemy_move;
    private GameObject Object_enemy_applicator;
    private Enemy_Condition_applicator enemy_applicator;
    // Start is called before the first frame update

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        Enemy_material = render.material;
        enemy_move = GetComponent<EnemyMove>();
        Object_enemy_applicator = GameObject.FindWithTag("Enemy_Condition_applicator");
        enemy_applicator = Object_enemy_applicator.GetComponent<Enemy_Condition_applicator>();
    }
    void Start()
    {
        initial_hp = hp;
        early_move_speed = move_speed;
        early_attack_speed = attack_speed;
        Enemy_material.color= new Color(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float percent = (initial_hp - hp / initial_hp);

        Enemy_material.color = new Color(percent*255, percent * 255, percent * 255);

        enemy_move.movespeed = this.move_speed;
    }

    public void reduce_hp_1()//화상,방어력 비례
    {
        this.hp -= 10 - (defensive_power / 10);
    }
    public void continuous_decline_hp(int i)//화상,독
    {
        StartCoroutine("recover_reduce_hp", i);
    }
    IEnumerator recover_reduce_hp(int i)//화상
    {
        if (i == 1)
        {
            current_burn = 1;
            InvokeRepeating("reduce_hp_1", 3f,5f);
            yield return new WaitForSeconds(60.0f);
            current_burn = 0;
            CancelInvoke("reduce_hp_1");
        }
    }

    public void reduce_attack_speed(int input)//감속
    {

        this.attack_speed -= input;
    }

    public void reduece_move_speed(int input)//냉기
    {
        this.move_speed -= input;
    }
    public void init_attack_speed()//감속 초기화 
    {
        this.attack_speed = early_attack_speed;
    }
    public void init_move_speed()//민첩 초기화 
    {
        this.move_speed = early_move_speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)//플레이어의 공격에 당할경우 
    {
        if(collision.gameObject.tag.Equals("Red_attack"))
        {
            enemy_applicator.Set_status(this);
            enemy_applicator.Set_Enemy_State(Enemy_State.burn);
            enemy_applicator.Apply_state();
        }
        else if(collision.gameObject.tag.Equals("Blue attack")) 
        {
            enemy_applicator.Set_status(this);
            enemy_applicator.Set_Enemy_State(Enemy_State.cooling);
            enemy_applicator.Apply_state();
        }
        else if(collision.gameObject.tag.Equals("Purplr attack"))
        {
            enemy_applicator.Set_status(this);
            enemy_applicator.Set_Enemy_State(Enemy_State.deceleration);
            enemy_applicator.Apply_state();
        }
    }
}
