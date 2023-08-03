using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angel_long_attack_move : MonoBehaviour
{
    public GameObject Player;
    public bool IsPlayerRight,IsPlayerUp,Is_x_same,Is_y_same;
    public SpriteRenderer render;
    public Animator animator;
   
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Self_destroy()//플레이어에게 피격되거나 맵 밖을 나가면 파괴 
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Check_x();
        render.flipX = IsPlayerRight;
        Check_y();

        if (Is_y_same == true)//높이가 같을경우
        {
            animator.SetTrigger("long_attack_left");
        }
        else if(Is_y_same == false)
        {
            if (IsPlayerUp == true)
            {
                if (Is_x_same == true)
                {
                    animator.SetTrigger("long_attack_up");
                }
                else if (Is_x_same == false)
                {
                    animator.SetTrigger("long_attack_leftup");
                }
            }
            else if(IsPlayerUp == false)
            {
                if (Is_x_same == true)
                {
                    animator.SetTrigger("long_attack_down");
                }
                else if (Is_x_same == false)
                {
                    animator.SetTrigger("long_attack_leftdown");
                }
            }
        }



    }

    public void Check_x()
    {
        if (Player.transform.position.x > this.transform.position.x)
        {
            IsPlayerRight = true;
            Is_x_same = false;
        }
        else if (Player.transform.position.x < this.transform.position.x)
        {
            IsPlayerRight = false;
            Is_x_same = false;
        }
        else if (Player.transform.position.x == this.transform.position.x)
        {
            Is_x_same = true;
        }
    }
    public void Check_y()
    {
        if (Player.transform.position.y < this.transform.position.y)
        {
            IsPlayerUp = true;
            Is_y_same = false;
        }
        else if (Player.transform.position.y > this.transform.position.y)
        {
            IsPlayerUp = false;
            Is_y_same = false;
        }
        else if (Player.transform.position.y == this.transform.position.y)
        {
            IsPlayerUp = false;
            Is_y_same = true;
        }
    }
}
