using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field_enviroment : MonoBehaviour
{//����Ƽ ���� �ߺ�����,
    public GameObject[] teleports;
    public int total_teleport_number;
    public GameObject first_teleport, second_teleport;
    // Start is called before the first frame update
    void Start()
    {
        teleports = GameObject.FindGameObjectsWithTag("Teleport");
        total_teleport_number = teleports.Length;
        Set_teleport();
    }


    void Set_teleport()
    {
        List<GameObject> list_teleports = teleports.ToList();
        for (int i = 0; i < list_teleports.Count; i++)//�����̱� 46ȸ �ݺ�,15���� �ʵ� �� ������ �Ա��� ���� 1���� ��Ż�� ������ �� 46��,���� ���������� �̾����� ��Ż�� ���� 
        {
            int rand = Random.Range(0, list_teleports.Count);
            if (first_teleport == null)
            {
                first_teleport = list_teleports[rand];
                list_teleports.RemoveAt(rand);
            }
            else if ((first_teleport != null)&&(second_teleport==null))
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
