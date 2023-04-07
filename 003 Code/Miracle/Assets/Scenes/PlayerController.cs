using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour
{

    private Movement2D movement2d;


    // Start is called before the first frame update
    void Start()
    {
        movement2d = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();


    }
    public void UpdateMove() {

        float x = Input.GetAxisRaw("Horizontal");

        movement2d.MoveTo(x);
    }
}
