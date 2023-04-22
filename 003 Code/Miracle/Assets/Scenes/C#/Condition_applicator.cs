using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { non_good, strength, quick, solid, agility, focus, recovery, non_bad, burn, weak, deceleration, destroy, toxin, coldair, cooling }


public class Condition_applicator : MonoBehaviour
{

    public State state;
    
    [SerializeField]
    private GameObject player;

    private Status status;
    // Start is called before the first frame update
    void Awake()
    {
        status = player.GetComponent<Status>();//플레이어 오브젝트의 status 컴포넌트 접근 
    }

    public void Select_state()
    {
        switch (state)
        {
            



        }
    }
}
