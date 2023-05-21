using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMenu : MonoBehaviour
{
    public Ring Data;
    public RingCakePiece RingCakePiecePrefab;
    public float GapWidthDegree = 1f;               //RingElements 사이의 거리
    protected RingCakePiece[] Pieces;

    void Start()
    {
        var stepLength = 360f / Data.Elements.Length;               //RIngElement 하나의 길이    

        //
        Pieces = new RingCakePiece[Data.Elements.Length];

        for (int i = 0; i < Data.Elements.Length; i++)
        {
            Pieces[i] = Instantiate(RingCakePiecePrefab, transform);
            //
            Pieces[i].transform.localPosition = Vector3.zero;
            Pieces[i].transform.localRotation = Quaternion.identity;

            //RingCakePiece 생성
            Pieces[i].CakePiece.fillAmount = 1f / Data.Elements.Length - GapWidthDegree / 360f;
            Pieces[i].CakePiece.transform.localPosition = Vector3.zero;
            Pieces[i].CakePiece.transform.localRotation = Quaternion.Euler(0, 0, -stepLength / 2f + GapWidthDegree / 2f + i * stepLength);

            Pieces[i].CakePiece.material = Data.Elements[i].RingMaterial;
        }
    }

    private void Update()
    {
        var stepLength = 360f / Data.Elements.Length;
        var mouseAngle = NormalizeAngle(Vector3.SignedAngle(Vector3.up, Input.mousePosition - transform.position, Vector3.forward) + stepLength);          //Vector3.up을 기준으로 마우스 위치의 각도
        var activeElement = (int)(mouseAngle / stepLength);             //마우스가 위치한 RingElement

        //
        for (int i = 0; i < Data.Elements.Length; i++)
        {
            if (i == activeElement)
                Pieces[i].CakePiece.color = new Color(1f, 1f, 1f, 0.75f);
            else
                Pieces[i].CakePiece.color = new Color(1f, 1f, 1f, 0.5f);
        }

        //오른쪽 마우스 버튼을 뗄 때
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log(Data.Elements[activeElement].Name);

            Destroy(gameObject);
        }
    }

    //각을 0이상 360 미만으로 표시
    private float NormalizeAngle(float a) => (a + 360f) % 360f;
}
