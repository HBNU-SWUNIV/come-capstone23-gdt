using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deepforest_enviroment : MonoBehaviour
{
    public GameObject[] teleports;
    public int total_teleport_number;
    public GameObject first_teleport, second_teleport;

    [SerializeField] GameObject condition_applicator;
    [SerializeField] Condition_applicator applicator;


    // Start is called before the first frame update
    void Awake()
    {
        condition_applicator = GameObject.FindWithTag("Condition_applicator");
        applicator = condition_applicator.GetComponent<Condition_applicator>();
        InvokeRepeating("apply_toxin", 2f, 2f);//ó�� ������ 3���� 5�ʸ��� �ߵ�
    }

    // Update is called once per frame
     void OnDestroy()
    {
        CancelInvoke("apply_toxin");

        applicator.Init_state(9);
    }

    void Start()
    {
        teleports = GameObject.FindGameObjectsWithTag("Teleport");
        total_teleport_number = teleports.Length;
        Set_teleport();
    }

    public void apply_toxin() {
        applicator.Set_state(State.toxin);
        applicator.Apply_state();
    }

    void Set_teleport()
    {
        List<GameObject> list_teleports = teleports.ToList();
        for (int i = 0; i < total_teleport_number; i++)//�����̱� 46ȸ �ݺ�,15���� �ʵ� �� ������ �Ա��� ���� 1���� ��Ż�� ������ �� 46��,���� ���������� �̾����� ��Ż�� ���� 
        {
            int rand = Random.Range(0, list_teleports.Count);
            if (first_teleport == null)
            {
                first_teleport = list_teleports[rand];
                list_teleports.RemoveAt(rand);
            }
            else if ((first_teleport != null) && (second_teleport == null))
            {
                second_teleport = list_teleports[rand];
                list_teleports.RemoveAt(rand);
            }
            else if ((first_teleport != null) && (second_teleport != null))
            {
                first_teleport.GetComponent<Teleport>().opposite_teleport = second_teleport;
                second_teleport.GetComponent<Teleport>().opposite_teleport = first_teleport;
                first_teleport = null;
                second_teleport = null;
            }
        }
    }
}
