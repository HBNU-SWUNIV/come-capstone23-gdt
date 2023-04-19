using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public enum goodstate { non,strength, quick ,solid, agility, focus ,recovery};//±«·Â,½Å¼Ó,°ß°í,¹ÎÃ¸,ÁýÁß,È¸º¹
    public enum badstate { non,burn,weak, deceleration ,destroy,toxin,coldair,cooling}//È­»ó,¾àÈ­,°¨¼Ó,ÆÄ±«,µ¶,³Ã±â,³Ã°¢
    private Movement2D movement2d;
    private Status status;
    public goodstate new_goodstate = goodstate.non;
    public goodstate current_goodstate = goodstate.non;
    int currentnumber_goodstate = 0;
    int maxnumber_goodstate = 3;
    // Start is called before the first frame update
    private void Awake()
    {
        movement2d = GetComponent<Movement2D>();
        status= GetComponent<Status>();
    }
    public void Get_HP(int add)
    {
        status.add_hp(add);
    }
    
    public void Apply_goodstate() 
    {
        switch (new_goodstate)
        {
            case goodstate.non:
                break;
            case goodstate.strength:

                current_goodstate = goodstate.strength;
                if (currentnumber_goodstate != maxnumber_goodstate)
                {
                    status.add_offensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.quick:
                current_goodstate = goodstate.quick;
                if (currentnumber_goodstate != maxnumber_goodstate)
                {
                    status.add_attack_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.solid:
                current_goodstate = goodstate.solid;
                if (currentnumber_goodstate != maxnumber_goodstate)
                {
                    status.add_defensive_power();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.agility:
                current_goodstate = goodstate.agility;
                if (currentnumber_goodstate != maxnumber_goodstate)
                {
                    status.add_move_speed();
                    currentnumber_goodstate++;
                }
                break;
            case goodstate.focus:
                current_goodstate = goodstate.focus;
                if (currentnumber_goodstate != maxnumber_goodstate)
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
    public void init_goodstate(goodstate state)
    {
        switch (state)
        {
            




        }

    }
    // Update is called once per frame
    void Update()
    {
        

        float x = Input.GetAxisRaw("Horizontal");
        movement2d.Move(x);

        if (Input.GetKeyDown(KeyCode.Space)) {

            movement2d.Jump();
        
        
        }
    }
}
