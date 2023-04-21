using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public enum goodstate { non,strength, quick ,solid, agility, focus ,recovery};//괴력,신속,견고,민첩,집중,회복
    public enum badstate { non,burn,weak, deceleration ,destroy,toxin,coldair,cooling}//화상,약화,감속,파괴,독,냉기,냉각
    private Movement2D movement2d;
    private Status status;
    public goodstate new_goodstate = goodstate.non;//
    public goodstate current_goodstate = goodstate.non;
    int currentnumber_goodstate = 0;
    int maxnumber_goodstate = 3;
    // Start is called before the first frame update
    private void Awake()
    {
        movement2d = GetComponent<Movement2D>();
        status= GetComponent<Status>();
    }
    public void Get_HP(int add)//체력회복
    {
        status.add_hp(add);
    }
    
    public void Apply_goodstate(goodstate input_new_goodstate)//버프 설정
    {
        switch (input_new_goodstate)
        {
            case goodstate.non:
                break;
            case goodstate.strength://괴력
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.strength;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    status.add_offensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.quick:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.quick;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    status.add_attack_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.solid:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.solid;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    status.add_defensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.agility:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.agility;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    status.add_move_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.focus:
                init_goodstate(input_new_goodstate);
                current_goodstate = goodstate.focus;
                if (currentnumber_goodstate < maxnumber_goodstate)
                {
                    status.add_critical();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.recovery:
                status.add_hp(30);
                break;
        }
    }
    public void init_goodstate(goodstate newstate)//새로운 버프 설정시 기존 버프 초기화 
    {
        if(newstate!= current_goodstate)
        {
            switch (current_goodstate)
            {
                case goodstate.strength:
                    currentnumber_goodstate = 0;
                    status.init_offensive_power();
                    break;
                case goodstate.quick:
                    currentnumber_goodstate = 0;
                    status.init_attack_speed();
                    break;
                case goodstate.solid:
                    currentnumber_goodstate = 0;
                    status.init_defensive_power();
                    break;
                case goodstate.agility:
                    currentnumber_goodstate = 0;
                    status.init_move_speed();
                    break;
                case goodstate.focus:
                    currentnumber_goodstate = 0;
                    status.init_critical();
                    break;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)//적의 공격에 피격 당할경우 
    {
        if (collision.collider.name == "Enemy_weapon")
        {
            if (status.Is_protective_film == true)//캐릭터의 보호막이 있는 경우 
            {


            }
            else if(status.Is_protective_film == false)//캐릭터의 보호막이 없는 경우 
            {
               

            }
        }
    }

    // Update is called once per frame
    void Update()//실질적 움직임 컨트롤
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement2d.Move(x);

        if (Input.GetKeyDown(KeyCode.Space)) {

            movement2d.Jump();
        
        
        }
    }
}
