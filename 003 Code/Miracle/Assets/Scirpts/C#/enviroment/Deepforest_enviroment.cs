using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deepforest_enviroment : MonoBehaviour
{

    [SerializeField] GameObject condition_applicator;
    [SerializeField] Condition_applicator applicator;


    // Start is called before the first frame update
    void Awake()
    {
        condition_applicator = GameObject.FindWithTag("Condition_applicator");
        applicator = condition_applicator.GetComponent<Condition_applicator>();
        InvokeRepeating("apply_toxin", 2f, 2f);//처음 시작후 3초후 5초마다 발동
    }

    // Update is called once per frame
     void OnDestroy()
    {
        CancelInvoke("apply_toxin");

        applicator.Init_state(9);
    }

    public void apply_toxin() {
        applicator.Set_state(State.toxin);
        applicator.Apply_state();
    }
}
