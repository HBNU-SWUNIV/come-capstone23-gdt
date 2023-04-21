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
    {//체력,공격력,방어력,데미지,이동속도,실드,공격속도,치명타율

        this.hp = hp;
        this.offensive_power = offensive_power;
        this.defensive_power = defensive_power;
        this.move_speed = move_speed;
        this.protective_film = protective_film;
        this.attack_speed = attack_speed;
        this.critical = critical;
    }

    public void add_hp(int add)//체력증가
    {
        this.hp += add;
    }
    public void add_offensive_power()//공격력 증가 
    {
        this.offensive_power += 10f;
    }
    public void init_offensive_power()//공격력 초기화
    {
        this.offensive_power =20f;
    }
    public void add_defensive_power()//위와 같음
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
    void Start()//초기 스텟 설정
    {
        Status status = new Status(100, 20, 30, 5, 0, 10, 0);
    }
}
