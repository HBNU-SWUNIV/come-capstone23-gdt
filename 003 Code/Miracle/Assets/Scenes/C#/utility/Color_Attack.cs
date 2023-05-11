using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Color_mode {white,red,orange,yellow,green,blue,purple};

public class Color_Attack : MonoBehaviour
{

    public Color_mode selected_color;

    public GameObject Object_applicator;
    //public GameObject Object_enemy_applicator;

    private Condition_applicator applicator;
   

    public void Set_Color_mode(Color_mode color) {

        this.selected_color = color;
       }

    public void Apply_Color()//색체 적용
    {
        switch (selected_color) 
        {
            case Color_mode.white:

                break;
            case Color_mode.red://빨강
                applicator.Set_state(State.deceleration);
                applicator.Apply_state();
                break;
            case Color_mode.orange://주황
                applicator.Set_state(State.strength);
                applicator.Apply_state();
                applicator.Set_state(State.deceleration);
                applicator.Apply_state();
                break;
            case Color_mode.yellow://노랑
                applicator.Set_state(State.weak);
                applicator.Apply_state();
                applicator.Set_state(State.quick);
                applicator.Apply_state();
                break;
            case Color_mode.green://초록
                applicator.Set_state(State.weak);
                applicator.Apply_state();
                applicator.Set_state(State.deceleration);
                applicator.Apply_state();
                applicator.Set_state(State.recovery);
                applicator.Apply_state();
                break;
            case Color_mode.blue://파랑
                applicator.Set_state(State.destroy);
                applicator.Apply_state();
                break;
            case Color_mode.purple://보라 
                applicator.Set_state(State.weak);
                applicator.Apply_state();
                break;
        }
    }



    // Start is called before the first frame update
    void Awake()
    {
        Object_applicator = GameObject.FindWithTag("Condition_applicator");
        //Object_enemy_applicator = GameObject.FindWithTag("Enemy_Condition_applicator");
        applicator = Object_applicator.GetComponent<Condition_applicator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
