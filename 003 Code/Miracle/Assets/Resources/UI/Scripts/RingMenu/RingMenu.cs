using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMenu : MonoBehaviour
{
    public Ring Data;
    public RingCakePiece RingCakePiecePrefab;
    public float GapWidthDegree = 1f;               //RingElements ������ �Ÿ�
    protected RingCakePiece[] Pieces;

    void Start()
    {
        var stepLength = 360f / Data.Elements.Length;               //RIngElement �ϳ��� ����    

        //
        Pieces = new RingCakePiece[Data.Elements.Length];

        for (int i = 0; i < Data.Elements.Length; i++)
        {
            Pieces[i] = Instantiate(RingCakePiecePrefab, transform);
            //
            Pieces[i].transform.localPosition = Vector3.zero;
            Pieces[i].transform.localRotation = Quaternion.identity;

            //RingCakePiece ����
            Pieces[i].CakePiece.fillAmount = 1f / Data.Elements.Length - GapWidthDegree / 360f;
            Pieces[i].CakePiece.transform.localPosition = Vector3.zero;
            Pieces[i].CakePiece.transform.localRotation = Quaternion.Euler(0, 0, -stepLength / 2f + GapWidthDegree / 2f + i * stepLength);

            Pieces[i].CakePiece.material = Data.Elements[i].RingMaterial;
        }
    }

    private void Update()
    {
        var stepLength = 360f / Data.Elements.Length;
        var mouseAngle = NormalizeAngle(Vector3.SignedAngle(Vector3.up, Input.mousePosition - transform.position, Vector3.forward) + stepLength);          //Vector3.up�� �������� ���콺 ��ġ�� ����
        var activeElement = (int)(mouseAngle / stepLength);             //���콺�� ��ġ�� RingElement

        //
        for (int i = 0; i < Data.Elements.Length; i++)
        {
            if (i == activeElement)
                Pieces[i].CakePiece.color = new Color(1f, 1f, 1f, 0.75f);
            else
                Pieces[i].CakePiece.color = new Color(1f, 1f, 1f, 0.5f);
        }

        //������ ���콺 ��ư�� �� ��
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log(Data.Elements[activeElement].Name);

            Destroy(gameObject);
        }
    }

    //���� 0�̻� 360 �̸����� ǥ��
    private float NormalizeAngle(float a) => (a + 360f) % 360f;
}
