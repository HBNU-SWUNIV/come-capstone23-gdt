using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake_enviroment : MonoBehaviour
{

    [SerializeField] GameObject condition_applicator;

    // Start is called before the first frame update
    void Awake()
    {
        condition_applicator = GameObject.FindWithTag("Condition_applicator");
        condition_applicator.SetActive(false);//�÷��̾� ��������� ��Ȱ��ȭ 
    }


    void OnDestroy()
    {
        condition_applicator.SetActive(true);//�÷��̾� ��������� Ȱ��ȭ 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
