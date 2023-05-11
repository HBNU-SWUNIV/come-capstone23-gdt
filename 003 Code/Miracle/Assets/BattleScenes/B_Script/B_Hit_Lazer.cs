using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class B_Hit_Lazer : MonoBehaviour
{

    Transform tr;
    Vector2 MousePos;
    float Speed = 50f;
    Vector3 dir;

    float angle;
    Vector3 dirNo;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        tr = GameObject.Find("B_Player").GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = pos - tr.position; // 마우스 - 플레이어 포지션 = 마우스 방향 벡터

        //각도
        angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

        //nomalized 단위벡터
        dirNo = new Vector3(dir.x, dir.y, 0).normalized;

       
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
