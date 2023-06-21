using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Transform Mtr;
    Transform Ptr;
    float Speed = 10f;
    public GameObject Bullet;
    Vector3 Atkdir;
    float angle;
    Vector3 dirNo;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        Ptr = GameObject.Find("B_Player").GetComponent<Transform>();
        Mtr = GameObject.Find("M_mob (2)").GetComponent<Transform>();
        Atkdir = Ptr.transform.position - Mtr.transform.position;
        //각도
        angle = Mathf.Atan2(Atkdir.y, Atkdir.x) * Mathf.Rad2Deg;

        //nomalized 단위벡터
        dirNo = new Vector3(Atkdir.x, Atkdir.y, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //회전
        transform.rotation = Quaternion.Euler(0f, 0f, angle);



        //이동
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}
