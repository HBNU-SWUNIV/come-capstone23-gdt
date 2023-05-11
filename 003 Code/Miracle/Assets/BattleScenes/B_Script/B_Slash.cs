using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Slash : MonoBehaviour
{
    private GameObject p;
    Vector2 MousePos;
    Vector3 dir;

    float angle;
   


  
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");

        Transform tr = p.GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position;

        angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;


    }

    // Update is called once per frame
    void Update()
    {

        //È¸Àü
        transform.rotation = Quaternion.Euler(0, 0, angle);


        transform.position = p.transform.position;
    }


    public void Des()
    {
        Destroy(gameObject);
    }

    

    
}
