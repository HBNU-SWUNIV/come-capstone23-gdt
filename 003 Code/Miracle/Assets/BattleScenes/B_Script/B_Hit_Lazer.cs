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
        dir = pos - tr.position; // ���콺 - �÷��̾� ������ = ���콺 ���� ����

        //����
        angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

        //nomalized ��������
        dirNo = new Vector3(dir.x, dir.y, 0).normalized;

       
    }

    // Update is called once per frame
    void Update()
    {
        //ȸ��
        transform.rotation = Quaternion.Euler(0f, 0f, angle);



        //�̵�
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}
