using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { non_good, strength, quick, solid, agility, focus, recovery, non_bad, burn, weak, deceleration, destroy, toxin, coldair, cooling }


public class Condition_applicator : MonoBehaviour
{

    public State state;

    private float max_filled_time = 60.0f;//�ִ� ���� ���ð� 

    [SerializeField]
    private GameObject player;

    [SerializeField]
    

    private Player_Status status;
    // Start is called before the first frame update
    void Awake()
    {
        status = player.GetComponent<Player_Status>();//�÷��̾� ������Ʈ�� status ������Ʈ ���� 
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
