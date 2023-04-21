using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Status : MonoBehaviour
{

    [SerializeField]
    private float hp, offensive_power, defensive_power, move_speed, protective_film, attack_speed, critical;

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
    public void add_offensive_power()//���ݷ� ���� 
    {
        this.offensive_power += 10f;
    }
    public void init_offensive_power()//���ݷ� �ʱ�ȭ
    {
        this.offensive_power =20f;
    }
    public void add_defensive_power()//���� ����
    {
        this.defensive_power += 10f;
    }
    public void init_defensive_power()
    {
        this.offensive_power = 30f;
    }
    public void add_move_speed()
    {
        this.move_speed += 10f;
    }
    public void init_move_speed()
    {
        this.move_speed = 5f;
    }
    public void add_protective_film()
    {
        this.protective_film += 10f;
    }
    public void add_attack_speed()
    {
        this.attack_speed += 10f;
    }
    public void init_attack_speed()
    {
        this.attack_speed = 10f;
    }
    public void add_critical()
    {
        this.critical += 10f;
    }
    public void init_critical()
    {
        this.critical = 0f;
    }
    // Start is called before the first frame update
    void Start()//�ʱ� ���� ����
    {
        Status status = new Status(100, 20, 30, 5, 0, 10, 0);
    }
}
