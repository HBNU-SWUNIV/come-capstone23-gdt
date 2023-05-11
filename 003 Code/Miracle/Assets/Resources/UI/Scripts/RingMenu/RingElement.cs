using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

//AssetMenu�� RingElement ���� �߰�
[CreateAssetMenu(fileName = "RingElement", menuName = "RingMenu/Element", order = 2)]
//RingElement ����
public class RingElement : ScriptableObject
{

    public string Name;                 //RingElement �̸�
    public Material RingMaterial;       //RingElement�� �� Mateial

}
