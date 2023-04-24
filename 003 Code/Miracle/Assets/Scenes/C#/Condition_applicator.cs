using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { non_good, strength, quick, solid, agility, focus, recovery, non_bad, burn, weak, deceleration, destroy, toxin, coldair, cooling }


public class Condition_applicator : MonoBehaviour
{

    public State state;

    private float max_filled_time = 60.0f;//최대 버프 사용시간 

    [SerializeField]
    private GameObject player;

    [SerializeField]
    

    private Player_Status status;
    // Start is called before the first frame update
    void Awake()
    {
        status = player.GetComponent<Player_Status>();//플레이어 오브젝트의 status 컴포넌트 접근 
    }

    public void Apply_state()
    {
        switch (state)
        {
            case State.strength:

                

                break;





        }
    }
}
