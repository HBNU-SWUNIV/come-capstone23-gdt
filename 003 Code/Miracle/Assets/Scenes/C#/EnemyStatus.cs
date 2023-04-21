using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    //적의 경우 체력 공격력 방어력 이동속도만 조절(체력이 절반으로 깎이면 폭주모드 발동)
    
    public float hp, offensive_power, defensive_power, move_speed;

    bool Is_fever;
    public EnemyStatus(float hp,float offensive_power,float defensive_power,float move_speed)
    {

        this.hp = hp;
        this.offensive_power = offensive_power;
        this.defensive_power = defensive_power;
        this.move_speed = move_speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyStatus enemy_status = new EnemyStatus(255, 20, 30, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Is_fever = hp < 127 ? true : false;
    }
}
