using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Status : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player_Status status = new Player_Status(100, 20, 30, 5, 0, 10, 0);
    }
}
struct Player_Status 
{

    private int hp, offensive_power, defensive_power, damage, move_speed, protective_film, attack_speed, critical;

    public Player_Status(int hp, int offensive_power, int defensive_power, int move_speed, int protective_film, int attack_speed, int critical) {//체력,공격력,방어력,데미지,이동속도,실드,공격속도,치명타율

        this.hp = hp;
        this.offensive_power = offensive_power;
        this.defensive_power = defensive_power;
        this.move_speed = move_speed;
        this.protective_film = protective_film;
        this.attack_speed = attack_speed;
        this.critical = critical;


    }


}