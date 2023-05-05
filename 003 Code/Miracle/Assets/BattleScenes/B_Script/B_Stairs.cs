using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Stairs : MonoBehaviour
{
    
    

        public GameObject B_player;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                B_player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                B_player.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
    


