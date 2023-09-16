using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_flame_control : MonoBehaviour
{
    public GameObject condition_applicator_object;
    private Condition_applicator condition_applicator;

    // Start is called before the first frame update
    void Awake()
    {
        condition_applicator_object = GameObject.FindWithTag("Condition_applicator");
        condition_applicator = condition_applicator_object.GetComponent<Condition_applicator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Self_destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            condition_applicator.Set_state(State.burn);
            condition_applicator.Apply_state();
        }
    }
}
