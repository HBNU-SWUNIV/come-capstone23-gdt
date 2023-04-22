using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Status : MonoBehaviour
{

    
    public float hp, offensive_power, defensive_power, move_speed, protective_film, attack_speed, critical;

    public bool Is_protective_film;
    public void Update()
    {
        Is_protective_film = protective_film > 0 ? true : false;
    }
    public Status(int hp, int offensive_power, int defensive_power, int move_speed, int protective_film, int attack_speed, int critical)
    {//ü��,���ݷ�,����,������,�̵��ӵ�,�ǵ�,���ݼӵ�,ġ��Ÿ��

        this.hp = hp;
        this.offensive_power = offensive_power;
        this.defensive_power = defensive_power;
        this.move_speed = move_speed;
        this.protective_film = protective_film;
        this.attack_speed = attack_speed;
        this.critical = critical;
    }

    public void add_hp(int add)//ü������
    {
        this.hp += add;
    }
    public void reduce_hp()
    {
        this.hp -= 5f;

    }
    public void burn()//�������� ü�°��� 
    {
        StartCoroutine("recover_burn");
    }
    IEnumerator recover_burn()//ü�°��� cover
    {
        reduce_hp();
        Invoke("reduce_hp", 3f);

        yield return new WaitForSeconds(60.0f);

        CancelInvoke("reduce_hp");
    }
   
    public void add_offensive_power()//���ݷ� ���� 
    {
        this.offensive_power += 10f;
    }
    public void init_offensive_power()//���ݷ� �ʱ�ȭ
    {
        this.offensive_power =20f;
    }
    public void reduce_offensive_power()//��ȭ 
    {
        this.offensive_power -= 2f;

        StartCoroutine("recover_offensive_power");
    }
    IEnumerator recover_offensive_power()//��ȭ cover
    {
        yield return new WaitForSeconds(60.0f);

        this.offensive_power += 2f;
    }
    public void add_defensive_power()//���� ���� 
    {
        this.defensive_power += 10f;
    }
    public void init_defensive_power()//���� �ʱ�ȭ
    {
        this.offensive_power = 30f;
    }
    public void reduce_defensive_powe()//�ı� 
    {

        this.defensive_power -= 2f;

        StartCoroutine("recover_defensive_powe");
    }
    IEnumerator recover_defensive_powe()//�ı�  cover
    {
        yield return new WaitForSeconds(60.0f);

        this.defensive_power += 2f;
    }
    public void add_move_speed()//�̵��ӵ� ���� 
    {
        this.move_speed += 10f;
    }
    public void init_move_speed()//�̵��ӵ� �ʱ�ȭ 
    {
        this.move_speed = 5f;
    }
    public void reduce_move_speed()//�ñ� 
    {
        this.move_speed -= 3f;

        StartCoroutine("recover_move_speed");
    }
    IEnumerator recover_move_speed()//�ñ�  cover
    {
        yield return new WaitForSeconds(60.0f);

        this.move_speed += 3f;
    }
    public void add_protective_film()//��ȣ�� ���� 
    {
        this.protective_film += 10f;
    }
    public void add_attack_speed()//���ݼӵ� ���� 
    {
        this.attack_speed += 10f;
    }
    public void init_attack_speed()//���ݼӵ� �ʱ�ȭ 
    {
        this.attack_speed = 10f;
    }
    public void reduce_attack_speed()//����
    {

        this.attack_speed -= 1f;

        StartCoroutine("recover_attack_speed");
    }
    IEnumerator recover_attack_speed()//���� cover
    {
        yield return new WaitForSeconds(60.0f);

        this.attack_speed += 1f;
    }
    public void add_critical()//ġ��Ÿ�� ���� 
    {
        this.critical += 10f;
    }
    public void init_critical()//ġ��Ÿ�� �ʱ�ȭ 
    {
        this.critical = 0f;
    }

    public void all_init()
    {
        init_offensive_power();
        init_defensive_power();
        init_move_speed();
        init_attack_speed();
        init_critical();
    }
    // Start is called before the first frame update
    void Start()//�ʱ� ���� ����
    {
        Status status = new Status(100, 20, 30, 5, 0, 10, 0);
    }
}
