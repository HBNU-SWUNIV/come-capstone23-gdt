using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    public float[] current_valid_statetime = new float[3];//�ñ�,����,�ð�
    public int[] current_validnumber_state = new int[3]; //0=����,1=�ñ�,2=�ð�
    public IEnumerator[] enumerators = new IEnumerator[3];
    public int current_burn = 0;


    [Header("�ʱⰪ ����")]
    public int hp, offensive_power, defensive_power,attack_speed, move_speed;//ü��,���ݷ�,����,���ݼӵ�,�̵��ӵ�
    
    private  float initial_hp;//�ʱ�ü��
    private int  early_move_speed, early_attack_speed;//�Է��� �ʱⰪ ���� 

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

    public void reduce_hp_1()//ȭ��,���� ���
    {
        this.hp -= 10 - (defensive_power / 10);
    }
    public void continuous_decline_hp(int i)//ȭ��,��
    {
        StartCoroutine("recover_reduce_hp", i);
    }
    IEnumerator recover_reduce_hp(int i)//ȭ��
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

    public void reduce_attack_speed(int input)//����
    {

        this.attack_speed -= input;
    }

    public void reduece_move_speed(int input)//�ñ�
    {
        this.move_speed -= input;
    }
    public void init_attack_speed()//���� �ʱ�ȭ 
    {
        this.attack_speed = early_attack_speed;
    }
    public void init_move_speed()//��ø �ʱ�ȭ 
    {
        this.move_speed = early_move_speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)//�÷��̾��� ���ݿ� ���Ұ�� 
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
